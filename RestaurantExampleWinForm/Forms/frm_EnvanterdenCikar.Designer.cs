
namespace RestaurantExampleWinForm.Forms
{
    partial class frm_EnvanterdenCikar
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
            this.btn_Cikar = new System.Windows.Forms.Button();
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
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "ItemType";
            // 
            // cmb_ItemTypes
            // 
            this.cmb_ItemTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ItemTypes.FormattingEnabled = true;
            this.cmb_ItemTypes.Location = new System.Drawing.Point(12, 64);
            this.cmb_ItemTypes.Name = "cmb_ItemTypes";
            this.cmb_ItemTypes.Size = new System.Drawing.Size(174, 21);
            this.cmb_ItemTypes.TabIndex = 25;
            // 
            // btn_Cikar
            // 
            this.btn_Cikar.Location = new System.Drawing.Point(60, 151);
            this.btn_Cikar.Name = "btn_Cikar";
            this.btn_Cikar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cikar.TabIndex = 22;
            this.btn_Cikar.Text = "Çıkar";
            this.btn_Cikar.UseVisualStyleBackColor = true;
            this.btn_Cikar.Click += new System.EventHandler(this.btn_Cikar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Count";
            // 
            // nup_Count
            // 
            this.nup_Count.Location = new System.Drawing.Point(15, 104);
            this.nup_Count.Name = "nup_Count";
            this.nup_Count.Size = new System.Drawing.Size(120, 20);
            this.nup_Count.TabIndex = 20;
            this.nup_Count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "itemName";
            // 
            // txt_ItemName
            // 
            this.txt_ItemName.Location = new System.Drawing.Point(15, 25);
            this.txt_ItemName.Name = "txt_ItemName";
            this.txt_ItemName.Size = new System.Drawing.Size(174, 20);
            this.txt_ItemName.TabIndex = 18;
            // 
            // frm_EnvanterdenCikar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 183);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_ItemTypes);
            this.Controls.Add(this.btn_Cikar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nup_Count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ItemName);
            this.Name = "frm_EnvanterdenCikar";
            this.Text = "frm_EnvanterdenCikar";
            ((System.ComponentModel.ISupportInitialize)(this.nup_Count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_ItemTypes;
        private System.Windows.Forms.Button btn_Cikar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nup_Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ItemName;
    }
}