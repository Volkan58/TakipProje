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
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Admin", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;



        }
        void temizle()
        {
            TxtKullanici.Text = "";
            TxtSifre.Text = "";

        }
        private void Ayarlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKaydet.Text == "Kaydet") { 
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Admin (KullaniciAd,Sifre) VALUES (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kullanıcı Eklendi");
            listele();
            temizle();
            }
            if (BtnKaydet.Text == "Güncelle")
            {
                SqlCommand komut2 = new SqlCommand("Update Tbl_Admin set Sifre=@p1 Where KullaniciAd=@p2",bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtSifre.Text);
                komut2.Parameters.AddWithValue("@p2", TxtKullanici.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Şifre Güncelleme Tamamlandı");
                listele();
                temizle();



            }
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtKullanici.Text = dr["KullaniciAd"].ToString();
                TxtSifre.Text = dr["Sifre"].ToString();


            }
        }

        private void TxtKullanici_TextChanged(object sender, EventArgs e)
        {
            if (TxtKullanici.Text !="")
            {
                BtnKaydet.Text = "Güncelle";
                BtnKaydet.BackColor = Color.Red;
            }else
            {
                BtnKaydet.Text = "Kaydet";
                BtnKaydet.BackColor = Color.Green;
            }
        }
    }
}
