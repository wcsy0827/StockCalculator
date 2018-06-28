using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //計算手續費
            double fee = 0;
            fee = double.Parse( this.txtBuyPrice.Text)*double.Parse(this.txtBuyAmount.Text) * 0.001425;
            if(fee<=20)
            { fee = 20; };

            double buyprice = double.Parse(this.txtBuyPrice.Text) * 1000;

            this.txtTotalCost.Text = (buyprice * double.Parse(txtBuyAmount.Text) + fee).ToString("0:N0");

            this.txtBEPoint.Text = (double.Parse(this.txtBuyPrice.Text) * (1 - 0.001425) / (1 - 0.001425 - 0.003)).ToString("C");




        }
    }
}
