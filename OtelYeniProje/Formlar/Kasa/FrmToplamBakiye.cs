using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelYeniProje.Entities;
using OtelYeniProje.Repositories;

namespace OtelYeniProje.Formlar.Kasa
{
    public partial class FrmToplamBakiye : Form
    {
        public FrmToplamBakiye()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();

        public decimal alinantoplampara; // Giren -- müşteriden alınan para
        public decimal toplamkasatutar; // Bakiye --> toplam param
        public decimal alinacaktoplampara;
        public decimal resepsiyongider; // Cikan --> Resepsiyon giderleri

        private void FrmToplamBakiye_Load(object sender, EventArgs e)
        {
            // Toplam Kasa Tutarı Hesaplama
            toplamkasatutar = Decimal.Parse((from x in db.TblRezervasyons select x.Toplam).Sum().ToString());
            TxtToplamPara.Text = toplamkasatutar.ToString();

            // Alınan toplam ücreti gösterir
            alinantoplampara = Decimal.Parse((from x in db.TblRezervasyons select x.AlinanUcret).Sum().ToString());
            resepsiyongider = Decimal.Parse((from x in db.TblKasaHareketis select x.Tutar).Sum().ToString());
            TxtResepsiyonGider.Text = resepsiyongider.ToString();
            TxtAlinanPara.Text = (alinantoplampara - resepsiyongider).ToString();

            // Alınacak Toplam Ücreti Göstrerir.
            alinacaktoplampara = toplamkasatutar - alinantoplampara;
            TxtAlinacakPara.Text = alinacaktoplampara.ToString();
        }
    }
}
