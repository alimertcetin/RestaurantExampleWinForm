
namespace RestaurantExampleWinForm.Forms
{
    partial class frm_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.siparişBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flp_ExtraIngredients = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flp_Size = new System.Windows.Forms.FlowLayoutPanel();
            this.ts_MalzemeEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünYönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_MalzemeCikar = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_EnvanterGoruntule = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_MenuOlustur = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_MenuGoruntule = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_TotalPrice = new System.Windows.Forms.Label();
            this.nup_menuAmount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Menu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_SiparisEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstb_OrderList = new System.Windows.Forms.ListBox();
            this.siparisYönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btn_CancelSelected = new System.Windows.Forms.Button();
            this.btn_Checkout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_menuAmount)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // siparişBilgileriToolStripMenuItem
            // 
            this.siparişBilgileriToolStripMenuItem.Name = "siparişBilgileriToolStripMenuItem";
            this.siparişBilgileriToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.siparişBilgileriToolStripMenuItem.Text = "Sipariş Bilgileri";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flp_ExtraIngredients);
            this.groupBox3.Location = new System.Drawing.Point(11, 384);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(344, 109);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extra Malzemeler";
            // 
            // flp_ExtraIngredients
            // 
            this.flp_ExtraIngredients.Location = new System.Drawing.Point(10, 23);
            this.flp_ExtraIngredients.Margin = new System.Windows.Forms.Padding(2);
            this.flp_ExtraIngredients.Name = "flp_ExtraIngredients";
            this.flp_ExtraIngredients.Size = new System.Drawing.Size(321, 71);
            this.flp_ExtraIngredients.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flp_Size);
            this.groupBox1.Location = new System.Drawing.Point(11, 276);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(344, 106);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "YiyecekBoyut Seçin";
            // 
            // flp_Size
            // 
            this.flp_Size.Location = new System.Drawing.Point(10, 23);
            this.flp_Size.Margin = new System.Windows.Forms.Padding(2);
            this.flp_Size.Name = "flp_Size";
            this.flp_Size.Size = new System.Drawing.Size(321, 71);
            this.flp_Size.TabIndex = 26;
            // 
            // ts_MalzemeEkle
            // 
            this.ts_MalzemeEkle.Name = "ts_MalzemeEkle";
            this.ts_MalzemeEkle.Size = new System.Drawing.Size(221, 22);
            this.ts_MalzemeEkle.Text = "Envantere Malzeme Ekle";
            this.ts_MalzemeEkle.Click += new System.EventHandler(this.ts_MalzemeEkle_Click);
            // 
            // ürünYönetimiToolStripMenuItem
            // 
            this.ürünYönetimiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_MalzemeEkle,
            this.ts_MalzemeCikar,
            this.ts_EnvanterGoruntule,
            this.ts_MenuOlustur,
            this.ts_MenuGoruntule});
            this.ürünYönetimiToolStripMenuItem.Name = "ürünYönetimiToolStripMenuItem";
            this.ürünYönetimiToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.ürünYönetimiToolStripMenuItem.Text = "Ürün Yönetimi";
            // 
            // ts_MalzemeCikar
            // 
            this.ts_MalzemeCikar.Name = "ts_MalzemeCikar";
            this.ts_MalzemeCikar.Size = new System.Drawing.Size(221, 22);
            this.ts_MalzemeCikar.Text = "Envanterden Malzeme Çıkar";
            this.ts_MalzemeCikar.Click += new System.EventHandler(this.ts_MalzemeCikar_Click);
            // 
            // ts_EnvanterGoruntule
            // 
            this.ts_EnvanterGoruntule.Name = "ts_EnvanterGoruntule";
            this.ts_EnvanterGoruntule.Size = new System.Drawing.Size(221, 22);
            this.ts_EnvanterGoruntule.Text = "Envanteri Görüntüle";
            this.ts_EnvanterGoruntule.Click += new System.EventHandler(this.ts_EnvanterGoruntule_Click);
            // 
            // ts_MenuOlustur
            // 
            this.ts_MenuOlustur.Name = "ts_MenuOlustur";
            this.ts_MenuOlustur.Size = new System.Drawing.Size(221, 22);
            this.ts_MenuOlustur.Text = "Menu Oluştur";
            this.ts_MenuOlustur.Click += new System.EventHandler(this.ts_MenuOlustur_Click);
            // 
            // ts_MenuGoruntule
            // 
            this.ts_MenuGoruntule.Name = "ts_MenuGoruntule";
            this.ts_MenuGoruntule.Size = new System.Drawing.Size(221, 22);
            this.ts_MenuGoruntule.Text = "Menuleri Görüntüle";
            this.ts_MenuGoruntule.Click += new System.EventHandler(this.ts_MenuGoruntule_Click);
            // 
            // lbl_TotalPrice
            // 
            this.lbl_TotalPrice.AutoSize = true;
            this.lbl_TotalPrice.Location = new System.Drawing.Point(452, 299);
            this.lbl_TotalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TotalPrice.Name = "lbl_TotalPrice";
            this.lbl_TotalPrice.Size = new System.Drawing.Size(13, 13);
            this.lbl_TotalPrice.TabIndex = 50;
            this.lbl_TotalPrice.Text = "0";
            this.lbl_TotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nup_menuAmount
            // 
            this.nup_menuAmount.Location = new System.Drawing.Point(61, 496);
            this.nup_menuAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nup_menuAmount.Name = "nup_menuAmount";
            this.nup_menuAmount.Size = new System.Drawing.Size(295, 20);
            this.nup_menuAmount.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 497);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Adet";
            // 
            // cmb_Menu
            // 
            this.cmb_Menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Menu.FormattingEnabled = true;
            this.cmb_Menu.Items.AddRange(new object[] {
            ""});
            this.cmb_Menu.Location = new System.Drawing.Point(11, 250);
            this.cmb_Menu.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Menu.Name = "cmb_Menu";
            this.cmb_Menu.Size = new System.Drawing.Size(345, 21);
            this.cmb_Menu.TabIndex = 46;
            this.cmb_Menu.SelectedIndexChanged += new System.EventHandler(this.cmb_Menu_SelectedIndexChanged);
            this.cmb_Menu.SizeChanged += new System.EventHandler(this.cmb_Menu_SizeChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 233);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Menü Seçin";
            // 
            // btn_SiparisEkle
            // 
            this.btn_SiparisEkle.Location = new System.Drawing.Point(11, 522);
            this.btn_SiparisEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SiparisEkle.Name = "btn_SiparisEkle";
            this.btn_SiparisEkle.Size = new System.Drawing.Size(344, 31);
            this.btn_SiparisEkle.TabIndex = 44;
            this.btn_SiparisEkle.Text = "Sipariş Ekle";
            this.btn_SiparisEkle.UseVisualStyleBackColor = true;
            this.btn_SiparisEkle.Click += new System.EventHandler(this.btn_SiparisEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 299);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Toplam Tutar :";
            // 
            // lstb_OrderList
            // 
            this.lstb_OrderList.FormattingEnabled = true;
            this.lstb_OrderList.Location = new System.Drawing.Point(375, 27);
            this.lstb_OrderList.Margin = new System.Windows.Forms.Padding(2);
            this.lstb_OrderList.Name = "lstb_OrderList";
            this.lstb_OrderList.Size = new System.Drawing.Size(299, 264);
            this.lstb_OrderList.TabIndex = 42;
            // 
            // siparisYönetimiToolStripMenuItem
            // 
            this.siparisYönetimiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siparişBilgileriToolStripMenuItem});
            this.siparisYönetimiToolStripMenuItem.Name = "siparisYönetimiToolStripMenuItem";
            this.siparisYönetimiToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.siparisYönetimiToolStripMenuItem.Text = "Siparis Yönetimi";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siparisYönetimiToolStripMenuItem,
            this.ürünYönetimiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 51;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btn_CancelSelected
            // 
            this.btn_CancelSelected.BackColor = System.Drawing.Color.Bisque;
            this.btn_CancelSelected.Location = new System.Drawing.Point(375, 327);
            this.btn_CancelSelected.Name = "btn_CancelSelected";
            this.btn_CancelSelected.Size = new System.Drawing.Size(75, 55);
            this.btn_CancelSelected.TabIndex = 54;
            this.btn_CancelSelected.Text = "Cancel Selected";
            this.btn_CancelSelected.UseVisualStyleBackColor = false;
            this.btn_CancelSelected.Click += new System.EventHandler(this.btn_CancelSelected_Click);
            // 
            // btn_Checkout
            // 
            this.btn_Checkout.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Checkout.Location = new System.Drawing.Point(599, 299);
            this.btn_Checkout.Name = "btn_Checkout";
            this.btn_Checkout.Size = new System.Drawing.Size(75, 83);
            this.btn_Checkout.TabIndex = 55;
            this.btn_Checkout.Text = "Checkout";
            this.btn_Checkout.UseVisualStyleBackColor = false;
            this.btn_Checkout.Click += new System.EventHandler(this.btn_Checkout_Click);
            // 
            // frm_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 566);
            this.Controls.Add(this.btn_Checkout);
            this.Controls.Add(this.btn_CancelSelected);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_TotalPrice);
            this.Controls.Add(this.nup_menuAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_Menu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_SiparisEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstb_OrderList);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frm_MainForm";
            this.Text = "frm_MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_MainForm_FormClosed);
            this.Load += new System.EventHandler(this.frm_MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nup_menuAmount)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem siparişBilgileriToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flp_ExtraIngredients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flp_Size;
        private System.Windows.Forms.ToolStripMenuItem ts_MalzemeEkle;
        private System.Windows.Forms.ToolStripMenuItem ürünYönetimiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_MalzemeCikar;
        private System.Windows.Forms.Label lbl_TotalPrice;
        private System.Windows.Forms.NumericUpDown nup_menuAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Menu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_SiparisEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstb_OrderList;
        private System.Windows.Forms.ToolStripMenuItem siparisYönetimiToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ts_EnvanterGoruntule;
        private System.Windows.Forms.ToolStripMenuItem ts_MenuOlustur;
        private System.Windows.Forms.Button btn_CancelSelected;
        private System.Windows.Forms.Button btn_Checkout;
        private System.Windows.Forms.ToolStripMenuItem ts_MenuGoruntule;
    }
}