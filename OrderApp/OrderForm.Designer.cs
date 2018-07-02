namespace OrderApp
{
    partial class OrderForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.note = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.orderTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.sendOrder = new System.Windows.Forms.Button();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.historyOrderButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 536);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.menuTableLayout);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 510);
            this.panel1.TabIndex = 0;
            // 
            // menuTableLayout
            // 
            this.menuTableLayout.AutoSize = true;
            this.menuTableLayout.ColumnCount = 3;
            this.menuTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menuTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.menuTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.menuTableLayout.Location = new System.Drawing.Point(3, 4);
            this.menuTableLayout.MaximumSize = new System.Drawing.Size(600, 0);
            this.menuTableLayout.Name = "menuTableLayout";
            this.menuTableLayout.RowCount = 1;
            this.menuTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menuTableLayout.Size = new System.Drawing.Size(550, 0);
            this.menuTableLayout.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.note);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.sendOrder);
            this.groupBox2.Controls.Add(this.emailBox);
            this.groupBox2.Location = new System.Drawing.Point(608, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(492, 536);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zamówienie";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // note
            // 
            this.note.Location = new System.Drawing.Point(131, 490);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(128, 20);
            this.note.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Uwaga do zamówienia:";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.orderTableLayout);
            this.panel2.Location = new System.Drawing.Point(7, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 462);
            this.panel2.TabIndex = 0;
            // 
            // orderTableLayout
            // 
            this.orderTableLayout.AutoSize = true;
            this.orderTableLayout.ColumnCount = 3;
            this.orderTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.orderTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.orderTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.orderTableLayout.Location = new System.Drawing.Point(4, 4);
            this.orderTableLayout.MaximumSize = new System.Drawing.Size(450, 0);
            this.orderTableLayout.Name = "orderTableLayout";
            this.orderTableLayout.RowCount = 1;
            this.orderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.orderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.orderTableLayout.Size = new System.Drawing.Size(450, 0);
            this.orderTableLayout.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email: ";
            // 
            // sendOrder
            // 
            this.sendOrder.Enabled = false;
            this.sendOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sendOrder.Location = new System.Drawing.Point(408, 488);
            this.sendOrder.Name = "sendOrder";
            this.sendOrder.Size = new System.Drawing.Size(78, 23);
            this.sendOrder.TabIndex = 1;
            this.sendOrder.Text = "Zamawiam";
            this.sendOrder.UseVisualStyleBackColor = true;
            this.sendOrder.Click += new System.EventHandler(this.sendOrder_Click);
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(309, 490);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(93, 20);
            this.emailBox.TabIndex = 3;
            // 
            // historyOrderButton
            // 
            this.historyOrderButton.Location = new System.Drawing.Point(900, 555);
            this.historyOrderButton.Name = "historyOrderButton";
            this.historyOrderButton.Size = new System.Drawing.Size(200, 44);
            this.historyOrderButton.TabIndex = 2;
            this.historyOrderButton.Text = "Historia zamówień";
            this.historyOrderButton.UseVisualStyleBackColor = true;
            this.historyOrderButton.Click += new System.EventHandler(this.historyOrderButton_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 611);
            this.Controls.Add(this.historyOrderButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrderForm";
            this.Text = "OrderFormcs";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel menuTableLayout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendOrder;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TableLayoutPanel orderTableLayout;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button historyOrderButton;
    }
}