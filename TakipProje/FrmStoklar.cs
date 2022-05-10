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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd,Sum(Adet) as 'Miktar' From Tbl_Urunler Group By UrunAd", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            //Chart veri Taşıma
            SqlCommand komut = new SqlCommand("Select UrunAd,Sum(Adet) as 'Miktar' From Tbl_Urunler Group By UrunAd", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }bgl.baglanti().Close();

            //Charta Firma Şehir Sayısı Çekme

            SqlCommand komut2 = new SqlCommand("SELECT İl,Count(*) as Miktar FROM Tbl_Firmalar GROUP BY İl", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]),int.Parse(dr2[1].ToString()));
            }bgl.baglanti().Close();

        }
    }
}
