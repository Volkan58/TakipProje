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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_FaturaBilgi", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;



        }
        void temizle()
        {
            Txtİd.Text = "";
            TxtSeri.Text = "";
            TxtSira.Text = "";
            TxtTAlan.Text = "";
            TxtTEden.Text = "";
            TxtVergiD.Text = "";
            TxtAlici.Text = "";
            MskSaat.Text = "";
            MskTarih.Text = "";



        }
  

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();

        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            if (TxtFaturaİd.Text == "")
            {
                
                SqlCommand komut2 = new SqlCommand("INSERT INTO Tbl_FaturaBilgi (Seri,SiraNo,Tarih,Saat,VergiDaire,Alici,TeslimEden,TeslimAlan) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtSeri.Text);
                komut2.Parameters.AddWithValue("@p2", TxtSira.Text);
                komut2.Parameters.AddWithValue("@p3", MskTarih.Text);
                komut2.Parameters.AddWithValue("@p4", MskSaat.Text);
                komut2.Parameters.AddWithValue("@p5", TxtVergiD.Text);
                komut2.Parameters.AddWithValue("@p6", TxtAlici.Text);
                komut2.Parameters.AddWithValue("@p7", TxtTEden.Text);
                komut2.Parameters.AddWithValue("@p8", TxtTAlan.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgileri Eklendi.");
                listele();


            }if (TxtFaturaİd.Text!="")
       
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TxtFiyat.Text);
                miktar = Convert.ToDouble(TxtMiktar.Text);
                tutar = miktar * fiyat;
                TxtTutar.Text = tutar.ToString();
                

                SqlCommand komut = new SqlCommand("INSERT INTO Tbl_FaturaDetay (UrunAd,Miktar,Fiyat,Tutar,Faturaİd) VALUES (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtUrun.Text);
                komut.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
                komut.Parameters.AddWithValue("@p5", TxtFaturaİd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Detayları Eklendi");



            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtİd.Text = dr["FaturaBilgiİd"].ToString();
                TxtSeri.Text = dr["Seri"].ToString();
                TxtSira.Text = dr["SiraNo"].ToString();
                MskTarih.Text = dr["Tarih"].ToString();
                MskSaat.Text = dr["Saat"].ToString();
                TxtVergiD.Text = dr["VergiDaire"].ToString();
                TxtAlici.Text = dr["Alici"].ToString();
                TxtTEden.Text = dr["TeslimEden"].ToString();
                TxtTAlan.Text = dr["TeslimAlan"].ToString(); 
            }
        }

        private void BtnTemizle_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_FaturaBilgi where FaturaBilgiİd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Tbl_FaturaBilgi set Seri=@p1,SiraNo=@p2,Tarih=@p3,Saat=@p4,VergiDaire=@p5,Alici=@p6,TeslimEden=@p7,TeslimAlan=@p8 where FaturaBilgiİd=@p9 ", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
            komut.Parameters.AddWithValue("@p2", TxtSira.Text);
            komut.Parameters.AddWithValue("@p3", MskTarih.Text);
            komut.Parameters.AddWithValue("@p4", MskSaat.Text);
            komut.Parameters.AddWithValue("@p5", TxtVergiD.Text);
            komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
            komut.Parameters.AddWithValue("@p7", TxtTEden.Text);
            komut.Parameters.AddWithValue("@p8", TxtTAlan.Text);
            komut.Parameters.AddWithValue("@p9", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Güncellendi.");
            listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FaturaBilgiİd"].ToString();
            }fr.Show();
        }
    }
}
