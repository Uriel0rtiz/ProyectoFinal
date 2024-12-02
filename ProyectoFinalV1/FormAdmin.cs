using MySql.Data.MySqlClient; // Para poder usar nuestra base de datos
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoFinalV1
{

    public partial class FormAdmin : Form
    {

        // Variable global para cargar el nombre de las imagenes a cargar
        string NombreModificar="";
        string NombreSubir="";

        public FormAdmin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Boton para cargar la imagen
        private void button_CargarImagenModificar_Click(object sender, EventArgs e)
        {
            // Abrimos el explorador de archivos
            OpenFileDialog abrirImagen = new OpenFileDialog();

            // Filtro para el tipo de archivo aceptado
            abrirImagen.Filter = "Archivos de imagenes (*.png; *.jpg) | *.png; *.jpg";

            // Si el archivo esta bien
            if (abrirImagen.ShowDialog() == DialogResult.OK)
            {
                // Cargamos la imagen a nuestro PictureBox
                pictureBox_Modificar.Image = Image.FromFile(abrirImagen.FileName);

                // Guardamos el nombre del archivo
                NombreModificar = Path.GetFileName(abrirImagen.FileName);
            }
        }

        // Boton para cargar la imagen
        private void button_CargarImagenSubir_Click(object sender, EventArgs e)
        {
            // Abrimos el explorador de archivos
            OpenFileDialog abrirImagen = new OpenFileDialog();

            // Filtro para el tipo de archivo aceptado
            abrirImagen.Filter = "Archivos de imagenes (*.png; *.jpg) | *.png; *.jpg";

            // Si el archivo esta bien
            if (abrirImagen.ShowDialog() == DialogResult.OK)
            {
                // Cargamos la imagen a nuestro PictureBox
                pictureBox_Subir.Image = Image.FromFile(abrirImagen.FileName);

                // Guardamos el nombre del archivo
                NombreSubir = Path.GetFileName(abrirImagen.FileName);
            }
        }

        // Boton para "refrescar" la base de datos y mostrarla en el 
        private void button_MostrarInventario_Click(object sender, EventArgs e)
        {
            // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
            MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
            // Abrimos nuestra base de datos
            conexion.Open();

            // Linea de comando de SQL
            string consulta = "SELECT * from juegos";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);

            // Creamos nuestra tabla
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView_Inventario.DataSource = dt;

            // Cerremos nuestra base de datos
            conexion.Close();
        }

        // Boton para eliminar un producto
        private void button_EliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {

                // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
                MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
                // Abrimos nuestra base de datos
                conexion.Open();

                // Linea de comando de SQL
                string consulta = "DELETE FROM juegos WHERE ID='" + Convert.ToInt32(textBox_IDBorrar.Text) + "'";
                // Cargamos nuestro comando
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // Ejecutamos el comando
                comando.ExecuteNonQuery();

                MessageBox.Show("Producto eliminado correctamente");

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }

            // Vaciamos el textBox
            textBox_IDBorrar.Text = "";

        }

        // Boton para guardar el nuevo producto
        private void button_Subir_Click(object sender, EventArgs e)
        {
            try
            {

                // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
                MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
                // Abrimos nuestra base de datos
                conexion.Open();

                // Linea de comando de SQL
                string consulta = "INSERT INTO juegos (ID, Nombre, Imagen, Genero, Plataforma, Modalidad, Precio, Stock) VALUES ("
                    + "'" + textBox_IDSubir.Text + "',"
                    + "'" + textBox_NombreSubir.Text + "',"
                    + "'" + NombreSubir + "',"
                    + "'" + textBox_GeneroSubir.Text + "',"
                    + "'" + textBox_PlataformaSubir.Text + "',"
                    + "'" + textBox_ModalidadSubir.Text + "',"
                    + "'" + textBox_PrecioSubir.Text + "',"
                    + "'" + textBox_StockSubir.Text + "')";

                // Cargamos neestra linea de comandos
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // Ejecutamos el comando
                comando.ExecuteNonQuery();

                MessageBox.Show("Producto agregado correctamente");

                // Cerramos nuestra conexion
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }

            // Volvemos a vaciar nuestros TextBox
            textBox_IDSubir.Text = "";
            textBox_NombreSubir.Text = "";
            textBox_GeneroSubir.Text = "";
            textBox_PlataformaSubir.Text = "";
            textBox_ModalidadSubir.Text = "";
            textBox_PrecioSubir.Text = "";
            textBox_StockSubir.Text = "";

            // Quitamos la imagen de nuestro pictureBox
            pictureBox_Subir.Image = null;
        }

        // Boton para modificar los datos
        private void button_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
                MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
                // Abrimos nuestra base de datos
                conexion.Open();

                string consulta = "UPDATE juegos SET ID=" + "'" + textBox_IDModificar.Text + "'" +
                    ",Nombre=" + "'" + textBox_NombreModificar.Text + "'" +
                    ",Imagen=" + "'" + NombreModificar + "'" +
                    ",Genero=" + "'" + textBox_PrecioModificar.Text + "'" +
                    ",Plataforma=" + "'" + textBox_PlataformaModificar.Text + "'" +
                    ",Modalidad=" + "'" + textBox_ModalidadModificar.Text + "'" +
                    ",Precio=" + "'" + textBox_PrecioModificar.Text + "'" +
                    ",Stock=" + "'" + textBox_StockModificar.Text + "'" +
                    "WHERE ID =" + textBox_IDModificar.Text;

                // Cargamos neestra linea de comandos
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // Ejecutamos el comando
                comando.ExecuteNonQuery();

                MessageBox.Show("Producto actualizado correctamente");

                // Cerramos nuestra conexion
                conexion.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la actualizacion: " + ex.Message);
            }

            // Volvemos a vaciar nuestros TextBox
            textBox_IDModificar.Text = "";
            textBox_NombreModificar.Text = "";
            textBox_GeneroModificar.Text = "";
            textBox_PlataformaModificar.Text = "";
            textBox_ModalidadModificar.Text = "";
            textBox_PrecioModificar.Text = "";
            textBox_StockModificar.Text = "";

            // Quitamos la imagen de nuestro pictureBox
            pictureBox_Modificar.Image = null;

        }

    }
}
