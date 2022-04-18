using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XIV.Utils;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_MainForm : Form
    {
        public frm_MainForm()
        {
            InitializeComponent();
        }

        private void ts_MalzemeEkle_Click(object sender, EventArgs e)
        {
            FormUtils.TekliFormOlustur<frm_EnvantereEkle>(this.MdiParent.Name);
        }
    }
}
