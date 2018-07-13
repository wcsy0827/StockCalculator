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
    public partial class FrmSell : Form
    {
        public FrmSell()
        {
            InitializeComponent();
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
        double _totalprofit = 0;
        double _ROI = 0;

        


        private void button1_Click(object sender, EventArgs e)
        {
            int stockid = int.Parse(this.txtstockid2.Text);
            DBTransactionEntities dc = new DBTransactionEntities();
            int[] arrtotalcost = dc.Buyhistory.Select(c => c.totalcost).Where(s => s == stockid).ToArray();
            decimal[] arramont = dc.Buyhistory.Select(c => c.buyamount).Where(s => s == stockid).ToArray();
            decimal sumcost = (decimal)arrtotalcost.Sum();
            decimal sumamount = arrtotalcost.Sum();
            


            fees = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.001425;
            tax = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.003;


            //double sellprice = double.Parse(this.txtSellPrice.Text) * 1000;

            //_totalprofit = ((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees));
            //_ROI = (((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)) / (buyprice * double.Parse(txtBuyAmount.Text) + fees));

            //this.txtTotalProfit.Text = ((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("C0");
            //this.txtRR.Text = (((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)) / (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("P");

        }
    }
}
