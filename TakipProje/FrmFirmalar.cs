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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * From Tbl_Firmalar",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void il()
        {
            SqlCommand komut = new SqlCommand("Select Sehir From Tbl_İller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİl.Properties.Items.Add(dr[0]);


            }
            bgl.baglanti().Close();


        }

        void temizle()
        {
            Txtİd.Text = "";
            TxtAd.Text = "";
            TxtYetkili.Text = "";
            YadSoyad.Text = "";
            MskTc.Text = "";
            TxtSektor.Text = "";
            MskTel1.Text = "";
            MskTel2.Text = "";
            MskTel3.Text = "";
            TxtMail.Text = "";
            MskFax.Text = "";
            TxtVergi.Text = "";
            RchAdres.Text = "";
            TxtKod1.Text = "";
            TxtKod2.Text = "";
            TxtKod3.Text = "";
            TxtAd.Focus();



        }
        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FirmaKod1 From Tbl_Kodlar ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                RchKod1.Text = dr[0].ToString();

            }bgl.baglanti().Close();


        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            listele();
            il();
            temizle();
            carikodaciklamalar();
            

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtİd.Text = dr["İd"].ToString();
                TxtAd.Text = dr["Ad"].ToString();
                TxtYetkili.Text = dr["YetkiliStatu"].ToString();
                YadSoyad.Text = dr["YetkiliAdSoyad"].ToString();
                MskTc.Text = dr["YetkiliTc"].ToString();
                TxtSektor.Text = dr["Sektor"].ToString();
                MskTel1.Text = dr["Telefon1"].ToString();
                MskTel2.Text = dr["Telefon2"].ToString();
                MskTel2.Text = dr["Telefon3"].ToString();
                TxtMail.Text = dr["Mail"].ToString();
                MskFax.Text = dr["Faks"].ToString();
                Cmbİl.Text= dr["İl"].ToString();
                Cmbİlce.Text = dr["İlce"].ToString();
                TxtVergi.Text = dr["VergiDaire"].ToString();
                RchAdres.Text= dr["Adres"].ToString();
                TxtKod1.Text = dr["OzelKod1"].ToString();
                TxtKod2.Text = dr["OzelKod2"].ToString();
                TxtKod3.Text = dr["OzelKod3"].ToString();





            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Firmalar " +
                "(Ad,YetkiliStatu,YetkiliAdSoyad,YetkiliTc,Sektor,Telefon1,Telefon2,Telefon3,Mail,Faks,İl,İlce,VergiDaire,Adres,OzelKod1," +
                "OzelKod2,OzelKod3) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());

            
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p3", YadSoyad.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p6", MskTel1.Text);
            komut.Parameters.AddWithValue("@p7", MskTel2.Text);
            komut.Parameters.AddWithValue("@p8", MskTel3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", MskFax.Text);
            komut.Parameters.AddWithValue("@p11", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p12", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", TxtKod1.Text);
            komut.Parameters.AddWithValue("@p16", TxtKod2.Text);
            komut.Parameters.AddWithValue("@p17", TxtKod3.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
            

        }

        private void Cmbİl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbİlce.Properties.Items.Clear();
            Cmbİlce.Text = "";
            SqlCommand komut = new SqlCommand("SELECT İlce From Tbl_İlceler Where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbİl.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİlce.Properties.Items.Add(dr[0]);

            }bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Firmalar where İd=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", Txtİd.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
            Cmbİl.Properties.Items.Clear();




        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Güncelleme Buton Komutları
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Firmalar SET Ad=@p1,YetkiliStatu=@p2,YetkiliAdSoyad=@p3,YetkiliTc=@p4,Sektor=@p5,Telefon1=@p6,Telefon2=@p7," +
                "Telefon3=@p8,Mail=@p9,Faks=@p10,İl=@p11,İlce=@p12,VergiDaire=@p13,Adres=@p14,OzelKod1=@p15,OzelKod2=@p16,OzelKod3=@p17 where İd=@p18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p3", YadSoyad.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p6", MskTel1.Text);
            komut.Parameters.AddWithValue("@p7", MskTel2.Text);
            komut.Parameters.AddWithValue("@p8", MskTel3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", MskFax.Text);
            komut.Parameters.AddWithValue("@p11", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p12", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", TxtKod1.Text);
            komut.Parameters.AddWithValue("@p16", TxtKod2.Text);
            komut.Parameters.AddWithValue("@p17", TxtKod3.Text);
            komut.Parameters.AddWithValue("@p18", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");
            listele();
            temizle();



        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
