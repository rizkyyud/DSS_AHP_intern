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

namespace DssPKL
{
    public partial class kriteriaProyek : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\DssPKL\DssPKL\PKL.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        double score;

        public kriteriaProyek()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (txtCriteria.Text != "")
            {
                cmd = new SqlCommand("insert into Criterias(CriteriaCode,CriteriaName) values(@code,@criteria)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@code", txtId.Text);
                cmd.Parameters.AddWithValue("@criteria", txtCriteria.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Input Successfull !!");
                display();
                displayScore();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete Criterias where CriteriaName = @criteria", con);
            con.Open();
            cmd.Parameters.AddWithValue("@criteria", txtCriteria.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully!");
            display();
            displayScore();
            ClearData();
        }

        //Update Record  

        private void edit_Click(object sender, EventArgs e)
        {
            if (txtCriteria.Text != "")
            {
                cmd = new SqlCommand("update Criterias set CriteriaName=@name where CriteriaCode=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.Parameters.AddWithValue("@name", txtCriteria.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                display();
                displayScore();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        public void display()
        {
            DataTable dt = new DataTable();
            con.Open();
            adapt = new SqlDataAdapter("select * from Criterias", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txtCriteria.Text = "";
            txtId.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = this.dataGridView1.Rows[e.RowIndex];
                txtId.Text = Row.Cells["CriteriaCode"].Value.ToString();
                txtCriteria.Text = Row.Cells["CriteriaName"].Value.ToString();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = this.dataGridView1.Rows[e.RowIndex];
                txtId.Text = Row.Cells["CriteriaCode"].Value.ToString();
                txtCriteria.Text = Row.Cells["CriteriaName"].Value.ToString();
            }
        }

        private void candidate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void displayScore()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select CriteriaName from criterias", con);
            adapt.Fill(dt);

            con.Open();
            dataGridView2.ColumnCount = (dt.Rows.Count) + 1;
            dataGridView2.RowCount = (dt.Rows.Count);
            dataGridView2.Columns[0].Name = "Criteria";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView2.Columns[i + 1].Name = dt.Rows[i].ItemArray[0].ToString();
                dataGridView2.Rows[i].Cells[0].Value = dt.Rows[i].ItemArray[0].ToString();
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int j = i + 1;
                dataGridView2.Rows[i].Cells[j].Value = "1";
                dataGridView2.Rows[i].Cells[j].ReadOnly = true;
                j++;
            }
            con.Close();
        }

        private void kriteriaProyek_Load(object sender, EventArgs e)
        {
            display();
            displayScore();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.textBox2.Text = dataGridView2.CurrentCell.OwningColumn.HeaderText.ToString();
            int var = dataGridView2.CurrentCell.OwningRow.Index;
            f3.textBox1.Text = dataGridView2.Rows[var].Cells[0].Value.ToString();
            f3.TopMost = true;
            f3.ShowDialog();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox3.Text = dataGridView2.CurrentCell.OwningColumn.HeaderText.ToString();
            int var = dataGridView2.CurrentCell.OwningRow.Index;
            textBox1.Text = dataGridView2.Rows[var].Cells[0].Value.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int indexRow = dataGridView2.CurrentCell.OwningRow.Index;
            int indexCell = dataGridView2.CurrentCell.OwningColumn.Index;
            if (trackBar1.Value == 1)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "9";
                dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "0,111";
            }
            else if (trackBar1.Value == 2)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "7";
                dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "0,142";
            }
            else if (trackBar1.Value == 3)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "5";
                
                    dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "0,2";
                
                
                
            }
            else if (trackBar1.Value == 4)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "3";
                
                    dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "0,333";
                
                
            }
            else if (trackBar1.Value == 5)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "1";
                
                    dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "1";
               
                
            }
            else if (trackBar1.Value == 6)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,333";
                
                    dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "3";
                
                
            }
            else if (trackBar1.Value == 7)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,2";
                
                    dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "5";
                
                
            }
            else if (trackBar1.Value == 8)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,142";
                dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "7";
                
                
            }
            else if (trackBar1.Value == 9)
            {
                dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,111";
                
                    dataGridView2.Rows[indexCell-1].Cells[indexRow + 1].Value = "9";
                
            }
        }
    }
}
