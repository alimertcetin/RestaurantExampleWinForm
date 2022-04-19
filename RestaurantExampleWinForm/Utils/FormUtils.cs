using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace XIV.Utils
{
    
    public static class FormUtils
    {
        /// <summary>
        /// Close all forms but keep the ones that has same type with <typeparamref name="T"/>
        /// </summary>
        public static void CloseAllBut<T>() where T : Form
        {
            Type type = typeof(T);
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != type)
                {
                    form.Close();
                }
                else
                {
                    form.Show();
                    form.Activate();
                }
            }
        }

        /// <summary>
        /// Close all Forms type of <typeparamref name="T"/>
        /// </summary>
        public static void CloseAllInstance<T>() where T : Form
        {
            Type type = typeof(T);
            foreach (Form item in Application.OpenForms)
            {
                if(item.GetType() != type)
                {
                    item.Close();
                }
            }
        }

        /// <summary>
        /// If form is open returns form, else returns new form of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Form Type</typeparam>
        public static T GetForm<T>() where T : Form
        {
            Type type = typeof(T);
            foreach (Form item in Application.OpenForms)
            {
                if(item.GetType() == type)
                {
                    return (T)item;
                }
            }
            return CreateForm<T>();
        }

        /// <summary>
        /// If form is open returns form, else returns new form of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Form Type</typeparam>
        public static T OpenForm<T>(Form mdiParent, bool show = true) where T : Form
        {
            Form form = GetForm<T>();
            form.MdiParent = mdiParent;
            if (show)
            {
                form.Show();
                //TODO : Do we need Activate call?
                form.Activate();
            }

            return (T)form;
        }

        /// <summary>
        /// Opens a form type of <typeparamref name="T"/>
        /// </summary>
        public static T CreateForm<T>() where T : Form
        {
            Type type = typeof(T);
            Form form = (Form)Activator.CreateInstance(type);
            return (T)form;
        }

        public static DataGridViewColumn ColumnOlustur(string DataPropertyName, string Header)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Name = DataPropertyName;
            column.DataPropertyName = DataPropertyName;
            column.HeaderText = Header;
            return column;
        }

        public static void FillCombo_WithEnum<T>(ComboBox comboBox) where T : Enum
        {
            comboBox.Items.Clear();
            Array values = EnumUtils.GetValues<T>();
            foreach (object item in values)
            {
                comboBox.Items.Add(item.ToString());
            }
            if(comboBox.SelectedIndex == -1 && comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        public static void FillFlp_RadioWithEnum<T>(FlowLayoutPanel flowLayoutPanel) 
            where T : Enum
        {
            flowLayoutPanel.Controls.Clear();
            Array values = EnumUtils.GetValues<T>();
            foreach (object item in values)
            {
                var control = new RadioButton();
                control.Name = $"rb_{item}";
                control.Text = item.ToString();
            }
        }

        public static void FillFlp_CheckBoxWithEnum<T>(FlowLayoutPanel flowLayoutPanel) 
            where T : Enum
        {
            flowLayoutPanel.Controls.Clear();
            Array values = EnumUtils.GetValues<T>();
            foreach (object item in values)
            {
                var control = new CheckBox();
                control.Name = $"cb_{item}";
                control.Text = item.ToString();
            }
        }

        public static void RefreshComboBox(ComboBox cmb, List<object> itemList)
        {
            cmb.Items.Clear();
            foreach (object item in itemList)
            {
                cmb.Items.Add(item);
            }
            if(cmb.SelectedIndex == -1 && cmb.Items.Count > 0)
            {
                cmb.SelectedIndex = 0;
            }
        }

    }

}