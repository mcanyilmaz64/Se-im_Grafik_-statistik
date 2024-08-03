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

namespace deneme
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MCY\SQLEXPRESS;Initial Catalog=DBSECIMPROJE;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            // ilçe adlarını combobox a çekme

            con.Open();
            SqlCommand cmd = new SqlCommand("Select ILCEAD from TBL_ILCE", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0]);
            
            }
            con.Close();

            // GRAFİĞE SONUÇLARI GETİRME
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) from TBL_ILCE",con);

            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTI",dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTI",dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTI",dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTI",dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTI",dr2[4]);
            }
            con.Close();

            

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_ILCE where ILCEAD=@P1", con);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                LblA.Text = dr[2].ToString();
                LblB.Text = dr[3].ToString();
                LblC.Text = dr[4].ToString();
                LblD.Text = dr[5].ToString();
                LblE.Text = dr[6].ToString();
            }
            con.Close();

        }
    }
}
