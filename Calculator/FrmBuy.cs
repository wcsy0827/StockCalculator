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
            DBTransactionEntities dc = new DBTransactionEntities();
            dataGridView1.DataSource = dc.Buyhistory.ToArray();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["totalcost"].DefaultCellStyle.Format = "c0";
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
        double _tp = 0;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //計算手續費
            fees = double.Parse(this.txtBuyPrice.Text) * 1000 * double.Parse(this.txtBuyAmount.Text) * 0.001425;
            
            _buyprice = double.Parse(this.txtBuyPrice.Text)* 1000;
            _buyamount = double.Parse(this.txtBuyAmount.Text);
            _totalcost = _buyprice *_buyamount + fees;
            _bepoint = _buyprice * (1 - 0.001425) / (1 - 0.001425 - 0.003)/1000;
            _ER = double.Parse(txtER.Text);
            _tp = (_totalcost * (1 + _ER) / (_buyamount * (1 - 0.001425 - 0.003)) / 1000);

            this.txtTotalCost.Text =_totalcost.ToString("C0");

            this.txtBEPoint.Text = _bepoint.ToString("C");

            this.txtTP.Text = _tp.ToString("C");

            this.txtEProfit.Text = (_totalcost * _ER).ToString("C0");
        }

        private void btnBuyInput_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = Settings.Default.DBTransactionConnectionString;
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "Insert into  Buyhistory(buyprice,buyamount,totalcost,BEpoint,ERate,TP,stockid,date,Note) values (@price, @amount,@cost,@BEpoint,@ERate,@TP,@id,@date,@Note)";
                        command.Connection = conn;

                        //=============================

                        //==============================
                        command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(this.txtStockID.Text);
                        command.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtBuyPrice.Text);
                        //command.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = (decimal) _buyprice;
                        command.Parameters.Add("@amount", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtBuyAmount.Text);
                        //command.Parameters.Add("@amount", SqlDbType.Decimal, 6).Value = (decimal)_buyamount;
                        command.Parameters.Add("@cost", SqlDbType.Int).Value = _totalcost;
                        //command.Parameters.Add("@cost", SqlDbType.Int).Value = (decimal)_totalcost;
                        command.Parameters.Add("@BEpoint", SqlDbType.Decimal, 6).Value =(decimal)_bepoint;
                        command.Parameters.Add("@ERate", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtER.Text);
                        command.Parameters.Add("@TP", SqlDbType.Decimal, 6).Value =(decimal)_tp;
                        command.Parameters.Add("@date", SqlDbType.SmallDateTime, 6).Value = this.dateTimePicker1.Value.ToShortDateString();
                        command.Parameters.Add("@Note", SqlDbType.NVarChar, 6).Value = this.textBox1.Text;

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert data successfully");

                    } //auto command.Dispose()
                }//auto conn.Close(); conn.Dispose()

                //重新整理datagridview
                DBTransactionEntities dc = new DBTransactionEntities();
                dataGridView1.DataSource = dc.Buyhistory.ToArray();
                //dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["totalcost"].DefaultCellStyle.Format = "c0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
