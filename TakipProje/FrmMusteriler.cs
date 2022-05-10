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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Musteriler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            
        }
        void İl()
        {
            SqlCommand komut = new SqlCommand("SELECT Sehir From Tbl_İller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİl.Properties.Items.Add(dr[0]);
            }bgl.baglanti().Close();
        }
        
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {

            listele();

            İl();




        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        { // Veri Ekleme.
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Musteriler (Ad,Soyad,Telefon,Telefon2,Tc,Mail,İl,İlce,Adres,VergiDaire) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@b1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTel1.Text);
            komut.Parameters.AddWithValue("@p4", MskTel2.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p8", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p9", RchAdres.Text);
            komut.Parameters.AddWithValue("@b1", TxtVergi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void Cmbİl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbİlce.Properties.Items.Clear();
            SqlCommand komut2 = new SqlCommand("SELECT İlce From Tbl_İlceler where Sehir=@p1 ", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", Cmbİl.SelectedIndex+1);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                Cmbİlce.Properties.Items.Add(dr[0]);

            }bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Musteriler where İd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            
            MessageBox.Show("Müşteri Kaydı Silindi");
            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) { 
            Txtİd.Text = dr["İd"].ToString();
            TxtAd.Text = dr["Ad"].ToString();
            TxtSoyad.Text = dr["Soyad"].ToString();
            MskTel1.Text = dr["Telefon"].ToString();
            MskTel2.Text = dr["Telefon2"].ToString();
            MskTc.Text = dr["Tc"].ToString();
            TxtMail.Text = dr["Mail"].ToString();
            Cmbİl.Text = dr["İl"].ToString();
            Cmbİlce.Text = dr["İlce"].ToString();
            RchAdres.Text = dr["Adres"].ToString();
            TxtVergi.Text = dr["VergiDaire"].ToString();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        { // Güncelleme İşlemi
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Musteriler SET Ad=@p1,Soyad=@p2,Telefon=@p3,Telefon2=@p4,Tc=@p5,Mail=@p6,İl=@p7,İlce=@p8,Adres=@p9,VergiDaire=@p10 where İd=@p11", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTel1.Text);
            komut.Parameters.AddWithValue("@p4", MskTel2.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p8", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p9", RchAdres.Text);
            komut.Parameters.AddWithValue("@p10", TxtVergi.Text);
            komut.Parameters.AddWithValue("@p11", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            
            MessageBox.Show("Müşteri Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
