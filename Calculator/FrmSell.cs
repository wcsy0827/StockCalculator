using Calculator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        double avgcost = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            int stockid = int.Parse(this.txtstockid2.Text);
            DBTransactionEntities dc = new DBTransactionEntities();
            int[] arrcost = dc.Buyhistory.Where(s => s.stockid == stockid).Select(c => c.totalcost.Value).ToArray();
            //int[] arrtotalcost = dc.Buyhistory.Select(c => c.totalcost).Where(s => s == stockid).ToArray();
            decimal[] arramount = dc.Buyhistory.Where(s => s.stockid == stockid).Select(c => c.buyamount.Value).ToArray();

            decimal sumcost = (decimal)arrcost.Sum();
            decimal sumamount = arramount.Sum();
            decimal _avgcost = sumcost / sumamount/1000;
            avgcost =(double)_avgcost;

            this.label4.Text = sumamount.ToString();
            this.label5.Text = avgcost.ToString("C2");

            this.dataGridView1.DataSource = dc.Buyhistory.Where(s => s.stockid == stockid).ToArray();
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["totalcost"].DefaultCellStyle.Format = "C0";

        }
        double _netincome = 0;
        double _ROI = 0;
        double _sellamount = 0;
        double _sellprice = 0;

        private void button1_Click(object sender, EventArgs e)
        {          

            fees = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.001425;
            tax = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.003;
            _sellamount = double.Parse(txtSellAmount.Text);
            _sellprice = double.Parse(txtSellPrice.Text)*1000;


            double _cost = _sellamount * avgcost*1000;
            double _profit = _sellamount * _sellprice - fees - tax;

            _netincome = (_profit - _cost);
            _ROI = _netincome / _cost;

            this.txtNetIncome.Text = _netincome.ToString("C");
            this.txtRR.Text = _ROI.ToString("P2");
            //this.txtTotalProfit.Text = ((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("C0");
            //this.txtRR.Text = (((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)) / (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("P");

        }

        private void btnSellInput_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = Settings.Default.DBTransactionConnectionString;
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "Insert into  Sellhistory(Sellprice,Sellamount,totalprofit,ROI,stockid,date,Note) values (@price, @amount,@profit,@ROI,@id,@date,@Note)";
                        command.Connection = conn;

                        //=============================

                        //==============================
                        command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(this.txtstockid2.Text);
                        command.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtSellPrice.Text);
                        command.Parameters.Add("@amount", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtSellAmount.Text);
                        command.Parameters.Add("@profit", SqlDbType.Int).Value = (int)_netincome;
                        command.Parameters.Add("@ROI", SqlDbType.Decimal, 6).Value = (decimal)_ROI;
                        command.Parameters.Add("@date", SqlDbType.SmallDateTime, 6).Value = this.dateTimePicker2.Value.ToShortDateString();
                        command.Parameters.Add("@Note", SqlDbType.NVarChar, 6).Value = this.textBox1.Text;

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert data successfully");

                    } //auto command.Dispose()
                }//auto conn.Close(); conn.Dispose()

                //重新整理datagridview
                DBTransactionEntities dc = new DBTransactionEntities();
                dataGridView2.DataSource = dc.Sellhistory.ToArray();
                dataGridView2.Columns["Id"].Visible = false;
                dataGridView2.Columns["totalprofit"].DefaultCellStyle.Format = "c0";
                dataGridView2.Columns["ROI"].DefaultCellStyle.Format = "P2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
