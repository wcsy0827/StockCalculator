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
        internal FrmMain f1 = null;
        public FrmBuy()
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

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
            var querybuy = dc.Buyhistory.AsParallel().Select(od => new
            {
                日期 = od.date,
                股號 = od.stockid,
                買進價格 = od.buyprice,
                買進數量 = od.buyamount,
                買進總成本 = od.totalcost,
                損平價格 = od.BEpoint,
                預期報酬 = od.ERate,
                目標價 = od.TP,
                筆記 = od.Note
            });
            dataGridView1.DataSource =querybuy.ToArray();
            //dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["買進總成本"].DefaultCellStyle.Format = "c0";
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            dataGridView1.Columns["買進總成本"].Width = 120;
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
            if (txtBuyPrice.Text != "" && txtBuyAmount.Text != "" && txtStockID.Text != "" && txtER.Text != "")
            {
                //計算手續費
                fees = double.Parse(this.txtBuyPrice.Text) * 1000 * double.Parse(this.txtBuyAmount.Text) * 0.001425;

                _buyprice = double.Parse(this.txtBuyPrice.Text) * 1000;
                _buyamount = double.Parse(this.txtBuyAmount.Text);
                _totalcost = _buyprice * _buyamount + fees;
                _bepoint = _buyprice * (1 - 0.001425) / (1 - 0.001425 - 0.003) / 1000;
                _ER = double.Parse(txtER.Text) / 100;
                _tp = (_totalcost * (1 + _ER) / (_buyamount * (1 - 0.001425 - 0.003)) / 1000);

                this.txtTotalCost.Text = _totalcost.ToString("C0");

                this.txtBEPoint.Text = _bepoint.ToString("C");

                this.txtTP.Text = _tp.ToString("C");

                this.txtEProfit.Text = (_totalcost * _ER).ToString("C0");

            }
            else
            {
                MessageBox.Show("請確認填入資料無誤!"); 
            }
           
        }

        private void btnBuyInput_Click(object sender, EventArgs e)
        {
            if (txtBEPoint.Text != "")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = Settings.Default.DBTransactionConnectionString;
                        using (SqlCommand command = new SqlCommand())
                        {
                            //===========輸入買進表========================
                            command.CommandText = "Insert into  Buyhistory(buyprice,buyamount,totalcost,BEpoint,ERate,TP,stockid,date,Note) values (@price, @amount,@cost,@BEpoint,@ERate,@TP,@id,@date,@Note)";
                            command.Connection = conn;

                            //==============================
                            command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(this.txtStockID.Text);
                            command.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtBuyPrice.Text);
                            //command.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = (decimal) _buyprice;
                            command.Parameters.Add("@amount", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtBuyAmount.Text);
                            //command.Parameters.Add("@amount", SqlDbType.Decimal, 6).Value = (decimal)_buyamount;
                            command.Parameters.Add("@cost", SqlDbType.Int).Value = _totalcost;
                            //command.Parameters.Add("@cost", SqlDbType.Int).Value = (decimal)_totalcost;
                            command.Parameters.Add("@BEpoint", SqlDbType.Decimal, 6).Value = (decimal)_bepoint;
                            command.Parameters.Add("@ERate", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtER.Text) / 100;
                            command.Parameters.Add("@TP", SqlDbType.Decimal, 6).Value = (decimal)_tp;
                            command.Parameters.Add("@date", SqlDbType.SmallDateTime, 6).Value = this.dateTimePicker1.Value.ToShortDateString();
                            command.Parameters.Add("@Note", SqlDbType.NVarChar, 6).Value = this.textBox1.Text;

                            conn.Open();
                            command.ExecuteNonQuery();
                            //===========輸入總表========================

                            command.CommandText = "Insert into  [Transaction history](stockid,buysell,price,amount,netincome,date) values (@id2, @buysell,@price2,@amount2,@netincome,@date2)";

                            //==============================
                            command.Parameters.Add("@id2", SqlDbType.Int).Value = int.Parse(this.txtStockID.Text);
                            command.Parameters.Add("@buysell", SqlDbType.Bit).Value = 1;
                            command.Parameters.Add("@price2", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtBuyPrice.Text);
                            command.Parameters.Add("@amount2", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtBuyAmount.Text);
                            command.Parameters.Add("@netincome", SqlDbType.Int).Value = _totalcost * (-1);
                            command.Parameters.Add("@date2", SqlDbType.SmallDateTime, 6).Value = this.dateTimePicker1.Value.ToShortDateString();

                            command.ExecuteNonQuery();

                            MessageBox.Show("Insert data successfully");

                        } //auto command.Dispose()
                    }//auto conn.Close(); conn.Dispose()

                    //重新整理datagridview
                    DBTransactionEntities dc = new DBTransactionEntities();
                    var querybuy = dc.Buyhistory.AsParallel().Select(od => new
                    {
                        日期 = od.date,
                        股號 = od.stockid,
                        買進價格 = od.buyprice,
                        買進數量 = od.buyamount,
                        買進總成本 = od.totalcost,
                        損平價格 = od.BEpoint,
                        預期報酬 = od.ERate,
                        目標價 = od.TP,
                        筆記 = od.Note
                    });


                    dataGridView1.DataSource = querybuy.ToArray();
                    //dataGridView1.Columns["Id"].Visible = false;
                    dataGridView1.Columns["買進總成本"].DefaultCellStyle.Format = "c0";
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
                    dataGridView1.Columns["買進總成本"].Width = 120;




                    //更新frmmain庫存狀況

                    var query = dc.Transaction_history.GroupBy(c => c.stockid).Select(od => new
                    {
                        股號 = od.Key,
                        庫存 = od.Sum(s => s.amount),
                        平均成本 = od.Where(bs => bs.buysell == true).Sum(c => c.netincome * (-1)) / od.Where(bs => bs.buysell == true).Sum(a => a.amount) / 1000

                    });




                    f1.dataGridView1.DataSource = query.ToArray();
                    f1.dataGridView1.Columns["平均成本"].DefaultCellStyle.Format = "c2";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("請先計算成本及預期報酬!");
            }


        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //視窗關閉僅隱藏，重複開啟不NG
        private void FrmBuy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason==CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide();
            }
        }
    }

}
