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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-T4GE7A8\\SQLEXPRESS;Initial Catalog=PerconalDataBase;Integrated Security=True");

        void clean()
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtSurname.Text = "";
            CmbCity.Text = "";
            MskSalary.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtProfession.Text = "";
            TxtName.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonnalTableAdapter.Fill(this.perconalDataBaseDataSet.Tbl_Personnal);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            this.tbl_PersonnalTableAdapter.Fill(this.perconalDataBaseDataSet.Tbl_Personnal);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Personnal (PerName,PerSurname,PerCity,PerSalary,PerSituation,PerProfession) values (@p1,@p2,@p3,@p4,@p5,@p6)", conn);
            cmd.Parameters.AddWithValue("@p1", TxtName.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", CmbCity.Text);
            cmd.Parameters.AddWithValue("@p4", MskSalary.Text);
            cmd.Parameters.AddWithValue("@p5", label8.Text);
            cmd.Parameters.AddWithValue("@p6", TxtProfession.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Personnel added");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            TxtId.Text=dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtName.Text=dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            TxtSurname.Text=dataGridView1.Rows[chosen].Cells[2].Value.ToString();
            CmbCity.Text=dataGridView1.Rows[chosen].Cells[3].Value.ToString();
            MskSalary.Text=dataGridView1.Rows[chosen].Cells[4].Value.ToString();
            
            if ((bool)dataGridView1.Rows[chosen].Cells[5].Value)
            {
                radioButton1.Checked = true;
                
            }
            else
            {
                
                radioButton2.Checked=true;
            }
            TxtProfession.Text=dataGridView1.Rows[chosen].Cells[6].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmddel = new SqlCommand("Delete From Tbl_Personnal Where Perid=@k1",conn);
            cmddel.Parameters.AddWithValue("@k1",TxtId.Text);
            cmddel.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Register deleted");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmdupd = new SqlCommand("Update Tbl_Personnal Set PerName=@a1,PerSurname=@a2,PerCity=@a3,PerSalary=@a4,PerSituation=@a5,PerProfession=@a6 where Perid=@a7", conn);
            cmdupd.Parameters.AddWithValue("@a1", TxtName.Text);
            cmdupd.Parameters.AddWithValue("@a2", TxtSurname.Text);
            cmdupd.Parameters.AddWithValue("@a3", CmbCity.Text);
            cmdupd.Parameters.AddWithValue("@a4", MskSalary.Text);
            cmdupd.Parameters.AddWithValue("@a5", label8.Text);
            cmdupd.Parameters.AddWithValue("@a6", TxtProfession.Text);
            cmdupd.Parameters.AddWithValue("@a7", TxtId.Text);
            cmdupd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Register updated");
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            FrmStatistics fr=new FrmStatistics();
            fr.Show();
        }

        private void BtnGraphics_Click(object sender, EventArgs e)
        {
            FrmGraphics frg=new FrmGraphics();
            frg.Show();
        }
    }
}
