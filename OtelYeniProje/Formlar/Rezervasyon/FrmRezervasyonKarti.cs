using DevExpress.XtraEditors;
using OtelYeniProje.Entity;
using OtelYeniProje.Repositories;
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
    public partial class FrmRezervasyonKarti : Form
    {
        public FrmRezervasyonKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities1 dbEntities1 = new DbOtelEntities1();
        Repository<TblRezervasyon> repo = new Repository<TblRezervasyon>();
        TblRezervasyon t = new TblRezervasyon();
        public int id;

        private void FrmRezervasyonKarti_Load(object sender, EventArgs e)
        {
            // Misafir Listesi
            lookUpEditMisafir.Properties.DataSource = (from field in dbEntities1.TblMisafirs
                                                       select new
                                                       {
                                                           field.MisafirID,
                                                           field.AdSoyad
                                                       }).ToList();
            // Oda Listesi
            lookUpEditOda.Properties.DataSource = (from field in dbEntities1.TblOdas
                                                   select new
                                                   {
                                                       field.OdaID,
                                                       field.OdaNo,
                                                       field.TblDurum.DurumAd
                                                   }).Where(x => x.DurumAd == "Aktif").ToList();
            // Durum Listesi
            lookUpEditDurum.Properties.DataSource = (from field in dbEntities1.TblDurums
                                                     select new
                                                     {
                                                         field.DurumID,
                                                         field.DurumAd,
                                                     }).ToList();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            t.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            t.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            t.Kisi = numericUpDown1.Value.ToString();
            t.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            t.Telefon = TxtTelefon.Text;
            t.Aciklana = TxtAciklama.Text;
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            repo.TAdd(t);
            XtraMessageBox.Show("Rezervasyon sisteme kaydedildi.");
        }
    }
}
