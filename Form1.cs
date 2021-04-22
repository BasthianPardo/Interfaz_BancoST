using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_BancoST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void controlBotones()
        {
            if (textBox1.Text.Trim() != string.Empty && textBox1.Text.All(Char.IsLetter))
            {
                button1.Enabled = true;
                errorProvider1.SetError(textBox1, "");
            }
            else
            {
                if (!(textBox1.Text.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(textBox1, "El nombre sólo puede contener letras");
                        }
                else
                {
                    errorProvider1.SetError(textBox1, "Debe introducir un nombre");
                }
                button1.Enabled = false;
                textBox1.Focus();
            }
            } 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            controlBotones();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Prestamos ventanaPrestamos = new Prestamos(textBox1.Text))
            ventanaPrestamos.ShowDialog();
        }
    }
}
