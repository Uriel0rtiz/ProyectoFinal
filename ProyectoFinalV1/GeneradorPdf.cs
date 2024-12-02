using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ProyectoFinalV1
{
    public class GeneradorPdf{

        private int folio;//Declaramos un folio para la compra
        public int Folio { get; set; }//Propiedad para el folio

        public GeneradorPdf(){
        }

        // Constructor por parametros (recibe el folio de la compra)
        public GeneradorPdf(int folio)
        {
            this.Folio = folio;//Asignamos el folio recibido a la propiedad
        }
        public void GenerarPDF()
        {
            
            FileStream fs = new FileStream(Ruta(Folio), FileMode.Create);//Creamos un archivo PDF en la ruta especificada
            Document doc = new Document(PageSize.LETTER, 2, 2, 2, 2);//Creamos un documento PDF
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs);//Creamos un escritor de PDF

            // Abrimos el documento
            doc.Open();

            // Agregamos un titulo al documento
            doc.AddTitle("Ticket de Compra");

            // Agregamos contenido al documento
            doc.Add(new Paragraph("Este es el contenido del ticket de compra."));

            // Cerramos el documento
            doc.Close();
            pdfWriter.Close();//Cerramos el escritor de PDF

            MessageBox.Show("Ticket generado con exito.");
        }

        //Declaramos un comportamiento en la clase con el cual podremos acceder a ruta de tickets en cualquier equipo que tenga el proyecto.
        public static string Ruta(int Folio)
        {
            // Se obtiene el directorio base de la aplicación en tiempo de ejecución
            string rutaBaseDirectorio = AppDomain.CurrentDomain.BaseDirectory;

            // Subimos varios niveles en el directorio para llegar a la carpeta del proyecto
            string rutaProyecto = Path.GetFullPath(Path.Combine(rutaBaseDirectorio, @"..\..\.."));

            // Combinamos el directorio del proyecto con la carpeta "Tickets" para formar la ruta completa
            string rutaTickets = Path.Combine(rutaProyecto, "Tickets");

            // Generar el nombre del archivo PDF usando el folio
            string nombreArchivo = $"Ticket_{Folio}.pdf";

            // Devuelve la ruta completa del archivo PDF
            return Path.Combine(rutaTickets, nombreArchivo);
        }



    }

}
