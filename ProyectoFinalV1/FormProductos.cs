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
        //Declaramos un folio para la compra
        private int folio=1;
        public int Folio { get; set; } //Propiedad para el folio

        // Constructor vacio
        public FormProductos()
        {
            InitializeComponent();
        }



        // Constructor por parametros (recibe el nombre de la persona que ingreso)
        public FormProductos(string nombre)
        {
            // Llamamos la funcion importante
            InitializeComponent();
            // Ponemos le nombre recibido en nuestro textBox
            textBox_Nombre.Text = nombre;
        }

        public FormProductos(int folio)
        {
            this.Folio = folio;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

    }
}
