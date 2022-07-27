using DevExpress.XtraEditors;
using OtelYeniProje.Entities;
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
    public partial class FrmUlke : Form
    {
        public FrmUlke()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        private void FrmUlke_Load(object sender, EventArgs e)
        {
            db.TblUlkes.Load();
            bindingSource1.DataSource = db.TblUlkes.Local;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            string cellValue = gridView1.GetFocusedDisplayText();
            try
            {
                 var ulkeitems = (from x in db.TblUlkes
                                 select new
                                 {
                                     x.UlkeAd
                                 }).Where(a => a.UlkeAd.ToString().Equals(cellValue)).FirstOrDefault();

                if (cellValue.ToLower().Equals(ulkeitems.UlkeAd.ToLower().ToString()))
                {
                    XtraMessageBox.Show("Bu ülke zaten eklenmiş", "Hoops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception)
            {
                db.SaveChanges();
                XtraMessageBox.Show("Başarıyla eklendi.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }
    }
}
