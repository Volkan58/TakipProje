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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
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

        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select İd,Ad From Tbl_Firmalar", bgl.baglanti());
            da.Fill(dt);
            lkFirma.Properties.NullText = "Lütfen Firma Seçiniz";
            lkFirma.Properties.ValueMember = "İd";
            lkFirma.Properties.DisplayMember = "Ad";
            lkFirma.Properties.DataSource = dt;
            


        }
        void temizle()
        {
            Txtİd.Text = "";
            TxtBankaAd.Text = "";
            TxtHesapNo.Text = "";
            TxtHesapTuru.Text = "";
            TxtSube.Text = "";
            TxtYetkili.Text = "";
            Txtİban.Text = "";
            Cmbİl.Text = "";
            Cmbİlce.Text = "";
            MskTarih.Text = "";
            MskTelefon.Text = "";


        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();
            il();
            firmalistesi();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Bankalar (BankaAd,İl,İlce,Sube,İban,HesapNo,Yetkili,Telefon,Tarih,HesapTuru,Firmaİd) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TxtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p3", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p4", TxtSube.Text);
            komut.Parameters.AddWithValue("@p5", Txtİban.Text);
            komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p9", MskTarih.Text);
            komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lkFirma.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            temizle();
            MessageBox.Show("Kayıt Eklendi");
            

        }

        private void Cmbİl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbİlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select İlce From Tbl_İlceler where Sehir=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", Cmbİl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                Cmbİlce.Properties.Items.Add(dr[0]);
            }bgl.baglanti().Close();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtİd.Text = dr["İd"].ToString();
                TxtBankaAd.Text = dr["BankaAd"].ToString();
                Cmbİl.Text = dr["İl"].ToString();
                Cmbİlce.Text = dr["İlce"].ToString();
                TxtSube.Text = dr["Sube"].ToString();
                Txtİban.Text = dr["İban"].ToString();
                TxtHesapNo.Text = dr["HesapNo"].ToString();
                TxtYetkili.Text = dr["Yetkili"].ToString();
                MskTelefon.Text = dr["Telefon"].ToString();
                MskTarih.Text = dr["Tarih"].ToString();
                TxtHesapTuru.Text = dr["HesapTuru"].ToString();
                
                

            }
           
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Bankalar Where İd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
            temizle();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("UPDATE Tbl_Bankalar set  BankaAd=@p1,İl=@p2,İlce=@p3,Sube=@p4,İban=@p5,HesapNo=@p6,Yetkili=@p7,Telefon=@p8,Tarih=@p9,HesapTuru=@p10,Firmaİd=@p12 where İd=@p11", bgl.baglanti());


            komut.Parameters.AddWithValue("@p1", TxtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p3", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p4", TxtSube.Text);
            komut.Parameters.AddWithValue("@p5", Txtİban.Text);
            komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p9", MskTarih.Text);
            komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p12", lkFirma.EditValue);
            komut.Parameters.AddWithValue("@p11", Txtİd.Text);
            
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
