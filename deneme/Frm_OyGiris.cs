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
using System.Globalization;

namespace deneme
{
    public partial class Frm_OyGiris : Form
    {
        public Frm_OyGiris()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MCY\SQLEXPRESS;Initial Catalog=DBSECIMPROJE;Integrated Security=True");

        private void BtnOyGirisi_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into TBL_ILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@P1,@P2,@P3,@P4,@P5,@P6)", con);
            cmd.Parameters.AddWithValue("@P1",TxtIlcead.Text);
            cmd.Parameters.AddWithValue("@P2", TxtA.Text);
            cmd.Parameters.AddWithValue("@P3", TxtB.Text);
            cmd.Parameters.AddWithValue("@P4", TxtC.Text);
            cmd.Parameters.AddWithValue("@P5", TxtD.Text);
            cmd.Parameters.AddWithValue("@P6", TxtE.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("OY GİRİŞİ YAPILDI");
        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }
    }
}
