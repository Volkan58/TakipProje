using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakipProje
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }
        FrmUrunler fr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null) { 
            
            fr = new FrmUrunler();
            fr.MdiParent = this;
            fr.Show();
            }
        }

        FrmMusteriler fr1;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed) { 
            fr1 = new FrmMusteriler();
            fr1.MdiParent = this;
            fr1.Show();
            }
        }
        FrmFirmalar fr3;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed) { 
             fr3 = new FrmFirmalar();
            fr3.MdiParent = this;

            fr3.Show();
            }
        }
        FrmPersoneller fr4;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FrmPersoneller();
                fr4.MdiParent = this;
                fr4.Show();

            }
        }
        FrmRehber fr5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null|| fr5.IsDisposed)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        FrmGiderler fg;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fg == null || fg.IsDisposed)
            {
                fg = new FrmGiderler();
                fg.MdiParent = this;
                fg.Show();

            }

        }

        FrmBankalar fb;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fb == null || fb.IsDisposed) { 
            fb = new FrmBankalar();
            fb.MdiParent = this;
            fb.Show();
            }
        }

        FrmNotlar fn;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fn == null || fn.IsDisposed)
            {
                fn = new FrmNotlar();
                fn.MdiParent = this;
                fn.Show();

            }
        }
        FrmStoklar frs;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frs == null || frs.IsDisposed)
            {
                frs = new FrmStoklar();
                frs.MdiParent = this;
                frs.Show();


            }
        }

        Ayarlar fra;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fra == null || fra.IsDisposed)
            {
                fra = new Ayarlar();
                
                fra.Show();

            }
        }

        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            if (fran == null || fran.IsDisposed)
            {
                fran = new FrmAnaSayfa();
                fran.MdiParent = this;
                fran.Show();


            }
        }

        FrmFaturalar frmftr;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmftr == null || frmftr.IsDisposed)
            {
                frmftr = new FrmFaturalar();
                frmftr.MdiParent = this;
                frmftr.Show();

            }

        }

        FrmHareketler frh;
        private void BtnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frh == null || frh.IsDisposed) { 
            frh = new FrmHareketler();
                frh.MdiParent = this;
                frh.Show();
            }
        }

        FrmRaporlar frp;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { if (frp == null || frp.IsDisposed) { 
            frp = new FrmRaporlar();
            frp.MdiParent = this;
            frp.Show();
            }
        }
        FrmAnaSayfa fran;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fran == null || fran.IsDisposed)
            {
                fran = new FrmAnaSayfa();
                fran.MdiParent = this;
                fran.Show();


            }

        }
    }
}
