using OtelYeniProje.Entity;
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
    public partial class FrmIptalRezervasyon : Form
    {
        public FrmIptalRezervasyon()
        {
            InitializeComponent();
        }

        DbOtelEntities1 db = new DbOtelEntities1();

        private void FrmIptalRezervasyon_Load(object sender, EventArgs e)
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
                                       }).Where(y => y.DurumAd == "Rezervasyon İptal").ToList();
        }
    }
}
