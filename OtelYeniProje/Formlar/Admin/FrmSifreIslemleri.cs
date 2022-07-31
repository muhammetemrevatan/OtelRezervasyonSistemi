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

namespace OtelYeniProje.Formlar.Admin
{
    public partial class FrmSifreIslemleri : Form
    {
        public FrmSifreIslemleri()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        public int id;
        Repository<TblAdmin> repo = new Repository<TblAdmin>();

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSifreIslemleri_Load(object sender, EventArgs e)
        {
            if(id != 0)
            {
                var admin = repo.Find(x => x.ID == id);
                TxtKullanici.Text = admin.Kullanici;
                TxtMecutSifre.Text = admin.Sifre;
                TxtRol.Text = admin.Rol;
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtSifre.Text == TxtSifreTekrar.Text)
            {
                TblAdmin t = new TblAdmin();
                t.Kullanici = TxtKullanici.Text;
                t.Sifre = TxtSifre.Text;
                db.SaveChanges();
                XtraMessageBox.Show("Yeni Kullanıcı Oluşturuldu.", "BAŞARILI");
            }
            else
            {
                XtraMessageBox.Show("Şifreler uyuşmuyor.", "HATA");
            }        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(TxtSifre.Text == TxtSifreTekrar.Text)
            {
                var deger = repo.Find(x => x.ID == id);
                deger.Kullanici = TxtKullanici.Text;
                deger.Sifre = TxtSifre.Text;
                deger.Rol = TxtRol.Text;
                repo.TUpdate(deger);
                XtraMessageBox.Show("Güncellendi.", "BAŞARILI");
            }
            else
            {
                XtraMessageBox.Show("Şifreler uyuşmuyor.", "Uyarı");
            }

           
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmAdminListesi fr = new FrmAdminListesi();
            fr.Show();
            this.Hide();
        }
    }
}
