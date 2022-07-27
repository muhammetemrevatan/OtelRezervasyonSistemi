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

namespace OtelYeniProje.Formlar.Misafir
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        public int id;
        Repository<TblMisafir> repo = new Repository<TblMisafir>();
        TblMisafir t = new TblMisafir();
        string resim1, resim2;

        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {

            //Güncellenecek kart bilgileri
            if (id != 0)
            {
                var misafir = repo.Find(x => x.MisafirID == id);
                TxtAdSoyad.Text = misafir.AdSoyad;
                TxtTc.Text = misafir.TC;
                TxtAdres.Text = misafir.Adres;
                TxtTelefon.Text = misafir.Telefon;
                TxtMail.Text = misafir.Mail;
                TxtAciklama.Text = misafir.Aciklama;
                try
                {
                    pictureEditKimlikOn.Image = Image.FromFile(misafir.KimlikFoto1);
                    pictureEditKimlikArka.Image = Image.FromFile(misafir.KimlikFoto2);
                    resim1 = misafir.KimlikFoto1;
                    resim2 = misafir.KimlikFoto2;
                }
                catch (Exception)
                {

                    XtraMessageBox.Show("Fotoğraf eklemelisiniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
                lookUpEditSehir.EditValue = misafir.sehir;
                lookUpEditUlke.EditValue = misafir.Ulke;
                lookUpEditilce.EditValue = misafir.ilce;
            }

            //ülke listesi
            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlkes
                                                          select new
                                                          {
                                                              x.UlkeID,
                                                              x.UlkeAd
                                                          }).ToList();

            //şehir listesi
            lookUpEditSehir.Properties.DataSource = (from x in db.illers
                                                    select new
                                                    {
                                                        Id = x.id,
                                                        Şehir = x.sehir
                                                    }).ToList();
        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditilce.Properties.DataSource = (from x in db.ilcelers
                                                    select new
                                                    {
                                                        Id = x.id,
                                                        İlçe = x.ilce,
                                                        Şehir = x.sehir
                                                    }).Where(y => y.Şehir == secilen).ToList();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            resim1 = pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            resim2 = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }

        public void btnGuncelleChanged(bool b)
        {
            BtnGuncelle.Visible = b;
        }

        public void btnKaydetChanged(bool b)
        {
            BtnKaydet.Visible = b;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.MisafirID == id);
            if (TxtAdSoyad.Text.Equals("") || TxtTc.Text.Equals("") || TxtTelefon.Text.Equals("")
                || lookUpEditSehir.EditValue == null || lookUpEditilce.EditValue == null
                || lookUpEditUlke.EditValue == null || resim1 == null || resim2 == null)
            {
                if (TxtAdSoyad.Text.Equals(""))
                {
                    TxtAdSoyad.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtTc.Text.Equals(""))
                {
                    TxtTc.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtTelefon.Text.Equals(""))
                {
                    TxtTelefon.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                XtraMessageBox.Show("Tüm alanları doldurmalısınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                deger.AdSoyad = TxtAdSoyad.Text;
                deger.TC = TxtTc.Text;
                deger.Mail = TxtMail.Text;
                deger.Telefon = TxtTelefon.Text;
                deger.Adres = TxtAdres.Text;
                deger.Aciklama = TxtAciklama.Text;
                deger.KimlikFoto1 = resim1;
                deger.KimlikFoto2 = resim2;
                deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
                deger.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
                deger.ilce = int.Parse(lookUpEditilce.EditValue.ToString());
                deger.Durum = 1;
                repo.TUpdate(deger);
                XtraMessageBox.Show("Misafir kartı bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAdSoyad.Text.Equals("") || TxtTc.Text.Equals("") || TxtTelefon.Text.Equals("")
                || lookUpEditSehir.EditValue == null || lookUpEditilce.EditValue == null
                || lookUpEditUlke.EditValue == null || resim1 == null || resim2 == null)
            {
                if (TxtAdSoyad.Text.Equals(""))
                {
                    TxtAdSoyad.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtTc.Text.Equals(""))
                {
                    TxtTc.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (TxtTelefon.Text.Equals(""))
                {
                    TxtTelefon.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                XtraMessageBox.Show("Tüm alanları doldurmalısınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (TxtTc.Text.Length != 11)
                {
                    XtraMessageBox.Show("TC 11 haneli olarak girilmelidir..", "HATA");
                }
                else
                {
                    t.AdSoyad = TxtAdSoyad.Text;
                    t.TC = TxtTc.Text;
                    t.Mail = TxtMail.Text;
                    t.Telefon = TxtTelefon.Text;
                    t.Adres = TxtAdres.Text;
                    t.Aciklama = TxtAciklama.Text;
                    t.Durum = 1;
                    t.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
                    t.ilce = int.Parse(lookUpEditilce.EditValue.ToString());
                    t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
                    t.KimlikFoto1 = resim1;
                    t.KimlikFoto2 = resim2;
                    repo.TAdd(t);
                    XtraMessageBox.Show("Misafir sisteme başarılı bir şekilde kaydedildi.");
                    this.Close();
                }
            }
        }
    }
}
