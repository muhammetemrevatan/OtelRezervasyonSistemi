﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelYeniProje.Entities;

namespace OtelYeniProje.Formlar.Grafikler
{
    public partial class FrmGrafik2 : Form
    {
        public FrmGrafik2()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        private void FrmGrafik2_Load(object sender, EventArgs e)
        {
            var durumlar = db.OdaDurum();
            foreach (var x in durumlar)
            {
                chartControl1.Series["Odalar"].Points.AddPoint(x.DurumAd, double.Parse(x.Sayı.ToString()));
            }
        }
    }
}
