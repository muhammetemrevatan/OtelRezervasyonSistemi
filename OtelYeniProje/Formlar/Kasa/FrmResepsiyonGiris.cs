using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelYeniProje.Entities;
using OtelYeniProje.Repositories;

namespace OtelYeniProje.Formlar.Kasa
{
    public partial class FrmResepsiyonGiris : Form
    {
        public FrmResepsiyonGiris()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();

        TblKasaHareketi kasaHareketi = new TblKasaHareketi();
        Repository<TblKasaHareketi> repo = new Repository<TblKasaHareketi>();
        public int id;

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            kasaHareketi.IslemAdı = TxtIslemAdi.Text;
            kasaHareketi.Tarih = DateTime.Parse(TxtIslemTarih.Text);
            kasaHareketi.Tutar = Decimal.Parse(TxtIslemTutar.Text);
            kasaHareketi.Aciklama = TxtAciklama.Text;
            repo.TAdd(kasaHareketi);
            XtraMessageBox.Show("Başırıyla Kaydedildi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BtnGuncelleChanged(bool b)
        {
            BtnGuncelle.Visible = b;
        }

        public void BtnKaydetChanged(bool b)
        {
            BtnKaydet.Visible = b;
        }

        private void FrmResepsiyonGiris_Load(object sender, EventArgs e)
        {
            // Güncelleme işlemi için alanların doldurulması
            if(id != 0)
            {
                var kasa = repo.Find(x => x.ID == id);
                TxtIslemAdi.Text = kasa.IslemAdı;
                TxtIslemTarih.Text = kasa.Tarih.ToString();
                TxtIslemTutar.Text = kasa.Tutar.ToString();
                TxtAciklama.Text = kasa.Aciklama;
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var kasa = repo.Find(x => x.ID == id);
            kasa.IslemAdı = TxtIslemAdi.Text;
            kasa.Tarih = DateTime.Parse(TxtIslemTarih.Text);
            kasa.Tutar = Decimal.Parse(TxtIslemTutar.Text);
            kasa.Aciklama = TxtAciklama.Text;
            repo.TUpdate(kasa);
            XtraMessageBox.Show("Başırıyla Güncellendi.","BAŞARILI",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
    }
}
