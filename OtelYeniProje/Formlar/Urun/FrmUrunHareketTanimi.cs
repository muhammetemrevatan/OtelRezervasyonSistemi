using DevExpress.XtraEditors;
using OtelYeniProje.Entities;
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

namespace OtelYeniProje.Formlar.Urun
{
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }

        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();
        Repository<TblUrunHareket> repo = new Repository<TblUrunHareket>();
        TblUrunHareket tblUrunHareket = new TblUrunHareket();
        public int id;

        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {
            //id değeri
            TxtID.Enabled = false;
            // Ürün listesi
            lookUpEditUrun.Properties.DataSource = (from field in dbEntities1.TblUruns
                                                         select new
                                                         {
                                                             field.UrunID,
                                                             field.UrunAd
                                                         }).ToList();
            //Verilerin kart alanlarına doldurulması
            if(id != 0)
            {
                var urun = repo.Find(x => x.HareketID == id);
                lookUpEditUrun.EditValue = urun.Urun;
                TxtMiktar.Text = urun.Miktar.ToString();
                TxtAciklama.Text = urun.Aciklama;
                comboBox1.Text = urun.HareketTuru;
                dateEdit1.Text = urun.Tarih.ToString();
            }
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BtnGunncelleVisibled(bool b)
        {
            BtnGuncelle.Visible = b;
        }

        public void BtnKaydetVisibled(bool b)
        {
            BtnKaydet.Visible = b;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(dateEdit1.Text == "" ||lookUpEditUrun.EditValue == null || comboBox1.Text == "" ||TxtMiktar.Text == "")
            {
                dateEdit1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditUrun.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                comboBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtMiktar.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                XtraMessageBox.Show("Ürün Hareketi Eklenemedi.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tblUrunHareket.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
                tblUrunHareket.Tarih = DateTime.Parse(dateEdit1.Text);
                tblUrunHareket.HareketTuru = comboBox1.Text;
                tblUrunHareket.Miktar = decimal.Parse(TxtMiktar.Text);
                tblUrunHareket.Aciklama = TxtAciklama.Text;
                repo.TAdd(tblUrunHareket);
                XtraMessageBox.Show("Ürün Hareketi Eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urun = repo.Find(x => x.HareketID == id);
            if (dateEdit1.Text == "" || lookUpEditUrun.EditValue == null || comboBox1.Text == "" || TxtMiktar.Text == "")
            {
                dateEdit1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditUrun.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                comboBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtMiktar.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                XtraMessageBox.Show("Ürün Hareketi Eklenemedi.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                urun.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
                urun.Tarih = DateTime.Parse(dateEdit1.Text);
                urun.HareketTuru = comboBox1.Text;
                urun.Miktar = decimal.Parse(TxtMiktar.Text);
                urun.Aciklama = TxtAciklama.Text;
                repo.TUpdate(urun);
                XtraMessageBox.Show("Ürün Hareketi Güncellendi.");
                this.Close();
            }
            
        }
    }
}
