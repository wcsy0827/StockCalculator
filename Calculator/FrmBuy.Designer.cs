namespace Calculator
{
    partial class FrmBuy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtStockID = new System.Windows.Forms.TextBox();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.txtBuyAmount = new System.Windows.Forms.TextBox();
            this.txtTex = new System.Windows.Forms.TextBox();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.txtBEPoint = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnBuyInput = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtER = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEProfit = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(726, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 64;
            this.checkBox1.Text = "視窗置頂";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtStockID
            // 
            this.txtStockID.Location = new System.Drawing.Point(149, 16);
            this.txtStockID.Name = "txtStockID";
            this.txtStockID.Size = new System.Drawing.Size(106, 22);
            this.txtStockID.TabIndex = 48;
            this.txtStockID.Text = "1590";
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Location = new System.Drawing.Point(149, 66);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(106, 22);
            this.txtBuyPrice.TabIndex = 50;
            this.txtBuyPrice.Text = "350";
            // 
            // txtBuyAmount
            // 
            this.txtBuyAmount.Location = new System.Drawing.Point(149, 126);
            this.txtBuyAmount.Name = "txtBuyAmount";
            this.txtBuyAmount.Size = new System.Drawing.Size(106, 22);
            this.txtBuyAmount.TabIndex = 52;
            this.txtBuyAmount.Text = "3";
            // 
            // txtTex
            // 
            this.txtTex.Location = new System.Drawing.Point(395, 19);
            this.txtTex.Name = "txtTex";
            this.txtTex.ReadOnly = true;
            this.txtTex.Size = new System.Drawing.Size(106, 22);
            this.txtTex.TabIndex = 54;
            this.txtTex.Text = "千分之1.425";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(149, 299);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(106, 22);
            this.txtTotalCost.TabIndex = 55;
            // 
            // txtBEPoint
            // 
            this.txtBEPoint.Location = new System.Drawing.Point(149, 244);
            this.txtBEPoint.Name = "txtBEPoint";
            this.txtBEPoint.ReadOnly = true;
            this.txtBEPoint.Size = new System.Drawing.Size(106, 22);
            this.txtBEPoint.TabIndex = 56;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(393, 121);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(108, 22);
            this.dateTimePicker1.TabIndex = 57;
            this.dateTimePicker1.Value = new System.DateTime(2018, 7, 13, 0, 0, 0, 0);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(273, 459);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(106, 41);
            this.btnCalculate.TabIndex = 58;
            this.btnCalculate.Text = "計算";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnBuyInput
            // 
            this.btnBuyInput.Location = new System.Drawing.Point(412, 459);
            this.btnBuyInput.Name = "btnBuyInput";
            this.btnBuyInput.Size = new System.Drawing.Size(106, 41);
            this.btnBuyInput.TabIndex = 60;
            this.btnBuyInput.Text = "存入買進資訊";
            this.btnBuyInput.UseVisualStyleBackColor = true;
            this.btnBuyInput.Click += new System.EventHandler(this.btnBuyInput_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(327, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 19);
            this.label18.TabIndex = 63;
            this.label18.Text = "日期:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(79, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 19);
            this.label16.TabIndex = 62;
            this.label16.Text = "股號:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(535, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 19);
            this.label11.TabIndex = 61;
            this.label11.Text = "買進";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(41, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 59;
            this.label5.Text = "損平價格:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(22, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 53;
            this.label4.Text = "買進總成本:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(269, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "券商手續費:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(79, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "張數:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(79, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 47;
            this.label1.Text = "價格:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(22, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 65;
            this.label6.Text = "預期報酬率:";
            // 
            // txtER
            // 
            this.txtER.Location = new System.Drawing.Point(149, 189);
            this.txtER.Name = "txtER";
            this.txtER.Size = new System.Drawing.Size(106, 22);
            this.txtER.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(41, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 19);
            this.label7.TabIndex = 67;
            this.label7.Text = "預期報酬:";
            // 
            // txtEProfit
            // 
            this.txtEProfit.Location = new System.Drawing.Point(149, 404);
            this.txtEProfit.Name = "txtEProfit";
            this.txtEProfit.ReadOnly = true;
            this.txtEProfit.Size = new System.Drawing.Size(106, 22);
            this.txtEProfit.TabIndex = 68;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(395, 71);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(106, 22);
            this.textBox7.TabIndex = 69;
            this.textBox7.Text = "千分之3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(270, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 19);
            this.label13.TabIndex = 70;
            this.label13.Text = "政府證交稅:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(274, 224);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(244, 229);
            this.textBox1.TabIndex = 71;
            // 
            // txtTP
            // 
            this.txtTP.Location = new System.Drawing.Point(149, 352);
            this.txtTP.Name = "txtTP";
            this.txtTP.ReadOnly = true;
            this.txtTP.Size = new System.Drawing.Size(106, 22);
            this.txtTP.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(41, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 19);
            this.label8.TabIndex = 73;
            this.label8.Text = "目標價格:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(270, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 74;
            this.label9.Text = "Note:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1213, 556);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 75;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.txtTP);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.textBox7);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label13);
            this.splitContainer2.Panel1.Controls.Add(this.label16);
            this.splitContainer2.Panel1.Controls.Add(this.txtEProfit);
            this.splitContainer2.Panel1.Controls.Add(this.label18);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.btnBuyInput);
            this.splitContainer2.Panel1.Controls.Add(this.txtER);
            this.splitContainer2.Panel1.Controls.Add(this.btnCalculate);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer2.Panel1.Controls.Add(this.txtStockID);
            this.splitContainer2.Panel1.Controls.Add(this.txtBEPoint);
            this.splitContainer2.Panel1.Controls.Add(this.txtBuyPrice);
            this.splitContainer2.Panel1.Controls.Add(this.txtTotalCost);
            this.splitContainer2.Panel1.Controls.Add(this.txtBuyAmount);
            this.splitContainer2.Panel1.Controls.Add(this.txtTex);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(1213, 512);
            this.splitContainer2.SplitterDistance = 534;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(675, 512);
            this.dataGridView1.TabIndex = 0;
            // 
            // FrmBuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 556);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmBuy";
            this.Text = "FrmBuy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtStockID;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.TextBox txtBuyAmount;
        private System.Windows.Forms.TextBox txtTex;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.TextBox txtBEPoint;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnBuyInput;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtER;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEProfit;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtTP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}