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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Soyad,Telefon,Telefon2,Mail From Tbl_Musteriler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            listele();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select Ad,YetkiliAdSoyad,Telefon1,Telefon2,Telefon3,Mail,Faks From Tbl_Firmalar", bgl.baglanti());
            da1.Fill(dt1);
            gridControl2.DataSource = dt1;

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["Mail"].ToString();
                

            }
            frm.Show();

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail fr = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if(dr != null)
            {
                fr.mail = dr["Mail"].ToString();

            }
            fr.Show();
        }
    }
}
