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
using DevExpress.XtraEditors;
using OtelYeniProje.Entities;

namespace OtelYeniProje.Formlar.Tanımlamalar
{
    public partial class FrmDurum : Form
    {
        public FrmDurum()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }


        DbOtelEntities2 db = new DbOtelEntities2();
        private void FrmDurum_Load(object sender, EventArgs e)
        {
            db.TblDurums.Load();
            bindingSource1.DataSource = db.TblDurums.Local;
                
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                XtraMessageBox.Show("Lütfen Değerleri kontrol edip yeniden giriş yapın.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void durumuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
