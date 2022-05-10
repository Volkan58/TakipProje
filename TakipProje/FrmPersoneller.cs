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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Personeller", bgl.baglanti());
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

            }bgl.baglanti().Close();


        }
        void temizle()
        {
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            TxtGorev.Text = "";
            MskTc.Text = "";
            MskTel1.Text = "";
            RchAdres.Text = "";
            Cmbİl.Text = "";
            Cmbİlce.Text = "";

        }


        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            listele();
            il();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Personel Ekleme Kodları.
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Personeller (Ad,Soyad,Telefon,Tc,Mail,İl,İlce,Adres,Gorev) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTel1.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p7", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

            temizle();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Personel Silme Kodları
            SqlCommand komut = new SqlCommand("Delete From Tbl_Personeller Where İd=@p1",bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", Txtİd.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
            temizle();



        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtİd.Text = dr[0].ToString();
            TxtAd.Text = dr[1].ToString();
            TxtSoyad.Text = dr[2].ToString();
            MskTel1.Text = dr[3].ToString();
            MskTc.Text = dr[4].ToString();
            TxtMail.Text = dr[5].ToString();
            Cmbİl.Text = dr[6].ToString();
            Cmbİlce.Text = dr[7].ToString();
            RchAdres.Text = dr[8].ToString();
            TxtGorev.Text = dr[9].ToString();



        }

        private void Cmbİl_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Cmbİlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select İlce From Tbl_İlceler where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbİl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {

                Cmbİlce.Properties.Items.Add(dr[0]);


            }bgl.baglanti().Close();



        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        { //Personel Güncelleme Kodları.
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Personeller set Ad=@p1,Soyad=@p2,Telefon=@p3,Tc=@p4,Mail=@p5,İl=@p6,İlce=@p7,Adres=@p8,Gorev=@p9 Where İd=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTel1.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p7", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGorev.Text);
            komut.Parameters.AddWithValue("@p10", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");
            listele();
            temizle();
        }
    }
}
