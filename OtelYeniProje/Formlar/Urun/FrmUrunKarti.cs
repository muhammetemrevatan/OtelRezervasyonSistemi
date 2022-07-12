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

namespace OtelYeniProje.Formlar.Urun
{
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities1 dbEntities1 = new DbOtelEntities1();
        Repository<TblUrun> repo = new Repository<TblUrun>();
        TblUrun tblUrun = new TblUrun();
        public int id;

        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            // Ürün grup listesi
            lookUpEditUrunGroup.Properties.DataSource = (from field in dbEntities1.TblUrunGrups
                                                         select new
                                                         {
                                                             field.UrunGrupID,
                                                             field.UrunGrupAd
                                                         }).ToList();
            // Durum listesi
            lookUpEditDurum.Properties.DataSource = (from field in dbEntities1.TblDurums
                                                     select new
                                                     {
                                                         field.DurumID,
                                                         field.DurumAd
                                                     }).ToList();
            // Birim listesi
            lookUpEditBirim.Properties.DataSource = (from field in dbEntities1.TblBirims
                                                     select new
                                                     {
                                                         field.BirimID,
                                                         field.BirimAd
                                                     }).ToList();

            //Ürün güncelleme alanı
            if(id != 0)
            {
                var urun = repo.Find(x => x.UrunID == id);
                TxtAd.Text = urun.UrunAd;
                lookUpEditUrunGroup.EditValue = urun.UrunGrup;
                lookUpEditBirim.EditValue = urun.Birim;
                TxtFiyat.Text = urun.Fiyat.ToString();
                TxtToplam.Text = urun.Toplam.ToString();
                int switch_on = int.Parse(urun.Kdv.ToString());
                switch (switch_on)
                {
                    case 1:
                        Rdb1.Checked = true;
                        break;
                    case 8:
                        Rdb2.Checked = true;
                        break;
                    case 10:
                        Rdb3.Checked = true;
                        break;
                    case 18:
                        Rdb4.Checked = true;
                        break;
                    default:
                        break;
                }
                TxtKDV.Text = urun.Kdv.ToString();
                lookUpEditDurum.EditValue = urun.Durum;
            }
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void btnGuncelleChanged(bool b)
        {
            BtnGuncelle.Visible = b;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            tblUrun.UrunAd = TxtAd.Text;
            tblUrun.UrunGrup = int.Parse(lookUpEditUrunGroup.EditValue.ToString());
            tblUrun.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
            tblUrun.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            tblUrun.Fiyat = decimal.Parse(TxtFiyat.Text);
            tblUrun.Toplam = decimal.Parse(TxtToplam.Text);
            tblUrun.Kdv = byte.Parse(TxtKDV.Text);
            repo.TAdd(tblUrun);
            XtraMessageBox.Show("Ürün kaydedildi.");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urunDeger = repo.Find(x => x.UrunID == id);
            urunDeger.UrunAd = TxtAd.Text;
            urunDeger.UrunGrup = int.Parse(lookUpEditUrunGroup.EditValue.ToString());
             
            urunDeger.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
            urunDeger.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            urunDeger.Fiyat = decimal.Parse(TxtFiyat.Text);
            urunDeger.Toplam = decimal.Parse(TxtToplam.Text);
            urunDeger.Kdv = byte.Parse(TxtKDV.Text);
            repo.TUpdate(urunDeger);
            XtraMessageBox.Show("Ürün güncellendi.");
            this.Close();
        }
    }
}
