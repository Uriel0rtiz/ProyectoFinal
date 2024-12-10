using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalV1
{
    public partial class FormBarras : Form
    {
        public FormBarras()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormCódigoBarras_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int maxAncho = 18;
            int minAncho = 1;

            StringBuilder sb = new StringBuilder();
            List<int> anchos = new List<int>();

            // Asignar anchos aleatorios a cada panel y almacenarlos en la lista
            Codigo1.Width = random.Next(minAncho, maxAncho + 1);
            Codigo1.BackColor = Color.Black;
            anchos.Add(Codigo1.Width);

            Codigo2.Width = random.Next(minAncho, maxAncho + 1);
            Codigo2.BackColor = Color.Black;
            anchos.Add(Codigo2.Width);

            Codigo3.Width = random.Next(minAncho, maxAncho + 1);
            Codigo3.BackColor = Color.Black;
            anchos.Add(Codigo3.Width);

            Codigo4.Width = random.Next(minAncho, maxAncho + 1);
            Codigo4.BackColor = Color.Black;
            anchos.Add(Codigo4.Width);

            Codigo5.Width = random.Next(minAncho, maxAncho + 1);
            Codigo5.BackColor = Color.Black;
            anchos.Add(Codigo5.Width);

            Codigo6.Width = random.Next(minAncho, maxAncho + 1);
            Codigo6.BackColor = Color.Black;
            anchos.Add(Codigo6.Width);

            Codigo7.Width = random.Next(minAncho, maxAncho + 1);
            Codigo7.BackColor = Color.Black;
            anchos.Add(Codigo7.Width);

            Codigo8.Width = random.Next(minAncho, maxAncho + 1);
            Codigo8.BackColor = Color.Black;
            anchos.Add(Codigo8.Width);

            Codigo9.Width = random.Next(minAncho, maxAncho + 1);
            Codigo9.BackColor = Color.Black;
            anchos.Add(Codigo9.Width);

            Codigo10.Width = random.Next(minAncho, maxAncho + 1);
            Codigo10.BackColor = Color.Black;
            anchos.Add(Codigo10.Width);

            Codigo11.Width = random.Next(minAncho, maxAncho + 1);
            Codigo11.BackColor = Color.Black;
            anchos.Add(Codigo11.Width);

            Codigo12.Width = random.Next(minAncho, maxAncho + 1);
            Codigo12.BackColor = Color.Black;
            anchos.Add(Codigo12.Width);

            Codigo13.Width = random.Next(minAncho, maxAncho + 1);
            Codigo13.BackColor = Color.Black;
            anchos.Add(Codigo13.Width);

            Codigo14.Width = random.Next(minAncho, maxAncho + 1);
            Codigo14.BackColor = Color.Black;
            anchos.Add(Codigo14.Width);

            Codigo15.Width = random.Next(minAncho, maxAncho + 1);
            Codigo15.BackColor = Color.Black;
            anchos.Add(Codigo15.Width);

            Codigo16.Width = random.Next(minAncho, maxAncho + 1);
            Codigo16.BackColor = Color.Black;
            anchos.Add(Codigo16.Width);

            Codigo17.Width = random.Next(minAncho, maxAncho + 1);
            Codigo17.BackColor = Color.Black;
            anchos.Add(Codigo17.Width);

            Codigo18.Width = random.Next(minAncho, maxAncho + 1);
            Codigo18.BackColor = Color.Black;
            anchos.Add(Codigo18.Width);

            Codigo19.Width = random.Next(minAncho, maxAncho + 1);
            Codigo19.BackColor = Color.Black;
            anchos.Add(Codigo19.Width);

            Codigo20.Width = random.Next(minAncho, maxAncho + 1);
            Codigo20.BackColor = Color.Black;
            anchos.Add(Codigo20.Width);

            // Configurar números bajo cada barra para representar el código
            for (int i = 0; i < anchos.Count; i++) // Recorrer cada ancho en la lista
            {
                int numero;
                if (anchos[i] > 7) // Barras más anchas representan 1
                {
                    numero = 1;
                }
                else // Espacios más estrechos representan 0
                {
                    numero = 0;
                }

                sb.Append(numero.ToString());
            }

            TextCodigo.Text = sb.ToString();
            RichTextCondiciones.Text = $"Por favor, presente el número '{sb.ToString()}' o escanee el código de barras en su OXXO más cercano.";
        }


        private void Codigo1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Codigo2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codigo20_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar la aplicación
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimizar la ventana
        }

        private void FormBarras_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            ReleaseCapture();
        }


    }
}
