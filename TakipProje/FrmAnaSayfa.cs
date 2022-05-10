using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TakipProje
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void Azalan()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd, sum(adet) as 'Miktar' From Tbl_Urunler Group By UrunAd Having sum(Adet) <= 20 Order By sum(adet)", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;


        }
        void Ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 5 NotTarih,NotSaat,NotBaslik From Tbl_Notlar Order By Notİd Desc", bgl.baglanti());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;

        }
        void firma()
        {
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareket2", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControlFirma.DataSource = dt;
        }

        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Telefon1 From Tbl_Firmalar", bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;

        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            Azalan();
            Ajanda();
            firma();
            fihrist();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/kurlar_tr.html");
        }
    }
}
