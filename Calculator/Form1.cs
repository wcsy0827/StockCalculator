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

        double _fees = 0;
        private double fees
        {

            get
            {
                
                return _fees;
            }
            set 
            {
                if (value <= 20)
                { _fees = 20; }
                else
                { _fees = value;}
                _fees = Convert.ToInt16(Math.Floor(_fees));
            }
        }

        double _tax = 0;
        private double tax
        {

            get
            {
                return _tax;
            }
            set
            {
                _tax = Convert.ToInt16(Math.Floor(value));

            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //計算手續費
            fees=double.Parse( this.txtBuyPrice.Text)*1000*double.Parse(this.txtBuyAmount.Text) * 0.001425;


            double buyprice = double.Parse(this.txtBuyPrice.Text) * 1000;

            this.txtTotalCost.Text = (buyprice * double.Parse(txtBuyAmount.Text) + fees).ToString("C0");

            this.txtBEPoint.Text = (double.Parse(this.txtBuyPrice.Text) * (1 - 0.001425) / (1 - 0.001425 - 0.003)).ToString("C");




        }

        //限制輸入條件
        private void Form1_Load(object sender, EventArgs e)
        {

            txtBuyPrice.MaxLength = 7;
        }

        //只能數字及一個小數點，允許使用BackSpace
        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9')
                || (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf(e.KeyChar) < 0)
                || e.KeyChar == 8))
                e.Handled = true;

        }
        private void txtBuyAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9')|| e.KeyChar == 8))
                e.Handled = true;

        }
        private void txtSellPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9')
    || (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf(e.KeyChar) < 0)
    || e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtSellAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9')|| e.KeyChar == 8))
            e.Handled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

             fees = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.001425;
            tax = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.003;

            double buyprice = double.Parse(this.txtBuyPrice.Text) * 1000;
            double sellprice = double.Parse(this.txtSellPrice.Text) * 1000;



            this.txtTotalProfit.Text = ((sellprice * double.Parse(txtBuyAmount.Text) - fees-tax)- (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("C0");
            this.txtRR.Text=( ((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees))/ (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("P");


            
            
         
           



        }


    }
}
