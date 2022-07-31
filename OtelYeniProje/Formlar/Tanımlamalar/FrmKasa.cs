using OtelYeniProje.Entities;
using OtelYeniProje.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYeniProje.Formlar.Tanımlamalar
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        Repository<TblKasa> repo = new Repository<TblKasa>();
        

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            //Resepsiyon güncelleme işlemi
            { 
                var resepsiyon = repo.Find(x => x.KasaID == 3);
                decimal alinantoplampara = Decimal.Parse((from x in db.TblRezervasyons select x.AlinanUcret).Sum().ToString());
                decimal toplamkasatutar = Decimal.Parse((from x in db.TblRezervasyons select x.Toplam).Sum().ToString());
                decimal resepsiyongider = Decimal.Parse((from x in db.TblKasaHareketis select x.Tutar).Sum().ToString());
                decimal alinacaktoplampara = toplamkasatutar - alinantoplampara;
                //Giren
                resepsiyon.Giren = alinantoplampara - (resepsiyongider + alinacaktoplampara);
                //Bakiye
                resepsiyon.Bakiye = toplamkasatutar;
                //Cikan
                resepsiyon.Cikan = resepsiyongider + alinacaktoplampara;
                repo.TUpdate(resepsiyon);
            }

            //Market güncelleme işlemi
            { 
                //Bakiye
                var market = repo.Find(x => x.KasaID == 1);
                decimal bakiye = 0;
                var bakiyelistesi = (from x in db.TblUruns
                              select new
                              {
                                  x.UrunID,
                                  x.Fiyat,
                                  x.Toplam
                              }).ToList();
                foreach (var item in bakiyelistesi)
                {
                    bakiye += Decimal.Parse(item.Fiyat.ToString()) * Decimal.Parse(item.Toplam.ToString());
                }
                market.Bakiye = bakiye;
                //Giren
                decimal giren = 0;
                decimal cikan = 0;
                var girenlistesi = (from x in db.TblUrunHarekets
                                    select new
                                    {
                                        x.HareketID,
                                        x.Miktar,
                                        x.Urun,
                                        x.TblUrun.Fiyat,
                                        x.HareketTuru
                                    }).ToList();
                foreach (var item in girenlistesi)
                {
                    if(item.HareketTuru == "Giriş")
                    {
                        giren += Decimal.Parse(item.Fiyat.ToString()) * Decimal.Parse(item.Miktar.ToString());
                    }
                    else if(item.HareketTuru == "Çıkış")
                    {
                        cikan += Decimal.Parse(item.Fiyat.ToString()) * Decimal.Parse(item.Miktar.ToString());
                    }
                }
                market.Giren = giren;
                market.Cikan = cikan;
                repo.TUpdate(market);
            }


            // Yükleme kısmı
            db.TblKasas.Load();
            //bindingSource1.DataSource = db.TblKasas.Local;
            bindingSource1.DataSource = (from x in db.TblKasas
                                         select new
                                         {
                                             x.KasaID,
                                             x.KasaAdi,
                                             x.Durum,
                                             x.Bakiye,
                                             x.Giren,
                                             x.Cikan
                                         }).Where(x => x.KasaID != 2).ToList();
            
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurums
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAd
                                                        }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }
    }
}
