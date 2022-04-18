using RestaurantExampleWinForm.Forms;
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

namespace RestaurantExampleWinForm
{
    public partial class frm_Parent : Form
    {
        public frm_Parent()
        {
            InitializeComponent();
        }

        private void frm_Parent_Load(object sender, EventArgs e)
        {
            FormUtils.TekliFormOlustur<frm_MainForm>(this);
        }
    }
}
