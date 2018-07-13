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
    public partial class FrmBuy : Form
    {
        public FrmBuy()
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
                { _fees = value; }
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
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
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8))
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
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8))
                e.Handled = true;
        }
        //==================
        double _totalcost = 0;
        double _bepoint = 0;
        double _ER = 0;
        double _buyprice = 0;
        double _buyamount = 0;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //計算手續費
            fees = double.Parse(this.txtBuyPrice.Text) * 1000 * double.Parse(this.txtBuyAmount.Text) * 0.001425;
            
            _buyprice = double.Parse(this.txtBuyPrice.Text)* 1000;
            _buyamount = double.Parse(this.txtBuyAmount.Text);
            _totalcost = _buyprice *_buyamount + fees;
            _bepoint = _buyprice * (1 - 0.001425) / (1 - 0.001425 - 0.003);
            _ER = double.Parse(txtER.Text);

            this.txtTotalCost.Text = (_buyprice * _buyamount + fees).ToString("C0");

            this.txtBEPoint.Text = (_buyprice * (1 - 0.001425) / (1 - 0.001425 - 0.003)/1000).ToString("C");

            this.txtTP.Text = (_totalcost * (1 + _ER) / (_buyamount * (1 - 0.001425 - 0.003))/1000).ToString("C");

            this.txtEProfit.Text = (_totalcost * _ER).ToString("C0");
        }



    }

}
