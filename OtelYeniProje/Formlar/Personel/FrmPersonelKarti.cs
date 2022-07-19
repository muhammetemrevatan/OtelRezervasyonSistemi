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

namespace OtelYeniProje.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        public int id;
        Repository<TblPersonel> repo = new Repository<TblPersonel>();
        TblPersonel t = new TblPersonel();

        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            //this.Text = id.ToString(); FrmPersonelKarti yüklenince pencerenin Text kısmına değerin döndüğünü görmek için atama yaptık. 

            if (id != 0)
            {
                var personel = repo.Find(x => x.PersonelID == id);
                TxtAdSoyad.Text = personel.AdSoyad;
                TxtTc.Text = personel.TC;
                TxtAdres.Text = personel.Adres;
                TxtTelefon.Text = personel.Telefon;
                TxtMail.Text = personel.Mail;
                dateEditGiris.Text = personel.IseGirisTarih.ToString();
                dateEditCikis.Text = personel.IstenCikisTarih.ToString();
                TxtAciklama.Text = personel.Aciklama;
                TxtSifre.Text = personel.Sifre;
                try
                {
                    pictureEditKimlikOn.Image = Image.FromFile(personel.KimlikOn);
                    pictureEditKimlikArka.Image = Image.FromFile(personel.KimlikArka);
                    labelControl14.Text = personel.KimlikOn;
                    labelControl15.Text = personel.KimlikArka;
                }
                catch (Exception)
                {

                    XtraMessageBox.Show("Fotoğraf eklemelisiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
                lookUpEditDepartmant.EditValue = personel.Departman;
                lookUpEditGorev.EditValue = personel.Gorev;
            }


            lookUpEditDepartmant.Properties.DataSource = (from x in db.TblDepartmen
                                                          select new
                                                          {
                                                              x.DepartmanID,
                                                              x.DepartmanAd
                                                          }).ToList();

            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorevs
                                                     select new
                                                     {
                                                         x.GorevID,
                                                         x.GorevAd
                                                     }).ToList();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnGuncelleChanged(bool b)
        {
            BtnGuncelle.Visible = b;
        }

        public void btnKaydeChanged(bool b)
        {
            BtnKaydet.Visible = b;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAdSoyad.Text.Equals("") || TxtTc.Text.Equals("") || TxtTelefon.Text.Equals("")
                || TxtSifre.Text.Equals("") || dateEditGiris.Text.Equals("") || lookUpEditDepartmant.EditValue.ToString().Equals("") 
                || lookUpEditGorev.EditValue.ToString().Equals("") || labelControl14.Text == "" || labelControl15.Text == "")
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
                if (TxtSifre.Text.Equals(""))
                {
                    TxtSifre.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditGorev.EditValue == null)
                {
                    lookUpEditGorev.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditDepartmant.EditValue == null)
                {
                    lookUpEditDepartmant.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (dateEditGiris.Text.Equals(""))
                {
                    dateEditGiris.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                XtraMessageBox.Show("Tüm alanları doldurmalısınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                t.AdSoyad = TxtAdSoyad.Text;
                t.TC = TxtTc.Text;
                t.Adres = TxtAdres.Text;
                t.Telefon = TxtTelefon.Text;
                t.IseGirisTarih = DateTime.Parse(dateEditGiris.Text);
                t.Departman = int.Parse(lookUpEditDepartmant.EditValue.ToString());
                t.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
                t.Aciklama = TxtAciklama.Text;
                t.Mail = TxtMail.Text;
                t.KimlikOn = pictureEditKimlikOn.GetLoadedImageLocation();
                t.KimlikArka = pictureEditKimlikArka.GetLoadedImageLocation();
                t.Sifre = TxtSifre.Text;
                t.Durum = 1;

                try
                {
                    if (TxtTc.Text.Length != 11)
                    {
                        XtraMessageBox.Show("TC 11 haneli olarak girilmelidir..", "HATA");
                    }
                    else
                    {
                        repo.TAdd(t);
                        XtraMessageBox.Show("Personel sisteme kaydedildi.", "Başarılı");
                    }

                }
                catch (Exception)
                {

                    XtraMessageBox.Show("Personel sisteme eklenemedi. Lütfen alanları doğru girdiğinizden emin olun.", "HATA");
                }
                this.Close();
            }
           
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelID == id);
            if (TxtAdSoyad.Text.Equals("") || TxtTc.Text.Equals("") || TxtTelefon.Text.Equals("")
               || TxtSifre.Text.Equals("") || dateEditGiris.Text.Equals("") || lookUpEditDepartmant.EditValue.ToString().Equals("")
               || lookUpEditGorev.EditValue.ToString().Equals("") || labelControl14.Text == "" || labelControl15.Text == "")
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
                if (TxtSifre.Text.Equals(""))
                {
                    TxtSifre.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditGorev.EditValue == null)
                {
                    lookUpEditGorev.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (lookUpEditDepartmant.EditValue == null)
                {
                    lookUpEditDepartmant.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (dateEditGiris.Text.Equals(""))
                {
                    dateEditGiris.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                XtraMessageBox.Show("Tüm alanları doldurmalısınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                deger.AdSoyad = TxtAdSoyad.Text;
                deger.TC = TxtTc.Text;
                deger.Adres = TxtAdres.Text;
                deger.Telefon = TxtTelefon.Text;
                deger.IseGirisTarih = DateTime.Parse(dateEditGiris.Text);
                deger.Departman = int.Parse(lookUpEditDepartmant.EditValue.ToString());
                deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
                deger.Aciklama = TxtAciklama.Text;
                deger.Mail = TxtMail.Text;
                deger.KimlikOn = labelControl14.Text;
                deger.KimlikArka = labelControl15.Text;
                deger.Sifre = TxtSifre.Text;
                try
                {
                    if (TxtTc.Text.Length != 11)
                    {
                        XtraMessageBox.Show("TC 11 haneli olarak girilmelidir..", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        repo.TUpdate(deger);
                        XtraMessageBox.Show("Personel kartı bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception)
                {

                    XtraMessageBox.Show("Personel sistemde güncellenemedi. Lütfen alanları doğru girdiğinizden emin olun.", "HATA");
                }
                this.Close();

                
            }
            
        }

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            labelControl14.Text = pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            labelControl15.Text = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }
    }
}
