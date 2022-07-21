﻿using OtelYeniProje.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYeniProje.Formlar.WebSite
{
    public partial class FrmGidenMesaj : Form
    {
        public FrmGidenMesaj()
        {
            InitializeComponent();
        }
        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();

        private void FrmGidenMesaj_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in dbEntities1.TblMesaj2
                                       select new
                                       {
                                           x.MesajID,
                                           x.Alici,
                                           x.Konu,
                                           x.Tarih,
                                           x.Gonderen
                                       }).Where(y => y.Gonderen == "Admin").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMesajKarti fr = new FrmMesajKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("MesajID").ToString());
            fr.Show();
        }
    }
}
