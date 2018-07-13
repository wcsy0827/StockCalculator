using Calculator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        //======


        //======
        double _totalcost = 0;
        double _bepoint = 0;
        double _totalprofit = 0;
        double _ROI = 0;
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //計算手續費
            fees=double.Parse( this.txtBuyPrice.Text)*1000*double.Parse(this.txtBuyAmount.Text) * 0.001425;


            double buyprice = double.Parse(this.txtBuyPrice.Text) * 1000;

            _totalcost = buyprice * double.Parse(txtBuyAmount.Text) + fees;
            this.txtTotalCost.Text = (buyprice * double.Parse(txtBuyAmount.Text) + fees).ToString("C0");
            _bepoint = (double.Parse(this.txtBuyPrice.Text) * (1 - 0.001425) / (1 - 0.001425 - 0.003));
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

        //計算獲利
        private void button1_Click(object sender, EventArgs e)
        {

             fees = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.001425;
            tax = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.003;

            double buyprice = double.Parse(this.txtBuyPrice.Text) * 1000;
            double sellprice = double.Parse(this.txtSellPrice.Text) * 1000;

            _totalprofit = ((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees));
            _ROI = (((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)) / (buyprice * double.Parse(txtBuyAmount.Text) + fees));

            this.txtTotalProfit.Text = ((sellprice * double.Parse(txtBuyAmount.Text) - fees-tax)- (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("C0");
            this.txtRR.Text=( ((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees))/ (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("P");


        }

        private void btnButHisroty_Click(object sender, EventArgs e)
        {
            DBTransactionEntities dc = new DBTransactionEntities();
            dataGridView1.DataSource = dc.Buyhistory.ToArray();
            dataGridView1.Columns["totalcost"].DefaultCellStyle.Format = "c0";
        }


        //連線方法input買進資料
        private void btnBuyInput_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = Settings.Default.DBTransactionConnectionString;
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "Insert into  Buyhistory(buyprice,buyamount,totalcost,BEpoint,stockid,date) values (@price, @amount,@cost,@BEpoint,@id,@date)";
                        command.Connection = conn;

                        //=============================

                        //==============================
                        command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(this.textBox2.Text);
                        command.Parameters.Add("@price", SqlDbType.Decimal,6).Value =decimal.Parse( this.txtBuyPrice.Text);
                        command.Parameters.Add("@amount", SqlDbType.Decimal,6).Value = decimal.Parse(this.txtBuyAmount.Text) ;
                        command.Parameters.Add("@cost", SqlDbType.Int).Value = _totalcost;
                        command.Parameters.Add("@BEpoint", SqlDbType.Decimal, 6).Value =_bepoint;
                        command.Parameters.Add("@date", SqlDbType.SmallDateTime, 6).Value = this.dateTimePicker1.Value.ToShortDateString();


                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert member successfully");

                    } //auto command.Dispose()
                }//auto conn.Close(); conn.Dispose()

                //重新整理datagridview
                DBTransactionEntities dc = new DBTransactionEntities(); 
                
                dataGridView1.DataSource = dc.Buyhistory.ToArray();
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["totalcost"].DefaultCellStyle.Format = "c0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                        command.CommandText = "Insert into  Sellhistory(Sellprice,Sellamount,totalprofit,ROI,stockid,date) values (@price, @amount,@profit,@ROI,@id,@date)";
                        command.Connection = conn;

                        //=============================
                        //==============================
                        command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(this.textBox3.Text);
                        command.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtSellPrice.Text);
                        command.Parameters.Add("@amount", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtSellAmount.Text);
                        command.Parameters.Add("@profit", SqlDbType.Int).Value = _totalprofit;
                        command.Parameters.Add("@ROI", SqlDbType.Decimal, 6).Value = _ROI;
                        command.Parameters.Add("@date", SqlDbType.SmallDateTime, 6).Value = this.dateTimePicker2.Value.ToShortDateString();

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert sell information successfully");

                    } //auto command.Dispose()
                }//auto conn.Close(); conn.Dispose()

                //重新整理datagridview
                DBTransactionEntities dc = new DBTransactionEntities();

                dataGridView1.DataSource = dc.Sellhistory.ToArray();
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["totalprofit"].DefaultCellStyle.Format = "c0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSellHistory_Click(object sender, EventArgs e)
        {
            DBTransactionEntities dc = new DBTransactionEntities();
            dataGridView1.DataSource = dc.Sellhistory.ToArray();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["totalprofit"].DefaultCellStyle.Format = "c0";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
    }
}
