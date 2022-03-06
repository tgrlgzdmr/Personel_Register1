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
    public partial class FrmGraphics : Form
    {
        public FrmGraphics()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-T4GE7A8\\SQLEXPRESS;Initial Catalog=PerconalDataBase;Integrated Security=True");

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmGraphics_Load(object sender, EventArgs e)
        {
            //Number of Personnal by Cities Graphic
            conn.Open();
            SqlCommand cmdg1 = new SqlCommand("Select PerCity,count(*) From Tbl_Personnal group by PerCity",conn);
            SqlDataReader dr1 = cmdg1.ExecuteReader();
            while(dr1.Read())
            {
                chart1.Series["Cities"].Points.AddXY(dr1[0],dr1[1]);
            }
            conn.Close();

            //Average Salary by Professions
            conn.Open();
            SqlCommand cmdg2 = new SqlCommand("Select PerProfession,Avg(PerSalary) From Tbl_Personnal group by PerProfession", conn);
            SqlDataReader dr2 = cmdg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Average Profession Salary"].Points.AddXY(dr2[0], dr2[1]);
            }
            conn.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
