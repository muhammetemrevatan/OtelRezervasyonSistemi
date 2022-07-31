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

namespace OtelYeniProje.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonKarti : Form
    {
        public FrmRezervasyonKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();
        Repository<TblRezervasyon> repo = new Repository<TblRezervasyon>();
        Repository<TblOda> repo2 = new Repository<TblOda>();
        TblRezervasyon t = new TblRezervasyon();
        public int id;

        public void misafirListFunc(LookUpEdit p)
        {
            p.Properties.DataSource = (from field in dbEntities1.TblMisafirs
                                                       select new
                                                       {
                                                           field.MisafirID,
                                                           field.AdSoyad
                                                       }).ToList();
        }

        private void FrmRezervasyonKarti_Load(object sender, EventArgs e)
        {
            // Misafir Listesi - Kisi2 - Kisi3 - Kisi4
            misafirListFunc(lookUpEditMisafir);
            misafirListFunc(lookUpEditKisi2);
            misafirListFunc(lookUpEditKisi3);
            misafirListFunc(lookUpEditKisi4);
            // Oda Listesi
            lookUpEditOda.Properties.DataSource = (from field in dbEntities1.TblOdas
                                                   select new
                                                   {
                                                       field.OdaID,
                                                       field.OdaNo,
                                                       field.Durum
                                                   }).Where(x => x.Durum == 1).ToList();
            // Durum Listesi
            lookUpEditDurum.Properties.DataSource = (from field in dbEntities1.TblDurums
                                                     select new
                                                     {
                                                         field.DurumID,
                                                         field.DurumAd,
                                                     }).ToList();
            //Ürün güncelleme alanı
            if (id != 0)
            {
                lookUpEditOda.Properties.DataSource = (from field in dbEntities1.TblOdas
                                                       select new
                                                       {
                                                           field.OdaID,
                                                           field.OdaNo,
                                                           field.Durum
                                                       }).Where(x => x.Durum == 1).ToList().ToList();
                var rezervasyon = repo.Find(x => x.RezervasyonID == id);
                lookUpEditMisafir.EditValue = rezervasyon.Misafir;
                lookUpEditKisi2.EditValue = rezervasyon.Kisi2;
                lookUpEditKisi3.EditValue = rezervasyon.Kisi3;
                lookUpEditKisi4.EditValue = rezervasyon.Kisi4;
                lookUpEditDurum.EditValue = rezervasyon.Durum;
                lookUpEditOda.EditValue = rezervasyon.Oda;
                dateEditGiris.EditValue = rezervasyon.GirisTarih.ToString();
                dateEditCikis.EditValue = rezervasyon.CikisTarih.ToString();
                if(rezervasyon.Kisi == null)
                {
                    numericUpDown1.Value = 1;
                }
                else
                {
                    numericUpDown1.Value = decimal.Parse(rezervasyon.Kisi.ToString());
                }
                TxtAciklama.Text = rezervasyon.Aciklana;
                TxtTelefon.Text = rezervasyon.Telefon;
                TxtToplam.Text = rezervasyon.Toplam.ToString();
                TxtAlinanUcret.Text = rezervasyon.AlinanUcret.ToString();
                TxtKalanUcret.Text = (rezervasyon.Toplam - rezervasyon.AlinanUcret).ToString();
                if (rezervasyon.Oda == null)
                {
                    XtraMessageBox.Show("Daha önceden bir oda atanmamış.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TxtOdaNo.Text = rezervasyon.TblOda.OdaNo;
                }
                
            }


        }

        //Vazgeç butonuna tıklanınca
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Güncelle butonu kapatma/açma
        public void BtnKaydetChanged(bool b)
        {
            BtnKaydet.Visible = b;
        }

        // Kaydet butonunu kapatma/açma
        public void BtnGuncelleChanged(bool b)
        {
            BtnGuncelle.Visible = b;
        }

        //Kaydet butonuna tıklanınca
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == 1)
            {
                try
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (numericUpDown1.Value == 2)
            {
                try
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanlarını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            else if (numericUpDown1.Value == 3)
            {
                try
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                    t.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanlarını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (numericUpDown1.Value == 4)
            {
                try
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                    t.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
                    t.Kisi4 = int.Parse(lookUpEditKisi4.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanlarını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
            if(dateEditGiris.Text.Equals("") || lookUpEditOda.EditValue.ToString().Equals("") 
                || lookUpEditDurum.EditValue.ToString().Equals("") || TxtToplam.Text == ""
                || lookUpEditMisafir.EditValue.ToString().Equals("") || TxtTelefon.Text == "")
            {
                dateEditGiris.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditOda.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditDurum.BackColor = System.Drawing.Color.LightGoldenrodYellow; 
                lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtTelefon.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtToplam.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                XtraMessageBox.Show("Lütfen zorunlu alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                t.RezervasyonAdSoyad = lookUpEditMisafir.Text;
                t.GirisTarih = DateTime.Parse(dateEditGiris.Text);
                t.CikisTarih = DateTime.Parse(dateEditCikis.Text);
                t.Kisi = numericUpDown1.Value.ToString();
                t.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
                t.Telefon = TxtTelefon.Text;
                t.Aciklana = TxtAciklama.Text;
                t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
                t.Toplam = Decimal.Parse(TxtToplam.Text);
                t.AlinanUcret = Decimal.Parse(TxtAlinanUcret.Text);
                repo.TAdd(t);
                XtraMessageBox.Show("Rezervasyon sisteme kaydedildi.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        // Kisi sayısı degistirilince gerceklesecek islemler
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 1)
            {
                lookUpEditKisi2.Visible = false;
                labelKisi2.Visible = true;
                lookUpEditKisi3.Visible = false;
                labelKisi3.Visible = true;
                lookUpEditKisi4.Visible = false;
                labelKisi4.Visible = true;
            }
            else if(numericUpDown1.Value == 2)
            {
                lookUpEditKisi2.Visible = true;
                labelKisi2.Visible = false;
                lookUpEditKisi3.Visible = false;
                labelKisi3.Visible = true;
                lookUpEditKisi4.Visible = false;
                labelKisi4.Visible = true;
            }
            else if (numericUpDown1.Value == 3)
            {
                lookUpEditKisi2.Visible = true;
                labelKisi2.Visible = false;
                lookUpEditKisi3.Visible = true;
                labelKisi3.Visible = false;
                lookUpEditKisi4.Visible = false;
                labelKisi4.Visible = true;
            }
            else if (numericUpDown1.Value == 4)
            {
                lookUpEditKisi2.Visible = true;
                labelKisi2.Visible = false;
                lookUpEditKisi3.Visible = true;
                labelKisi3.Visible = false;
                lookUpEditKisi4.Visible = true;
                labelKisi4.Visible = false;
            }
        }

        // Misafir seçilince telefon bilgisini getirme
        private void lookUpEditMisafir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditMisafir.EditValue.ToString());
            var telefon = dbEntities1.TblMisafirs.Where(x => x.MisafirID == secilen).Select(y => y.Telefon).FirstOrDefault();
            TxtTelefon.Text = telefon.ToString();
        }

        // Güncelle butonuna tıklanınca
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var rezervasyon = repo.Find(x => x.RezervasyonID == id);
            int databaseOdaValue;
           
            try
            {
               databaseOdaValue = rezervasyon.Oda.Value;
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Daha önce bir oda numarası atanmamış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                databaseOdaValue = 0;
            }

            if (databaseOdaValue != int.Parse(lookUpEditOda.EditValue.ToString()) && databaseOdaValue != 0)
            {
                XtraMessageBox.Show("Oda Numarası Değiştirdiniz. Lütfen Eski Oda numarasını Oda tanımlarından düzenleyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (numericUpDown1.Value == 1)
            {
                try
                {
                    rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (numericUpDown1.Value == 2)
            {
                try
                {
                    rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanlarını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (numericUpDown1.Value == 3)
            {
                try
                {
                    rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                    rezervasyon.Kisi3 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanlarını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (numericUpDown1.Value == 4)
            {
                try
                {
                    rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                    rezervasyon.Kisi3 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                    rezervasyon.Kisi4 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                }
                catch (Exception)
                {
                    lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    lookUpEditKisi4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    XtraMessageBox.Show("Lütfen Misafir ismi alanlarını giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            if (dateEditGiris.Text.Equals("") || lookUpEditOda.EditValue == null || TxtToplam.Text == ""
                || lookUpEditDurum == null || lookUpEditMisafir.EditValue == null || TxtTelefon.Text == "")
            {
                dateEditGiris.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditOda.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditDurum.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtTelefon.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtToplam.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                XtraMessageBox.Show("Lütfen zorunlu alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.RezervasyonAdSoyad = lookUpEditMisafir.Text;
                rezervasyon.GirisTarih = DateTime.Parse(dateEditGiris.Text);
                if(dateEditCikis.Text == "")
                {
                    rezervasyon.CikisTarih = null;
                }
                else
                {
                    rezervasyon.CikisTarih = DateTime.Parse(dateEditCikis.Text);
                }
                rezervasyon.Kisi = numericUpDown1.Value.ToString();
                rezervasyon.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
                rezervasyon.Telefon = TxtTelefon.Text;
                rezervasyon.Aciklana = TxtAciklama.Text;
                rezervasyon.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
                rezervasyon.Toplam = Decimal.Parse(TxtToplam.Text);
                rezervasyon.AlinanUcret = Decimal.Parse(TxtAlinanUcret.Text);
                repo.TUpdate(rezervasyon);
                XtraMessageBox.Show("Rezervasyon Güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
