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
    public partial class FrmOnRezervasyonKarti : Form
    {
        public FrmOnRezervasyonKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();
        Repository<TblOnRezervasyon> repo = new Repository<TblOnRezervasyon>();
        public int id;

        private void FrmOnRezervasyonKarti_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var rezervasyon = repo.Find(x => x.ID == id);
                dateEditGiris.EditValue = rezervasyon.GirisTarih.ToString();
                dateEditCikis.EditValue = rezervasyon.CikisTarih.ToString();
                dateEditTarih.EditValue = rezervasyon.Tarih.ToString();
                TxtAciklama.Text = rezervasyon.Aciklama;
                TxtTelefon.Text = rezervasyon.Telefon;
                TxtMail.Text = rezervasyon.Mail;
                TxtAdSoyad.Text = rezervasyon.AdSoyad;
                if (rezervasyon.Kisi == null)
                {
                    numericUpDown1.Value = 1;
                }
                else
                {
                    numericUpDown1.Value = decimal.Parse(rezervasyon.Kisi.ToString());
                }
            }
        }
    }
}
