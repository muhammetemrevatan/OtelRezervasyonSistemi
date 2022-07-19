﻿using OtelYeniProje.Entities;
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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            db.TblKasas.Load();
            bindingSource1.DataSource = db.TblKasas.Local;
            
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurums
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAd
                                                        }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
