using MySql.Data.MySqlClient; // Para poder usar nuestra base de datos
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
    public partial class FormProductos : Form
    {
        // Creamos nuestra lista de tipo Juegos, la cual nos servira para mostrar los juegos
        List<Juegos> lista = new List<Juegos>();

        // Creamos otra lista donde se va a guardar el carrito de compras
        List<Juegos> carrito = new List<Juegos>();

        // Variable para almacenar al usuario que ingreso
        Persona usuario;

        // Variable para almacenar si el usuario llego a comprar
        int monto_usuario = 0;

        public FormProductos()
        {
            InitializeComponent();
        }

        // Constructor por parametros (recibe el nombre de la persona que ingreso)
        public FormProductos(Persona usuario_constructor)
        {
            // Llamamos la funcion importante
            InitializeComponent();
            // Guardamos al usuario
            usuario = usuario_constructor;
            // Ponemos le nombre recibido en nuestro textBox
            textBox_Nombre.Text = usuario.Nombre;
            // Al iniciar el form, cargamos los juegos
            Cargar_Juegos();
            // Al iniciar el form, no tenemos nada en el carrito
            textBox_ConteoCarrito.Text = 0.ToString();
            // Guardamos el monto actual del usuario
            monto_usuario = usuario.Monto;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void button_LogOut_Click(object sender, EventArgs e)
        {

            // Verificamos si hay productos en el carrito
            if (carrito.Count() != 0)
            {
                MessageBox.Show("No es posible salirse sin antes vaciar el carrito");
            }
            else
            {
                this.Dispose();
            }

        }

        private void FormProductos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            ReleaseCapture();
        }

        // Funcion para ir al form de nuestro carrito
        private void button_Carrito_Click(object sender, EventArgs e)
        {
            // Creamos nuestro form para el carrito
            FormCarrito formCarrito = new FormCarrito(carrito, lista, usuario);

            // Ocultamos el form actual
            this.Hide();

            // Mostramos el nuevo form (usando ShowDialog)
            formCarrito.ShowDialog();

            // Verificamos si al regresar del carrito, el usuario realizo una compra o no
            // En caso de que el usuario si haya realizado una compra, entonces cerramos ya este form
            if (usuario.Monto != monto_usuario)
            {
                this.Dispose();
            }
            // En caso contrario, mostramos todo como estaba
            else
            {

                // Volvemos a mostrar este form
                this.Show();

                // Limpiamos nuevamente nuestra lista
                lista.Clear();

                // Cargamos todos los juegos que tenemos
                Cargar_Juegos();

                // Mostramos nuevamente la cantidad de productos que tenemos en nuestro carrito
                textBox_ConteoCarrito.Text = carrito.Count.ToString();
            }



        }

        // Funcion para mostrar nuestros juegos
        private void Cargar_Juegos()
        {
            try
            {
                // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
                MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
                // Abrimos nuestra base de datos
                conexion.Open();

                // Linea de comando de SQL
                string consulta = "SELECT * FROM juegos";
                // Cargamos nuestro comando
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // Ejecutamos el comando
                MySqlDataReader lector = comando.ExecuteReader();

                // Mientras haya algo que leer
                while (lector.Read())
                {
                    // Creamos las variables que vamos a usar
                    int id;
                    string nombre;
                    string imagen;
                    string genero;
                    string plataforma;
                    string modalidad;
                    int precio;
                    int stock;

                    // Asignamos los valores recuperados a nuestras variables
                    id = int.Parse(lector["ID"].ToString());
                    nombre = lector["Nombre"].ToString();
                    imagen = lector["Imagen"].ToString();
                    genero = lector["Genero"].ToString();
                    plataforma = lector["Plataforma"].ToString();
                    modalidad = lector["Modalidad"].ToString();
                    // Convertimos el valor recuperado a string, para despues pasarlo a entero
                    precio = int.Parse(lector["Precio"].ToString());
                    stock = int.Parse(lector["Stock"].ToString());

                    // Creamos el objeto de nuestra clase
                    Juegos temp = new Juegos(id, nombre, imagen, genero, plataforma, modalidad, precio, stock);

                    // Agregamos este objeto a nuestra lista
                    lista.Add(temp);
                }

                // Verificamos si hay al menos 6 juegos
                if (lista.Count < 6)
                {
                    MessageBox.Show("Debe haber al menos 6 juegos disponibles");
                    // Cerramos por completo la aplicacion, ya que no se puede iniciar
                    Application.Exit();
                }

                if (lista.Count < 7)
                {
                    this.Size = new Size(1500, 330);
                }
                else if (lista.Count >= 7)
                {
                    this.Size = new Size(1500, 702);
                }

                // Limitamos la lista a un maximo de 10 juegos, asi el administrador puede agregar mas juegos en la base de datos sin problemas
                if (lista.Count > 10)
                {
                    //Tomamos los primeros 10 elementos de la lista
                    lista = lista.Take(10).ToList();
                }

                // Recorremos nuestra lista
                for (int i = 0; i < lista.Count; i++)
                {
                    // Asignamos los valores a los controles correspondientes
                    AsignarValoresJuego(i, lista[i]);
                }

                // Ocultamos los controles de los juegos que no existen
                for (int i = lista.Count; i < 10; i++)
                {
                    OcultarJuego(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message);
            }
        }

        // Metodo para asignar los valores de un juego a los controles correspondientes
        private void AsignarValoresJuego(int indice, Juegos juego)
        {
            // Asignamos los valores a los controles correspondientes segun el indice del juego
            switch (indice)
            {
                case 0:
                    // Asignamos los valores del primer juego a los controles correspondientes
                    TituloJuego1.Text = juego.Nombre;
                    ModalidadJuego1.Text = juego.Modalidad;
                    GeneroJuego1.Text = juego.Genero;
                    PlataformaJuego1.Text = juego.Plataforma;
                    StockJuego1.Text = $"Stock: {juego.Stock}";
                    PrecioJuego1.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego1, juego.Imagen);
                    break;
                case 1:
                    // Asignamos los valores del segundo juego a los controles correspondientes
                    TituloJuego2.Text = juego.Nombre;
                    ModalidadJuego2.Text = juego.Modalidad;
                    GeneroJuego2.Text = juego.Genero;
                    PlataformaJuego2.Text = juego.Plataforma;
                    StockJuego2.Text = $"Stock: {juego.Stock}";
                    PrecioJuego2.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego2, juego.Imagen);
                    break;
                case 2:
                    // Asignamos los valores del tercer juego a los controles correspondientes
                    TituloJuego3.Text = juego.Nombre;
                    ModalidadJuego3.Text = juego.Modalidad;
                    GeneroJuego3.Text = juego.Genero;
                    PlataformaJuego3.Text = juego.Plataforma;
                    StockJuego3.Text = $"Stock: {juego.Stock}";
                    PrecioJuego3.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego3, juego.Imagen);
                    break;
                case 3:
                    // Asignamos los valores del cuarto juego a los controles correspondientes
                    TituloJuego4.Text = juego.Nombre;
                    ModalidadJuego4.Text = juego.Modalidad;
                    GeneroJuego4.Text = juego.Genero;
                    PlataformaJuego4.Text = juego.Plataforma;
                    StockJuego4.Text = $"Stock: {juego.Stock}";
                    PrecioJuego4.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego4, juego.Imagen);
                    break;
                case 4:
                    // Asignamos los valores del quinto juego a los controles correspondientes
                    TituloJuego5.Text = juego.Nombre;
                    ModalidadJuego5.Text = juego.Modalidad;
                    GeneroJuego5.Text = juego.Genero;
                    PlataformaJuego5.Text = juego.Plataforma;
                    StockJuego5.Text = $"Stock: {juego.Stock}";
                    PrecioJuego5.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego5, juego.Imagen);
                    break;
                case 5:
                    // Asignamos los valores del sexto juego a los controles correspondientes
                    TituloJuego6.Text = juego.Nombre;
                    ModalidadJuego6.Text = juego.Modalidad;
                    GeneroJuego6.Text = juego.Genero;
                    PlataformaJuego6.Text = juego.Plataforma;
                    StockJuego6.Text = $"Stock: {juego.Stock}";
                    PrecioJuego6.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego6, juego.Imagen);
                    break;
                case 6:
                    // Asignamos los valores del septimo juego a los controles correspondientes
                    TituloJuego7.Text = juego.Nombre;
                    ModalidadJuego7.Text = juego.Modalidad;
                    GeneroJuego7.Text = juego.Genero;
                    PlataformaJuego7.Text = juego.Plataforma;
                    StockJuego7.Text = $"Stock: {juego.Stock}";
                    PrecioJuego7.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego7, juego.Imagen);
                    break;
                case 7:
                    // Asignamos los valores del octavo juego a los controles correspondientes
                    TituloJuego8.Text = juego.Nombre;
                    ModalidadJuego8.Text = juego.Modalidad;
                    GeneroJuego8.Text = juego.Genero;
                    PlataformaJuego8.Text = juego.Plataforma;
                    StockJuego8.Text = $"Stock: {juego.Stock}";
                    PrecioJuego8.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego8, juego.Imagen);
                    break;
                case 8:
                    // Asignamos los valores del noveno juego a los controles correspondientes
                    TituloJuego9.Text = juego.Nombre;
                    ModalidadJuego9.Text = juego.Modalidad;
                    GeneroJuego9.Text = juego.Genero;
                    PlataformaJuego9.Text = juego.Plataforma;
                    StockJuego9.Text = $"Stock: {juego.Stock}";
                    PrecioJuego9.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego9, juego.Imagen);
                    break;
                case 9:
                    // Asignamos los valores del decimo juego a los controles correspondientes
                    TituloJuego10.Text = juego.Nombre;
                    ModalidadJuego10.Text = juego.Modalidad;
                    GeneroJuego10.Text = juego.Genero;
                    PlataformaJuego10.Text = juego.Plataforma;
                    StockJuego10.Text = $"Stock: {juego.Stock}";
                    PrecioJuego10.Text = $"${juego.Precio}";
                    CargarImagen(ImagenJuego10, juego.Imagen);
                    break;
            }
        }

        // Metodo para ocultar los controles de un juego
        private void OcultarJuego(int indice)
        {
            switch (indice)
            {
                case 6:
                    buttonComprarJuego7.Visible = false;
                    panel11.Visible = false;
                    TituloJuego7.Visible = false;
                    ModalidadJuego7.Visible = false;
                    GeneroJuego7.Visible = false;
                    PlataformaJuego7.Visible = false;
                    StockJuego7.Visible = false;
                    PrecioJuego7.Visible = false;
                    ImagenJuego7.Visible = false;
                    break;
                case 7:
                    buttonComprarJuego8.Visible = false;
                    panel12.Visible = false;
                    TituloJuego8.Visible = false;
                    ModalidadJuego8.Visible = false;
                    GeneroJuego8.Visible = false;
                    PlataformaJuego8.Visible = false;
                    StockJuego8.Visible = false;
                    PrecioJuego8.Visible = false;
                    ImagenJuego8.Visible = false;
                    break;
                case 8:
                    buttonComprarJuego9.Visible = false;
                    panel13.Visible = false;
                    TituloJuego9.Visible = false;
                    ModalidadJuego9.Visible = false;
                    GeneroJuego9.Visible = false;
                    PlataformaJuego9.Visible = false;
                    StockJuego9.Visible = false;
                    PrecioJuego9.Visible = false;
                    ImagenJuego9.Visible = false;
                    break;
                case 9:
                    buttonComprarJuego10.Visible = false;
                    panel14.Visible = false;
                    TituloJuego10.Visible = false;
                    ModalidadJuego10.Visible = false;
                    GeneroJuego10.Visible = false;
                    PlataformaJuego10.Visible = false;
                    StockJuego10.Visible = false;
                    PrecioJuego10.Visible = false;
                    ImagenJuego10.Visible = false;
                    break;
            }
        }

        // Metodo para cargar una imagen a un pictureBox
        private void CargarImagen(PictureBox pictureBox, string nombreImagen)
        {
            // Construimos la ruta hacia la carpeta donde estan las imagenes de los juegos
            string rutaImagenes = System.IO.Path.Combine(Application.StartupPath, "Juegos");

            // Construimos la ruta completa donde se encuentra nuestra imagen a buscar
            string rutaCompleta = System.IO.Path.Combine(rutaImagenes, nombreImagen);

            // Si hay un archivo con esta direccion en especifico
            if (System.IO.File.Exists(rutaCompleta))
            {
                // Cargamos la imagen a nuestro picture box
                pictureBox.Image = Image.FromFile(rutaCompleta);
            }
            else
            {
                // En caso de que la imagen no exista, entonces mostramos mensaje de error
                MessageBox.Show("No se encontro la imagen deseada");

                // Si habia una imagen en el pictureBox, la quitamos
                pictureBox.Image = null;
            }
        }

        // Evento para el boton de comprar el primer juego
        private void buttonComprarJuego1_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 0
            AgregarJuegoAlCarrito(0);
        }

        // Evento para el boton de comprar el segundo juego
        private void buttonComprarJuego2_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 1
            AgregarJuegoAlCarrito(1);
        }

        // Evento para el boton de comprar el tercer juego
        private void buttonComprarJuego3_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 2
            AgregarJuegoAlCarrito(2);
        }

        // Evento para el boton de comprar el cuarto juego
        private void buttonComprarJuego4_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 3
            AgregarJuegoAlCarrito(3);
        }

        // Evento para el boton de comprar el quinto juego
        private void buttonComprarJuego5_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 4
            AgregarJuegoAlCarrito(4);
        }

        // Evento para el boton de comprar el sexto juego
        private void buttonComprarJuego6_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 5
            AgregarJuegoAlCarrito(5);
        }

        // Evento para el boton de comprar el septimo juego
        private void buttonComprarJuego7_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 6
            AgregarJuegoAlCarrito(6);
        }

        // Evento para el boton de comprar el octavo juego
        private void buttonComprarJuego8_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 7
            AgregarJuegoAlCarrito(7);
        }

        // Evento para el boton de comprar el noveno juego
        private void buttonComprarJuego9_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 8
            AgregarJuegoAlCarrito(8);
        }

        // Evento para el boton de comprar el decimo juego
        private void buttonComprarJuego10_Click(object sender, EventArgs e)
        {
            // Llama al metodo para agregar el juego al carrito, pasando el indice 9
            AgregarJuegoAlCarrito(9);
        }

        // Metodo para agregar un juego al carrito
        private void AgregarJuegoAlCarrito(int indice)
        {
            // Verificamos si hay stock disponible 
            if (lista[indice].Stock > 0)
            {
                // Agregamos este objeto a nuestro carrito
                carrito.Add(lista[indice]);

                // Mensaje de exito
                MessageBox.Show($"{lista[indice].Nombre} fue agregado correctamente al carrito");

                // Mostramos el valor del contador
                textBox_ConteoCarrito.Text = carrito.Count.ToString();

                // Quitamos uno de nuestro stock
                lista[indice].Stock--;

                // Mostramos el nuevo valor del stock
                switch (indice)
                {
                    case 0:
                        StockJuego1.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 1:
                        StockJuego2.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 2:
                        StockJuego3.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 3:
                        StockJuego4.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 4:
                        StockJuego5.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 5:
                        StockJuego6.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 6:
                        StockJuego7.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 7:
                        StockJuego8.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 8:
                        StockJuego9.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                    case 9:
                        StockJuego10.Text = $"Stock: {lista[indice].Stock.ToString()}";
                        break;
                }

                // Actualizamos nuestra base de datos
                try
                {
                    // Creamos nuestra variable para la base de datos, y pasamos nuestra informacion
                    MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; User=root; Password=; Sslmode=none;");
                    // Abrimos nuestra base de datos
                    conexion.Open();

                    // Linea de comando de SQL
                    string consulta = "UPDATE juegos SET " +
                        "ID=@Id, Nombre=@Nombre, Imagen=@Imagen, Genero=@Genero, Plataforma=@Plataforma, Modalidad=@Modalidad, Precio=@Precio, Stock=@Stock " +
                        "WHERE ID=@Id";

                    // Cargamos nuestra linea de comandos
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Id", lista[indice].Id);
                    comando.Parameters.AddWithValue("@Nombre", lista[indice].Nombre);
                    comando.Parameters.AddWithValue("@Imagen", lista[indice].Imagen);
                    comando.Parameters.AddWithValue("@Genero", lista[indice].Genero);
                    comando.Parameters.AddWithValue("@Plataforma", lista[indice].Plataforma);
                    comando.Parameters.AddWithValue("@Modalidad", lista[indice].Modalidad);
                    comando.Parameters.AddWithValue("@Precio", lista[indice].Precio);
                    comando.Parameters.AddWithValue("@Stock", lista[indice].Stock);

                    // Ejecutamos el comando
                    comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la actualizacion del registro: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show($"No hay stock disponible del juego {lista[indice].Nombre}");
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncerrar_Click_1(object sender, EventArgs e)
        {
            if (carrito.Count() != 0)
            {
                MessageBox.Show("No es posible salirse sin antes vaciar el carrito");
            }
            else
            {
                Application.Exit();
            }
        }

        private void ImagenJuego8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }
    }
}