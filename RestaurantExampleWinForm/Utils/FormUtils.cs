﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XIV.Utils
{
    public static class FormUtils
    {
        /// <summary>
        /// Açık olan bütün formları kapatır ve giriş ekranını aktif hale getirir.
        /// </summary>
        public static void GirisEkraninaDon(string girisFormIsmi)
        {
            List<Form> Acikformlar = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                Acikformlar.Add(form);
            }
            foreach (Form form in Acikformlar)
            {
                if (form.Name != girisFormIsmi)
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
        /// Verilen isme göre açık olan formlarda formu arar.
        /// Bulunduysa true döndürür.
        /// </summary>
        public static bool FormlariBul(string formAd, out List<Form> bulunanFormListesi)
        {
            bulunanFormListesi = new List<Form>();
            bool found = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == formAd)
                {
                    found = true;
                    bulunanFormListesi.Add(form);
                }
            }
            return found;
        }

        /// <summary>
        /// Eğer formun birden fazla örneği varsa bir tanesini aktif yapar ve diğerlerini kapatıp true döndürür.
        /// Açık bir örnek yoksa false döndürür.
        /// </summary>
        public static bool CloseAllInstance(string FormAdi)
        {
            FormUtils.FormlariBul(FormAdi, out List<Form> form);
            if (form.Count >= 1)
            {
                for (int i = 1; i < form.Count; i++)
                {
                    form[i].Close();
                    form.RemoveAt(i);
                }
                form[0].Activate();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Eğer verilen türde açık form yoksa formu oluşturur. Açık form varsa aktif hale getirir.
        /// </summary>
        public static void TekliFormOlustur<T>(string mdiParent) where T : Form
        {
            Type type = typeof(T);
            if (!CloseAllInstance(type.Name))
            {
                Form frm = (Form)Activator.CreateInstance(type);
                FormlariBul(mdiParent, out List<Form> anaSayfa);
                frm.MdiParent = anaSayfa[0];
                frm.Show();
            }
        }

        /// <summary>
        /// Eğer verilen türde açık form yoksa formu oluşturur. Açık form varsa aktif hale getirir.
        /// </summary>
        public static void TekliFormOlustur<T>(Form mdiParent) where T : Form
        {
            Type type = typeof(T);
            if (!CloseAllInstance(type.Name))
            {
                Form frm = (Form)Activator.CreateInstance(type);
                frm.MdiParent = mdiParent;
                frm.Show();
            }
        }

        public static DataGridViewColumn ColumnOlustur(string DataPropertyName, string Header)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Name = DataPropertyName;
            column.DataPropertyName = DataPropertyName;
            column.HeaderText = Header;
            return column;
        }

    }
}