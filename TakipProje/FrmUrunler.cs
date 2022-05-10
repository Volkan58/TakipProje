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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Urunler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //veri Ekleme İşlemi 
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Urunler (UrunAd,Marka,Model,Yil,Adet,Alisfiyat,Satisfiyat,Detay) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
           
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(NudAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydetme İşlemi Tamamlandı");




        }

        private void BtnSil_Click(object sender, EventArgs e)
        {// Veri Silme İşlemi
            SqlCommand komut2 = new SqlCommand("Delete From Tbl_Urunler where İd=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", Txtİd.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi" , "Bilgi" , MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        { // Ürün Güncelleme İşlemi.
            SqlCommand komut3 = new SqlCommand("UPDATE  Tbl_Urunler SET UrunAd=@p1,Marka=@p2,Model=@p3,Yil=@p4,Adet=@p5,Alisfiyat=@p6,Satisfiyat=@p7,Detay=@p8 where İd=@p9", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut3.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut3.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut3.Parameters.AddWithValue("@p4", MskYil.Text);
            komut3.Parameters.AddWithValue("@p5",int.Parse(NudAdet.Value.ToString()) );
            komut3.Parameters.AddWithValue("@p6", double.Parse(TxtAlis.Text));
            komut3.Parameters.AddWithValue("@p7", double.Parse(TxtSatis.Text));
            komut3.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut3.Parameters.AddWithValue("@p9", Txtİd.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme İşlemi Tamamlandı", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);





        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtİd.Text = dr["İd"].ToString();
            TxtAd.Text = dr["UrunAd"].ToString();
            TxtMarka.Text = dr["Marka"].ToString();
            TxtModel.Text = dr["Model"].ToString();
            MskYil.Text = dr["Yil"].ToString();
            NudAdet.Value = int.Parse(dr["Adet"].ToString());
            TxtAlis.Text = dr["Alisfiyat"].ToString();
            TxtSatis.Text = dr["Satisfiyat"].ToString();
            RchDetay.Text = dr["Detay"].ToString();



        }
    }
}
