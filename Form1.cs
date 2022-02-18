using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Navegador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Guardar(string fileName, string texto)
        {
            
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);  
            writer.Close();
        }
        private void Leer (string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
           
            {
                comboBox1.Items.Add(reader.ReadLine());
            }
            reader.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
            Leer("Historial.txt");

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uri = "";
            uri = comboBox1.Text.ToString();
            if (comboBox1.SelectedIndex.Equals(-1))
            {
                
                if (uri.Contains(".") == true)
                {
                    uri = "http://" + uri;
                    webBrowser1.Navigate(uri);
                }
                else if (uri.Contains(".") == false)
                {
                    uri = "http://www.google.com/search?q=" + uri;
                    webBrowser1.Navigate(uri);
                }
            }
            else
            {
                webBrowser1.Navigate(uri);
            }
            int Listo = 0;
            for (int i = 0; i< comboBox1.Items.Count;i++)
                    {
                if (uri == comboBox1.Items[i].ToString())
                    Listo++;
            }

            comboBox1.Items.Add(uri);
            Guardar("Historial.txt", uri);
        }

        private void inicioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void haciaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
