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

namespace OtelYeniProje.Formlar.WebSite
{
    public partial class FrmMesajKarti : Form
    {
        public FrmMesajKarti()
        {
            InitializeComponent();
        }

        public int id;
        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();
        Repository<TblMesaj2> repo = new Repository<TblMesaj2>();

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMesajKarti_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var mesaj = repo.Find(x => x.MesajID == id);
                TxtMail.Text = mesaj.Gonderen;
                TxtKonu.Text = mesaj.Konu;
                TxtMesaj.Text = mesaj.Mesaj;
                TxtTarih.Text = mesaj.Tarih.ToString();
                var kisi = dbEntities1.TblYeniKayits.Where(x => x.Mail == mesaj.Gonderen).Select(y => y.AdSoyad).FirstOrDefault();
                TxtAdSoyad.Text = kisi.ToString();
            }
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            TblMesaj2 t = new TblMesaj2();
            t.Gonderen = "Admin";
            t.Alici = TxtMail.Text;
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            t.Konu = TxtKonu.Text;
            t.Mesaj = TxtMesaj.Text;
            repo.TAdd(t);
            XtraMessageBox.Show("Mesajınız başarılı bir şekilde gönderildi.");
        }
    }
}
