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
        public FrmMain()
        {
            InitializeComponent();
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
            FrmBuy w = new FrmBuy();
            w.Show();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            FrmSell w = new FrmSell();
            w.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //=====庫存狀況=====
            DBTransactionEntities dc = new DBTransactionEntities();
            var query = dc.Transaction_history.AsParallel().GroupBy(c => c.stockid).Select(od => new
            {
                股號 = od.Key,
                庫存 = od.Sum(s => s.amount),
                平均成本 = od.Where(bs => bs.buysell == true).Sum(c => c.netincome * (-1)) / od.Where(bs => bs.buysell == true).Sum(a => a.amount)/1000
               
                
            });
           // var query = dc.Transaction_history.Select(c=>c).ToString();


            this.dataGridView1.DataSource = query.ToArray();
            dataGridView1.Columns["平均成本"].DefaultCellStyle.Format = "c2";



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
            this.dataGridView2.Columns["標題"].Width =300;
            this.dataGridView2.Columns["發布時間"].Width = 200;



        }
    }
}
