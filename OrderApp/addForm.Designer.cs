namespace OrderApp
{
    partial class AddForm
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
            this.groupLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.additionsGroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.additionsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.addDishButton = new System.Windows.Forms.Button();
            this.additionsGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupLabel.Location = new System.Drawing.Point(12, 9);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(41, 13);
            this.groupLabel.TabIndex = 0;
            this.groupLabel.Text = "label1";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 34);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "label1";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 58);
            this.descriptionLabel.MaximumSize = new System.Drawing.Size(100, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(35, 13);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "label1";
            // 
            // additionsGroupBox
            // 
            this.additionsGroupBox.Controls.Add(this.panel1);
            this.additionsGroupBox.Location = new System.Drawing.Point(151, 9);
            this.additionsGroupBox.Name = "additionsGroupBox";
            this.additionsGroupBox.Size = new System.Drawing.Size(221, 159);
            this.additionsGroupBox.TabIndex = 4;
            this.additionsGroupBox.TabStop = false;
            this.additionsGroupBox.Text = "Dodatki";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.additionsTableLayout);
            this.panel1.Location = new System.Drawing.Point(6, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 142);
            this.panel1.TabIndex = 0;
            // 
            // additionsTableLayout
            // 
            this.additionsTableLayout.ColumnCount = 2;
            this.additionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.54054F));
            this.additionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.45946F));
            this.additionsTableLayout.Location = new System.Drawing.Point(3, 0);
            this.additionsTableLayout.Name = "additionsTableLayout";
            this.additionsTableLayout.RowCount = 1;
            this.additionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.additionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.additionsTableLayout.Size = new System.Drawing.Size(203, 142);
            this.additionsTableLayout.TabIndex = 0;
            // 
            // addDishButton
            // 
            this.addDishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addDishButton.Location = new System.Drawing.Point(237, 207);
            this.addDishButton.Name = "addDishButton";
            this.addDishButton.Size = new System.Drawing.Size(135, 23);
            this.addDishButton.TabIndex = 5;
            this.addDishButton.Text = "Dodaj";
            this.addDishButton.UseVisualStyleBackColor = true;
            this.addDishButton.Click += new System.EventHandler(this.addDishButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.addDishButton);
            this.Controls.Add(this.additionsGroupBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.groupLabel);
            this.Name = "AddForm";
            this.Text = "Dodaj danie";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.additionsGroupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.GroupBox additionsGroupBox;
        private System.Windows.Forms.Button addDishButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel additionsTableLayout;
    }
}