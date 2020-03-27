using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private double a1;
        private double a2;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            txtSonuc1.Clear();
            txtSonuc2.Clear();
            txtSonuc3.Clear();
            txtSonuc4.Clear();

            if (txta1.Text != "")
             {
                double a1 = Convert.ToDouble(txta1.Text);
             }
                if (txta2.Text != "")
             {
                double a2 = Convert.ToDouble(txta2.Text);
             }
                if ((String.IsNullOrEmpty(txta1.Text)) && (String.IsNullOrEmpty(txta2.Text)))
             {
                 MessageBox.Show("BİR SAYI GİRİNİZ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }

            if (rbPoisson.Checked)
            {
                if (String.IsNullOrEmpty(txtLambda.Text))
                {
                    MessageBox.Show("LAMBDA DEĞERİ GİRİN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                { 
                double lambda = Convert.ToDouble(txtLambda.Text);
                double numerator = 0;
                double p;

                double Factorial(double k)
                {
                    double count = k;
                    double factorial = 1;
                    while (count >= 1)
                    {
                        factorial = factorial * count;
                        count--;
                    }
                    return factorial;
                }

                p = 0;
                for (double k = a1; k <= a2; k++)
                {
                    double kFactorial = Factorial(k);
                    numerator = Math.Pow(Math.E, -(double)lambda) * Math.Pow((double)lambda, (double)k);
                    p = p + (double)numerator / kFactorial;
                }
                txtSonuc1.Text = p.ToString();

                p = 0;

                // X<=a2; yani a2 ve a2 den küçüklerin toplamı. (0 a kadar)
                for (double k = 0; k <= a2; k++)
                {
                    double kFactorial = Factorial(k);
                    numerator = Math.Pow(Math.E, -(double)lambda) * Math.Pow((double)lambda, (double)k);
                    p = p + (double)numerator / kFactorial;
                }
                txtSonuc2.Text = p.ToString();
                p = 0;

                // a1<=X yani 1-a1 den küçük olanlar
                for (double k = 0.0; k < a1; k++)
                {

                    double kFactorial = Factorial(k);
                    numerator = Math.Pow(Math.E, -(double)lambda) * Math.Pow((double)lambda, (double)k);
                    p = p + (double)numerator / kFactorial;
                    p = 1 - p;
                }
                txtSonuc3.Text = p.ToString();
                    
                }
            }
        }
    }
}
