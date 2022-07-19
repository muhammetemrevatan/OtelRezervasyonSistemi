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
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();
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

        public void btnKaydetChanged(bool b)
        {
            BtnKaydet.Visible = b;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtAd.Text == "" || TxtFiyat.Text == "" || TxtKDV.Text == "" || TxtToplam.Text == ""
                || lookUpEditUrunGroup.EditValue == null || lookUpEditDurum.EditValue == null || lookUpEditBirim.EditValue == null)
            {
                if(TxtAd.Text == "")
                {
                    TxtAd.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtFiyat.Text == "")
                {
                    TxtFiyat.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtKDV.Text == "")
                {
                    TxtKDV.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtToplam.Text == "")
                {
                    TxtToplam.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditUrunGroup.EditValue == null)
                {
                    lookUpEditUrunGroup.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditDurum.EditValue == null)
                {
                    lookUpEditDurum.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditBirim.EditValue == null)
                {
                    lookUpEditBirim.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                XtraMessageBox.Show("Ürün Kaydedilemedi. Tüm alanların dolu olduğundan emin olun.","HATA", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                tblUrun.UrunAd = TxtAd.Text;
                tblUrun.UrunGrup = int.Parse(lookUpEditUrunGroup.EditValue.ToString());
                tblUrun.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
                tblUrun.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
                tblUrun.Fiyat = decimal.Parse(TxtFiyat.Text);
                tblUrun.Toplam = decimal.Parse(TxtToplam.Text);
                tblUrun.Kdv = byte.Parse(TxtKDV.Text);
                repo.TAdd(tblUrun);
                XtraMessageBox.Show("Ürün kaydedildi.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urunDeger = repo.Find(x => x.UrunID == id);
            if (TxtAd.Text == "" || TxtFiyat.Text == "" || TxtKDV.Text == "" || TxtToplam.Text == ""
               || lookUpEditUrunGroup.EditValue == null || lookUpEditDurum.EditValue == null || lookUpEditBirim.EditValue == null)
            {
                if (TxtAd.Text == "")
                {
                    TxtAd.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtFiyat.Text == "")
                {
                    TxtFiyat.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtKDV.Text == "")
                {
                    TxtKDV.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtToplam.Text == "")
                {
                    TxtToplam.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditUrunGroup.EditValue == null)
                {
                    lookUpEditUrunGroup.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditDurum.EditValue == null)
                {
                    lookUpEditDurum.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditBirim.EditValue == null)
                {
                    lookUpEditBirim.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                XtraMessageBox.Show("Ürün Kaydedilemedi. Tüm alanların dolu olduğundan emin olun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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

        private void Rdb4_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "18";
        }

        private void Rdb3_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "10";
        }

        private void Rdb2_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "8";
        }

        private void Rdb1_CheckedChanged(object sender, EventArgs e)
        {
            TxtKDV.Text = "1";
        }
    }
}
