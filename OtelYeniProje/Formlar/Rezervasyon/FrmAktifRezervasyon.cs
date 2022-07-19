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

namespace OtelYeniProje.Formlar.Rezervasyon
{
    public partial class FrmAktifRezervasyon : Form
    {
        public FrmAktifRezervasyon()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();

        private void FrmAktifRezervasyon_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblRezervasyons
                                       select new
                                       {
                                           x.RezervasyonID,
                                           x.TblMisafir.AdSoyad,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Kisi,
                                           x.TblOda.OdaNo,
                                           x.Telefon,
                                           x.TblDurum.DurumAd
                                       }).Where(y =>y.DurumAd == "Aktif").ToList();
        }
    }
}
