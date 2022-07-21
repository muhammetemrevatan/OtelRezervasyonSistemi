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
    public partial class FrmAdresKarti : Form
    {
        public FrmAdresKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();
        Repository<TblIletisim> repo = new Repository<TblIletisim>();
        private void FrmAdresKarti_Load(object sender, EventArgs e)
        {
            var mesaj = repo.Find(x => x.ID == 1);
            TxtKoordinat.Text = mesaj.Koordinat;
            TxtMail.Text = mesaj.Mail;
            TxtTelefon.Text = mesaj.Telefon;
            TxtAdres.Text = mesaj.Adress;
            TxtAciklama.Text = mesaj.Aciklama;
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var iletisim = repo.Find(x => x.ID == 1);
            iletisim.Mail = TxtMail.Text;
            iletisim.Telefon = TxtTelefon.Text;
            iletisim.Koordinat = TxtKoordinat.Text;
            iletisim.Adress = TxtAdres.Text;
            iletisim.Aciklama = TxtAciklama.Text;
            repo.TUpdate(iletisim);
            XtraMessageBox.Show("Başarıyla Güncellendi.");

        }
    }
}
