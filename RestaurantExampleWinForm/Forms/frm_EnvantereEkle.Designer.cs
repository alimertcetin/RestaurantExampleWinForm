
namespace RestaurantExampleWinForm.Forms
{
    partial class frm_EnvantereEkle
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
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_ItemTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ItemPrice = new System.Windows.Forms.TextBox();
            this.btn_Ekle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nup_Count = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ItemName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Count)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "ItemType";
            // 
            // cmb_ItemTypes
            // 
            this.cmb_ItemTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ItemTypes.FormattingEnabled = true;
            this.cmb_ItemTypes.Location = new System.Drawing.Point(12, 116);
            this.cmb_ItemTypes.Name = "cmb_ItemTypes";
            this.cmb_ItemTypes.Size = new System.Drawing.Size(174, 21);
            this.cmb_ItemTypes.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "ItemPrice";
            // 
            // txt_ItemPrice
            // 
            this.txt_ItemPrice.Location = new System.Drawing.Point(12, 68);
            this.txt_ItemPrice.Name = "txt_ItemPrice";
            this.txt_ItemPrice.Size = new System.Drawing.Size(174, 20);
            this.txt_ItemPrice.TabIndex = 14;
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.Location = new System.Drawing.Point(57, 226);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_Ekle.TabIndex = 13;
            this.btn_Ekle.Text = "Ekle";
            this.btn_Ekle.UseVisualStyleBackColor = true;
            this.btn_Ekle.Click += new System.EventHandler(this.btn_Ekle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Count";
            // 
            // nup_Count
            // 
            this.nup_Count.Location = new System.Drawing.Point(12, 182);
            this.nup_Count.Name = "nup_Count";
            this.nup_Count.Size = new System.Drawing.Size(120, 20);
            this.nup_Count.TabIndex = 11;
            this.nup_Count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "itemName";
            // 
            // txt_ItemName
            // 
            this.txt_ItemName.Location = new System.Drawing.Point(12, 29);
            this.txt_ItemName.Name = "txt_ItemName";
            this.txt_ItemName.Size = new System.Drawing.Size(174, 20);
            this.txt_ItemName.TabIndex = 9;
            // 
            // frm_EnvantereEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 266);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_ItemTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ItemPrice);
            this.Controls.Add(this.btn_Ekle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nup_Count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ItemName);
            this.Name = "frm_EnvantereEkle";
            this.Text = "frm_EnvantereEkle";
            ((System.ComponentModel.ISupportInitialize)(this.nup_Count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_ItemTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ItemPrice;
        private System.Windows.Forms.Button btn_Ekle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nup_Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ItemName;
    }
}