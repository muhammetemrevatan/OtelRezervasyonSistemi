﻿using DevExpress.XtraEditors;
using OtelYeniProje.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYeniProje.Formlar.Tanımlamalar
{
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        private void FrmGorev_Load(object sender, EventArgs e)
        {
            db.TblGorevs.Load();
            bindingSource1.DataSource = db.TblGorevs.Local;

            repositoryItemLookUpEditDepartman.DataSource = (from x in db.TblDepartmen
                                                        select new
                                                        {
                                                            x.DepartmanID,
                                                            x.DepartmanAd
                                                        }).ToList();



            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurums
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAd
                                                        }).ToList();
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Bilgiler kaydedilirken hata oluştu", "Uyarı");
            }
        }
    }
}
