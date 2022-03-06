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

namespace Personel_Register1
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-T4GE7A8\\SQLEXPRESS;Initial Catalog=PerconalDataBase;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            //Total Number of Personnal
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("Select Count(*) From Tbl_Personnal",conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while(dr1.Read())
            {
                LblTotalPer.Text=dr1[0].ToString();
            }
            conn.Close();

            //Total Number of Married Personnal
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Select Count(*) From Tbl_Personnal Where PerSituation=1", conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                LblTotalMarPer.Text = dr2[0].ToString();
            }
            conn.Close();

            //Total Number of Single Personnal
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select Count(*) From Tbl_Personnal Where PerSituation=0", conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                LblTotalSinPer.Text = dr3[0].ToString();
            }
            conn.Close();

            //Total Number of Different City
            conn.Open();
            SqlCommand cmd4 = new SqlCommand("Select Count(Distinct PerCity) From Tbl_Personnal", conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                LblTotalDifCity.Text = dr4[0].ToString();
            }
            conn.Close();

            //Total Salary
            conn.Open();
            SqlCommand cmd5 = new SqlCommand("Select Sum(PerSalary) From Tbl_Personnal", conn);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                LblTotalSalary.Text = dr5[0].ToString();
            }
            conn.Close();

            //Avarage Salary
            conn.Open();
            SqlCommand cmd6 = new SqlCommand("Select Avg(PerSalary) From Tbl_Personnal", conn);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                LblAvgSalary.Text = dr6[0].ToString();
            }
            conn.Close();
        }
    }
}
