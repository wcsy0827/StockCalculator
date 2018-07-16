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
    public partial class FrmMain : Form
    {
        public FrmMain()
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
            DBTransactionEntities dc = new DBTransactionEntities();
            var query = dc.Transaction_history.GroupBy(c => c.stockid).Select(od => new
            {
                股號 = od.Key,
                庫存=od.Sum(s=>s.amount),
               
                
            });
           // var query = dc.Transaction_history.Select(c=>c).ToString();


            this.dataGridView1.DataSource = query.ToArray();

            
               

            //int stockid = int.Parse(this.txtstockid2.Text);
            //DBTransactionEntities dc = new DBTransactionEntities();
            //int[] arrcost = dc.Buyhistory.Where(s => s.stockid == stockid).Select(c => c.totalcost.Value).ToArray();
            ////int[] arrtotalcost = dc.Buyhistory.Select(c => c.totalcost).Where(s => s == stockid).ToArray();
            //decimal[] arramount = dc.Buyhistory.Where(s => s.stockid == stockid).Select(c => c.buyamount.Value).ToArray();

            //decimal sumcost = (decimal)arrcost.Sum();
            //decimal sumamount = arramount.Sum();
            //decimal _avgcost = sumcost / sumamount / 1000;
            //avgcost = (double)_avgcost;
            
            //dataGridView2.DataSource = dc.Sellhistory.ToArray();
            //dataGridView2.Columns["Id"].Visible = false;
            //dataGridView2.Columns["totalprofit"].DefaultCellStyle.Format = "c0";
            //dataGridView2.Columns["ROI"].DefaultCellStyle.Format = "P2";



        }
    }
}
