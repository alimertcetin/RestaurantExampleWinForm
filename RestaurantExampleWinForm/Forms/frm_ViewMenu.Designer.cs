
namespace RestaurantExampleWinForm.Forms
{
    partial class frm_ViewMenu
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
            this.tv_Menu = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tv_Menu
            // 
            this.tv_Menu.Location = new System.Drawing.Point(12, 12);
            this.tv_Menu.Name = "tv_Menu";
            this.tv_Menu.Size = new System.Drawing.Size(202, 348);
            this.tv_Menu.TabIndex = 0;
            // 
            // frm_ViewMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 372);
            this.Controls.Add(this.tv_Menu);
            this.Name = "frm_ViewMenu";
            this.Text = "frm_ViewMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ViewMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_Menu;
    }
}