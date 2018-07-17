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
    public partial class FrmAllTable : Form
    {
        internal FrmMain f1 = null;
        public FrmAllTable()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void FrmAllTable_Load(object sender, EventArgs e)
        {
            DBTransactionEntities dc = new DBTransactionEntities();
            var queryTransaction = dc.Transaction_history.AsParallel().Select(od => new
            {
                日期=od.date,
                股號 = od.stockid,
                庫存 = od.amount,
                買賣 = od.buysell,
                價格 = od.price,
                數量=od.amount,
                損益=od.netincome,

            }).OrderBy(d=>d.日期);
            this.dataGridView1.DataSource = queryTransaction.ToArray();
            dataGridView1.Columns["價格"].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns["價格"].Width = 150;
            dataGridView1.Columns["損益"].DefaultCellStyle.Format = "c0";
            dataGridView1.Columns["損益"].Width = 150;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);

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
            }).OrderBy(d=>d.日期);


            dataGridView2.DataSource = querybuy.ToArray();
            //dataGridView1.Columns["Id"].Visible = false;
            dataGridView2.Columns["買進總成本"].DefaultCellStyle.Format = "c0";
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 12, FontStyle.Bold);
            dataGridView2.Columns["買進總成本"].Width = 120;
            dataGridView2.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);

            var querysell = dc.Sellhistory.AsParallel().Select(od => new
            {
                日期 = od.date,
                股號 = od.stockid,
                賣出價格 = od.Sellprice,
                賣出數量 = od.Sellamount,
                獲利 = od.totalprofit,
                報酬率 = od.ROI,
                筆記 = od.Note
            }).OrderBy(d=>d.日期);
            dataGridView3.DataSource = querysell.ToArray();
            dataGridView3.Columns["獲利"].DefaultCellStyle.Format = "c0";
            dataGridView3.Columns["報酬率"].DefaultCellStyle.Format = "P2";
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 12, FontStyle.Bold);
            dataGridView3.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);

        }

        private void FrmAllTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide();
            }
        }
    }
}
