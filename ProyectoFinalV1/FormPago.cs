using MySql.Data.MySqlClient; // Para poder usar nuestra base de datos
using System.Globalization; // Para poder obtener la fecha actual
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoFinalV1
{
    public partial class FormPago : Form
    {

        // Variable para almacenar el total que nos llega por parte del constructor
        int total_impuesto;
        // Variable para nuestro PDF
        int folio;

        // Banderas para saber que tipo de pago se esta realizando
        bool bandera_Efectivo, bandera_Tarjeta;

        // Variable para almacenar al usuario que ingreso
        Persona usuario;

        // Constuctor vacio
        public FormPago()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Constructor por parametros (nos llega nuestro total de la compra)
        public FormPago(int total_impuesto_constructor, Persona usuario_constructor)
        {
            // Llamamos a nuestra funcion importante
            InitializeComponent();

            // Guardamos el valor de nuestra variable
            total_impuesto = total_impuesto_constructor;

            // Guardamos a nuestro usuario
            usuario = usuario_constructor;

            textBox_TotalCompra.Text = total_impuesto.ToString();
        }

        // En caso de que se haya elegido para con efectivo
        private void radioButton_Efectivo_CheckedChanged(object sender, EventArgs e)
        {
            PagoEfectivo.Width = 286;
            button_Pagar.Width = 0;
            PanelEfectivo.Width = 482; // Mostrar panel efectivo
            panel1.Width = 0; // Ocultar panel tarjeta

            // Ocultamos la informacion para hacer el pago por tarjeta
            textBox_NombreCuenta.Visible = false;
            textBox_NumeroTarjeta.Visible = false;
            textBox_MesTarjeta.Visible = false;
            textBox_YearTarjeta.Visible = false;
            textBox_CVVTarjeta.Visible = false;

            // Mostramos la informacion para hacer el pago de efectivo
            textBox_Efectivo.Visible = true;

            // Seleccionamos pagar con efectivo
            bandera_Efectivo = true;
            // Para asegurarnos de que la otra bandera no este activa
            bandera_Tarjeta = false;
        }

        // En caso de que se haya elegido con tarjeta 
        private void radioButton_Tarjeta_CheckedChanged(object sender, EventArgs e)
        {
            PagoEfectivo.Width = 0;
            button_Pagar.Width = 286;
            panel1.Width = 482; // Mostrar panel tarjeta
            PanelEfectivo.Width = 0; // Ocultar panel efectivo

            // Ocultamos la informacion para hacer el pago de efectivo
            textBox_Efectivo.Visible = false;

            // Mostramos la informacion para hacer el pago por tarjeta
            textBox_NombreCuenta.Visible = true;
            textBox_NumeroTarjeta.Visible = true;
            textBox_MesTarjeta.Visible = true;
            textBox_YearTarjeta.Visible = true;
            textBox_CVVTarjeta.Visible = true;

            // Seleccionamos pagar con tarjeta
            bandera_Tarjeta = true;
            // Para asegurarnos de que la otra bandera no este activa
            bandera_Efectivo = false;

        }

        private void button_Pagar_Click(object sender, EventArgs e)
        {

            // Checamos cual metodo de pago ha sido seleccionado
            if (bandera_Tarjeta)
            {
                // Guardamos la informacion en nuestro objeto de la clase Tarjeta
                Tarjeta informacion = new Tarjeta(textBox_NombreCuenta.Text,
                    Convert.ToInt64(textBox_NumeroTarjeta.Text),
                    Convert.ToInt32(textBox_MesTarjeta.Text),
                    Convert.ToInt32(textBox_YearTarjeta.Text),
                    Convert.ToInt32(textBox_CVVTarjeta.Text)
                    );

                // Llamamos a una funcion para que verifique si la informacion de la tarjeta es correcta Verificar_Informacion(informacion
                if (Verificar_Informacion(informacion))
                {
                    // Realizamos la compra
                    try
                    {
                        // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
                        MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
                        // Abrimos nuestra base de datos
                        conexion.Open();

                        // Linea de comando de SQL
                        string consulta = "UPDATE personas SET Monto=" + "'" + (total_impuesto + usuario.Monto) + "'" +
                            "WHERE ID =" + usuario.Id;

                        // Cargamos neestra linea de comandos
                        MySqlCommand comando = new MySqlCommand(consulta, conexion);

                        // Ejecutamos el comando
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Compra realizada con exito");

                        // Actualizamos el valor del monto
                        usuario.Monto += total_impuesto;

                        // Tras realizar la compra, cerramos este form
                        this.Dispose();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en la actualizacion del registro: " + ex.Message);
                    }

                }
                else
                {
                    // Mostramos mensaje de que la tarjeta no es valida
                    MessageBox.Show("La informacion de la tarjeta no es valida, verifica la informacion");
                }

            }
            else if (bandera_Efectivo)
            {
                int dinero_usuario = Convert.ToInt32(textBox_Efectivo.Text);

                if (dinero_usuario < total_impuesto)
                {
                    MessageBox.Show("Dinero insuficiente para la compra");
                }
                else
                {
                    // Realizamos la compra
                    try
                    {
                        // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
                        MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
                        // Abrimos nuestra base de datos
                        conexion.Open();

                        // Linea de comando de SQL
                        string consulta = "UPDATE personas SET Monto=" + "'" + (total_impuesto + usuario.Monto) + "'" +
                            "WHERE ID =" + usuario.Id;

                        // Cargamos neestra linea de comandos
                        MySqlCommand comando = new MySqlCommand(consulta, conexion);

                        // Ejecutamos el comando
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Compra realizada con exito");

                        // Actualizamos el valor del monto
                        usuario.Monto += total_impuesto;

                        // Tras realizar la compra, cerramos este form
                        this.Dispose();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en la actualizacion del registro: " + ex.Message);
                    }
                }
            }

        }

        private bool Verificar_Informacion(Tarjeta objeto)
        {
            // Primero verificamos si el numero de cuenta es de 16 digitos
            if (objeto.Numero.ToString().Length != 16)
            {
                return false;
            }

            // Obtenemos la fecha actual
            DateTime hoy = DateTime.Today;

            // Verificamos si la tarjeta es vigente
            if (objeto.Year < hoy.Year || (objeto.Year == hoy.Year && objeto.Mes < hoy.Month))
            {
                return false;
            }

            return true;

        }

        private void textBox_TotalIva_TextChanged(object sender, EventArgs e)
        {

        }
        private void label_Pregunta_Click(object sender, EventArgs e)
        {
            // Lógica para manejar el evento
        }


        private void textBox_TotalCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Efectivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_MesTarjeta_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void FormPago_Load(object sender, EventArgs e)
        {
            panel1.Width = 0; // Ocultar el panel tarjeta
            PanelEfectivo.Width = 0; // Ocultar el panel efectivo

            textBox_Efectivo.Visible = false; // Ocultar campos de efectivo
            textBox_NombreCuenta.Visible = false; // Ocultar campos de tarjeta
            textBox_NumeroTarjeta.Visible = false;
            textBox_MesTarjeta.Visible = false;
            textBox_YearTarjeta.Visible = false;
            textBox_CVVTarjeta.Visible = false;

            // Inicializar banderas
            bandera_Tarjeta = false;
            bandera_Efectivo = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelEfectivo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBarras formBarras = new FormBarras();
            formBarras.Show();
        }

        private void textBox_Efectivo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void FormPago_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            ReleaseCapture();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            ReleaseCapture();
        }
    }

}
