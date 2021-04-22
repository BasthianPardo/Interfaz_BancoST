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
    public partial class Prestamos : Form
    {
        string nombre_cliente;
        int[] cuotas_disponibles = { 12, 24, 36 };
        int monto;
        Dictionary<int, double> intereses_base;


        public Prestamos(string nombre)
        {
            InitializeComponent();
            nombre_cliente = nombre;


            intereses_base = new Dictionary<int, double>();
            int i;
            double interes;
            for (i = 0, interes = 0.1; i <cuotas_disponibles.Length; i++,interes += 0.1)
            {
                intereses_base[cuotas_disponibles[i]] = interes;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prestamos_Load(object sender, EventArgs e)
        {
            popularCuotas();
            saludo.Text += nombre_cliente;
        }
        void popularCuotas()
        {
            for (int i = 0; i < cuotas_disponibles.Length; i++)
            {
                comboBox1.Items.Add(cuotas_disponibles[i]);
            }
        }
        double calcularInteres()
        {
            int cuotas_perdidas = (int)comboBox1.SelectedItem;
            double interes = intereses_base[cuotas_perdidas];
           
            return interes;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Double interes_mes = calcularInteres();
            Double monto_solicitado = double.Parse(monto.Text);
            int cuotas_pedidas = (int)comboBox1.SelectedItem;
            double interes_total = monto_solicitado * (interes_mes / 100) * cuotas_pedidas;
            double monto_pagar = monto_solicitado * interes_total;
            string mensaje = "Su prestamo es de " + monto_solicitado + " en un número de " + cuotas_pedidas + " cuotas con un interés del " + interes_mes +
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(mensaje, "calculo de interés", buttons);
        }
        }
    }

