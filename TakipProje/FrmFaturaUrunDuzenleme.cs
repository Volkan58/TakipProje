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
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        public string urunid;
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            TxtUrunİd.Text = urunid;
            SqlCommand komut = new SqlCommand("Select * From Tbl_FaturaDetay where FaturaUrunİd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunİd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtFiyat.Text = dr[3].ToString();
                TxtMiktar.Text = dr[2].ToString();
                TxtTutar.Text = dr[4].ToString();
                TxtUrun.Text = dr[1].ToString();
                bgl.baglanti().Close();

            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Tbl_FaturaDetay SET UrunAd=@p1,Miktar=@p2,Fiyat=@p3,Tutar=@p4 where FaturaUrunİd=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrun.Text);
            komut.Parameters.AddWithValue("@p2", double.Parse(TxtMiktar.Text));
            komut.Parameters.AddWithValue("@p3", double.Parse(TxtFiyat.Text));
            komut.Parameters.AddWithValue("@p4",double.Parse( TxtTutar.Text));
            komut.Parameters.AddWithValue("@p5", TxtUrunİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme İşlemi Tamamlandı");

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete FROM Tbl_FaturaDetay Where FaturaUrunİd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");

        }
    }
}
