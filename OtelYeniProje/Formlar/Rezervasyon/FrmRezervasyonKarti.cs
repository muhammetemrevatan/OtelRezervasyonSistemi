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
                                                       field.TblDurum.DurumAd
                                                   }).Where(x => x.DurumAd == "Aktif").ToList();
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
            }


        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BtnKaydetChanged(bool b)
        {
            BtnKaydet.Visible = b;
        }

        public void BtnGuncelleChanged(bool b)
        {
            BtnGuncelle.Visible = b;
        }

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
                || lookUpEditDurum.EditValue.ToString().Equals("")
                || lookUpEditMisafir.EditValue.ToString().Equals("") || TxtTelefon.Text == "")
            {
                dateEditGiris.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditOda.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditDurum.BackColor = System.Drawing.Color.LightGoldenrodYellow; 
                lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtTelefon.BackColor = System.Drawing.Color.LightGoldenrodYellow;
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
                repo.TAdd(t);
                XtraMessageBox.Show("Rezervasyon sisteme kaydedildi.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }

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

        private void lookUpEditMisafir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditMisafir.EditValue.ToString());
            var telefon = dbEntities1.TblMisafirs.Where(x => x.MisafirID == secilen).Select(y => y.Telefon).FirstOrDefault();
            TxtTelefon.Text = telefon.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var rezervasyon = repo.Find(x => x.RezervasyonID == id);

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

            if (dateEditGiris.Text.Equals("") || lookUpEditOda.EditValue == null
                || lookUpEditDurum == null || lookUpEditMisafir.EditValue == null || TxtTelefon.Text == "")
            {
                dateEditGiris.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditOda.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditDurum.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lookUpEditMisafir.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                TxtTelefon.BackColor = System.Drawing.Color.LightGoldenrodYellow;
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
                repo.TUpdate(rezervasyon);
                XtraMessageBox.Show("Rezervasyon Güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
