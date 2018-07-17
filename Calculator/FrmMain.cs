using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Calculator
{
    public partial class FrmMain : Form
    {
        delegate void ThreadsSynchronization();
        FrmBuy f2 = new FrmBuy();
        FrmSell f3 = new FrmSell();
        FrmAllTable f4 = new FrmAllTable();
        public FrmMain()
        {
            InitializeComponent();
            f2.f1 = this;
            f3.f1 = this;
            f4.f1 = this;
            this.StartPosition = FormStartPosition.CenterScreen;
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
        private void btnBuy_Click(object sender, EventArgs e)
        {
            
            f2.Show();
        }

        private void btnSell_Click(object sender, EventArgs e)
        { 
            f3.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //=====庫存狀況=====
            DBTransactionEntities dc = new DBTransactionEntities();
            var query = dc.Transaction_history.AsParallel().GroupBy(c => c.stockid).Select(od => new
            {
                股號 = od.Key,
                庫存= od.Sum(s => s.amount),
                平均每股成本 = od.Where(bs => bs.buysell == true).Sum(c => c.netincome * (-1)) / od.Where(bs => bs.buysell == true).Sum(a => a.amount)/1000,
                總成本 = od.Where(bs => bs.buysell == true).Sum(c => c.netincome * (-1))



            });
           // var query = dc.Transaction_history.Select(c=>c).ToString();


            this.dataGridView1.DataSource = query.ToArray();
            dataGridView1.Columns["平均每股成本"].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns["平均每股成本"].Width = 150;
            dataGridView1.Columns["總成本"].DefaultCellStyle.Format = "c0";
            dataGridView1.Columns["總成本"].Width = 150;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font= new Font("Times New Roman", 12, FontStyle.Regular);




            //=====RSS Reader=====
            XDocument rssFeed = XDocument.Load("https://tw.stock.yahoo.com/rss/url/d/e/N1.html");
            var queryrss = from item in rssFeed.Descendants("item").AsParallel()
                           select new
                        {
                            標題 = item.Element("title").Value,
                            發布時間 =  item.Element("pubDate").Value,
                            link = item.Element("link").Value,
                        };
            dataGridView2.DataSource = queryrss.ToList();
            this.dataGridView2.Columns["標題"].Width =350;
            this.dataGridView2.Columns["發布時間"].Width = 200;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 12, FontStyle.Bold);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            f4.Show();
        }
    }
}
