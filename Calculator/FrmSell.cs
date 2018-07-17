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
        internal FrmMain f1 = null;
        public FrmSell()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
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
        #region 費用屬性

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
        #endregion

        double avgcost = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            int stockid = int.Parse(this.txtstockid2.Text);
            DBTransactionEntities dc = new DBTransactionEntities();
            decimal instock =0 ;
                instock=dc.Transaction_history.AsParallel().Where(s => s.stockid == stockid).Sum(a => a.amount).Value;
            if(instock!=0)
            {
            this.labelInstock.Text= dc.Transaction_history.AsParallel().Where(s => s.stockid == stockid).Sum(a => a.amount).ToString();
           
                decimal temp= (dc.Transaction_history.Where(s => s.stockid == stockid && s.buysell == true).Sum(c => c.netincome) / dc.Transaction_history.Where(s => s.stockid == stockid && s.buysell == true).Sum(c => c.amount) / -1000).Value;
            this.labelavgcost.Text =temp.ToString("c2");
            avgcost =double.Parse( (dc.Transaction_history.Where(s => s.stockid == stockid && s.buysell == true).Sum(c => c.netincome) / dc.Transaction_history.Where(s => s.stockid == stockid && s.buysell == true).Sum(c => c.amount)/-1000).ToString() );

            //=====歷史買進表=====
            var querybuy = dc.Buyhistory.AsParallel().Where(s=>s.stockid==stockid).Select(od => new
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
                        this.dataGridView1.DataSource =querybuy.ToArray();
            dataGridView1.Columns["買進總成本"].DefaultCellStyle.Format = "c0";
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Regular);
            dataGridView1.Columns["買進總成本"].Width = 120;
            }
            //無庫存，顯示庫存個股
            else
            {
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
                this.dataGridView1.DataSource = querybuy.ToArray();
                dataGridView1.Columns["買進總成本"].DefaultCellStyle.Format = "c0";
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Regular);
                dataGridView1.Columns["買進總成本"].Width = 120;
                MessageBox.Show("目前無庫存資訊");
            }
            


        }
        double _netincome = 0;
        double _ROI = 0;
        double _sellamount = 0;
        double _sellprice = 0;
        double _cost = 0;
        double _profit = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (labelInstock.Text != "")
            {
                fees = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.001425;
                tax = double.Parse(this.txtSellPrice.Text) * 1000 * double.Parse(this.txtSellAmount.Text) * 0.003;
                _sellamount = double.Parse(txtSellAmount.Text);
                _sellprice = double.Parse(txtSellPrice.Text) * 1000;



                _profit = _sellamount * _sellprice - fees - tax;
                _cost = _sellamount * avgcost * 1000;
                _netincome = (_profit - _cost);
                _ROI = _netincome / _cost;

                this.txtNetIncome.Text = _netincome.ToString("C");
                this.txtRR.Text = _ROI.ToString("P2");
                //this.txtTotalProfit.Text = ((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("C0");
                //this.txtRR.Text = (((sellprice * double.Parse(txtBuyAmount.Text) - fees - tax) - (buyprice * double.Parse(txtBuyAmount.Text) + fees)) / (buyprice * double.Parse(txtBuyAmount.Text) + fees)).ToString("P");
            }
            else
            { MessageBox.Show("請先查詢該股庫存及成本!"); }
        }

        private void btnSellInput_Click(object sender, EventArgs e)
        {
            if (this.txtNetIncome.Text != "")
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
                            //===================================

                            command.CommandText = "Insert into  [Transaction history](stockid,buysell,price,amount,netincome,date) values (@id2, @buysell,@price2,@amount2,@netincome,@date2)";

                            //==============================
                            command.Parameters.Add("@id2", SqlDbType.Int).Value = int.Parse(this.txtstockid2.Text);
                            command.Parameters.Add("@buysell", SqlDbType.Bit).Value = 0;
                            command.Parameters.Add("@price2", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtSellPrice.Text);
                            command.Parameters.Add("@amount2", SqlDbType.Decimal, 6).Value = decimal.Parse(this.txtSellAmount.Text) * (-1);
                            command.Parameters.Add("@netincome", SqlDbType.Int).Value = _profit;
                            command.Parameters.Add("@date2", SqlDbType.SmallDateTime, 6).Value = this.dateTimePicker2.Value.ToShortDateString();
                            //conn.Open();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Insert data successfully");


                        } //auto command.Dispose()
                    }//auto conn.Close(); conn.Dispose()

                    //重新整理datagridview
                    DBTransactionEntities dc = new DBTransactionEntities();
                    var querysell = dc.Sellhistory.AsParallel().Select(od => new
                    {
                        日期 = od.date,
                        股號 = od.stockid,
                        賣出價格 = od.Sellprice,
                        賣出數量 = od.Sellamount,
                        獲利 = od.totalprofit,
                        報酬率 = od.ROI,
                        筆記 = od.Note
                    });
                    dataGridView2.DataSource = querysell.ToArray();
                    dataGridView2.Columns["獲利"].DefaultCellStyle.Format = "c0";
                    dataGridView2.Columns["報酬率"].DefaultCellStyle.Format = "P2";
                    dataGridView2.Columns["獲利"].DefaultCellStyle.Format = "c0";
                    dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Regular);
                    dataGridView2.Columns["獲利"].Width = 120;


                    //更新frmmain庫存狀況

                    var query =dc.Transaction_history.GroupBy(c => c.stockid).Select(od => new
                    {
                        股號 = od.Key,
                        庫存 = od.Sum(s => s.amount),
                        平均每股成本 = od.Where(bs => bs.buysell == true).Sum(c => c.netincome * (-1)) / od.Where(bs => bs.buysell == true).Sum(a => a.amount) / 1000,
                        總成本 = od.Where(bs => bs.buysell == true).Sum(c => c.netincome * (-1))

                    });

                    f1.dataGridView1.DataSource = query.ToArray();
                    f1.dataGridView1.Columns["平均每股成本"].DefaultCellStyle.Format = "c2";
                    f1.dataGridView1.Columns["平均每股成本"].Width = 150;
                    f1.dataGridView1.Columns["總成本"].DefaultCellStyle.Format = "c0";
                    f1.dataGridView1.Columns["總成本"].Width = 150;
                    f1.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 12, FontStyle.Regular);
                    f1.dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            { MessageBox.Show("請先查詢庫存及成本，並計算報酬!"); }
                    
        }

        private void FrmSell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide();
            }
        }
    }
}
