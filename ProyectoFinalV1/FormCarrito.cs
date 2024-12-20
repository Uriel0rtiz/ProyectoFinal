﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient; // Para conectarnos a nuestra base de datos
using System.Data;
using System.Media; // Para poder usar sonidos

namespace ProyectoFinalV1
{
    public partial class FormCarrito : Form
    {
        // Variables para guardar y reproducir los sonidos
        SoundPlayer playlogout;
        SoundPlayer playBoton;

        // Variable para guardar el monto total de la compra
        int total;

        // Variable para guardar el monto total tras el aumento del 6%
        int total_impuesto;

        // Creamos nuestra lista que va a almacenar el carrito que nos llego en el constructor
        List<Juegos> carrito = new List<Juegos>();

        // Creamos nuestra lista que va a almacenar la informacion de los juegos que nos llego en el constructor
        List<Juegos> lista = new List<Juegos>();

        // Variable para almacenar al usuario que ingreso
        Persona usuario;

        // Constructor vacio
        public FormCarrito()
        {
            InitializeComponent();
        }

        // Constructor por parametros (recibimos la lista que representa nuestro carrito de compras)
        public FormCarrito(List<Juegos> carrito_constructor, List<Juegos> lista_constructor, Persona usuario_constructor)
        {
            // Llamamos a nuestra funcion importante
            InitializeComponent();

            // Guardamos la lista que nos llego a nuestra variable local
            carrito = carrito_constructor;

            // Guardamos la lista que nos llego a nuestra variable local
            lista = lista_constructor;

            // Llenamos el DataGridView con los datos del carrito
            LlenarDataGridView();

            // Mostramos los precios
            Calcular_Total();

            // Guardamos a nuestro usuario
            usuario = usuario_constructor;

            // Cargamos los sonidos a utilizar
            playlogout = new SoundPlayer(Properties.Resources.LogOut);
            playBoton = new SoundPlayer(Properties.Resources.Boton);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormCarrito_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btncerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_SeguirComprando_Click(object sender, EventArgs e)
        {
            playlogout.Play();
            // Cerramos este form, y regresamos al anterior
            this.Dispose();
        }

        // Metodo para llenar el DataGridView con los datos del carrito
        private void LlenarDataGridView()
        {
            // Agrupamos los juegos por nombre y plataforma, y contamos la cantidad de veces que se repiten
            var juegosAgrupados = carrito //Var es una palabra reservada de C# que nos permite declarar una variable sin especificar su tipo
                .GroupBy(j => new { j.Nombre, j.Plataforma, j.Precio })//GroupBy es una funcion de la libreria LINQ funciona para agrupar los datos
                .Select(g => new//Select es una funcion de la libreria LINQ funciona para seleccionar los datos
                {
                    Nombre = g.Key.Nombre,//Key es una propiedad de la clase GroupBy que nos permite acceder a la clave por la que se agruparon los datos
                    Plataforma = g.Key.Plataforma,//Key es una propiedad de la clase GroupBy que nos permite acceder a la clave por la que se agruparon los datos
                    Cantidad = g.Count(),//Count es una funcion de la libreria LINQ que nos permite contar los elementos de un grupo
                    Precio = g.Key.Precio * g.Count()//Count es una funcion de la libreria LINQ que nos permite contar los elementos de un grupo
                })
                .ToList();//ToList es una funcion de la libreria LINQ que nos permite convertir los datos a una lista

            // Llenamos el DataGridView con los datos agrupados
            foreach (var juego in juegosAgrupados)
            {
                dataGridView_CarritodeCompras.Rows.Add(juego.Nombre, juego.Plataforma, juego.Cantidad, juego.Precio);
            }
        }

        // Funcion para calcular el precio estimado y el precio con iva
        private void Calcular_Total()
        {
            // Recorremos nuestra lista
            for (int i = 0; i < carrito.Count; i++)
            {
                // Acumulamos el precio de los productos
                total += carrito[i].Precio;
            }

            // Mostramos el valor en nuestro textBox
            textBox_Total.Text = $"${total.ToString()} MXN";

            // Calculamos el 6% de impuesto
            total_impuesto = Convert.ToInt32(total * 1.06);

            // Mostramos el valor en nuestro textBox
            textBox_TotalIva.Text = $"${total_impuesto.ToString()} MXN";
        }

        // Cuando el usuario haga click, se borrara el carrito por completo
        private void button_BorrarCarrito_Click(object sender, EventArgs e)
        {

            playBoton.Play();

            // Como no se efectuo la compra, entonces regresamos al stock los productos
            Regresar_Stock();

            // Vaciamos por completo nuestra lista que representa nuestro carrito
            carrito.Clear();

            // Mostramos el valor en nuestro textBox
            textBox_Total.Text = "$0 MXN";

            // Mostramos el valor en nuestro textBox
            textBox_TotalIva.Text = "$0 MXN";

            // Limpiamos el dataGrid
            dataGridView_CarritodeCompras.Rows.Clear();

            // Actualizamos el dataGrid
            dataGridView_CarritodeCompras.Refresh();
        }

        private void Regresar_Stock()
        {
            // Agrupamos los juegos por nombre y plataforma, y contamos la cantidad
            var juegosAgrupados = carrito
                .GroupBy(j => new { j.Nombre, j.Plataforma })
                .Select(g => new
                {
                    Nombre = g.Key.Nombre,
                    Plataforma = g.Key.Plataforma,
                    Cantidad = g.Count()
                })
                .ToList();

            // Actualizamos nuestra base de datos
            try
            {
                using (MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;"))
                {
                    conexion.Open();

                    foreach (var juego in juegosAgrupados)
                    {
                        // Actualizamos solo el stock del juego correspondiente
                        string consulta = "UPDATE juegos SET Stock = Stock + @Cantidad " +
                                          "WHERE Nombre = @Nombre AND Plataforma = @Plataforma";

                        MySqlCommand comando = new MySqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@Cantidad", juego.Cantidad);
                        comando.Parameters.AddWithValue("@Nombre", juego.Nombre);
                        comando.Parameters.AddWithValue("@Plataforma", juego.Plataforma);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al regresar stock: " + ex.Message);
            }
        }

        // Cuando el usuario quiera seguir con el pago
        private void button_ContinuarPago_Click(object sender, EventArgs e)
        {

            if (carrito.Count == 0)
            {
                MessageBox.Show("No es posible continuar con el pago sin productos");
            }
            else
            {

                playBoton.Play();
                // Creamos el formPago, mandando nuestro total
                FormPago formPago = new FormPago(total_impuesto, usuario, carrito);

                // Ocultamos este form
                this.Hide();

                // Mostramos el form creado usando ShowDialog para cuando nos querramos salir
                formPago.ShowDialog();

                // Cerramos este form por completo
                this.Dispose();
            }

        }
    }
}