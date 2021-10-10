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
    public partial class criteriaScore : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\DssPKL\DssPKL\PKL.mdf;Integrated Security=True");
        SqlDataAdapter adapt;
        SqlCommand cmd;
        
        public double[] final ;


        public criteriaScore()
        {
            InitializeComponent();
            panel1.BringToFront();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int indexRow = dataGridView2.CurrentCell.OwningRow.Index;
            int indexCell = dataGridView2.CurrentCell.OwningColumn.Index;

            if (indexRow+1 != indexCell)
            {
                if (trackBar1.Value == 1)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "9";
                }
                else if (trackBar1.Value == 2)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "7";
                }
                else if (trackBar1.Value == 3)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "5";
                }
                else if (trackBar1.Value == 4)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "3";
                }
                else if (trackBar1.Value == 5)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "1";
                }
                else if (trackBar1.Value == 6)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,333";
                }
                else if (trackBar1.Value == 7)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,200";
                }
                else if (trackBar1.Value == 8)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,142";
                }
                else if (trackBar1.Value == 9)
                {
                    dataGridView2.Rows[indexRow].Cells[indexCell].Value = "0,111";
                }
            }
            double tes = Convert.ToDouble(dataGridView2.Rows[indexRow].Cells[indexCell].Value);
            if (trackBar1.Value < 6)
            {
                double y = 1 / tes;
                dataGridView2.Rows[indexCell - 1].Cells[indexRow + 1].Value = (Math.Round((1 / tes), 3)).ToString();
            }
            else if (trackBar1.Value >= 6)
            {
                double convert = tes / 1000;
                dataGridView2.Rows[indexCell - 1].Cells[indexRow + 1].Value = (Convert.ToInt32(1 / convert)).ToString();
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView2.CurrentCell.OwningColumn.HeaderText.ToString();
            int var = dataGridView2.CurrentCell.OwningRow.Index;
            textBox1.Text = dataGridView2.Rows[var].Cells[0].Value.ToString();
        }

        public void count()
        {
            double[] score = new double[dataGridView1.RowCount];
            final = new double[dataGridView1.RowCount];
            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    score[i] += Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                }
                if(IndexForm.Text == "1")
                {
                    String y = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    String x = Math.Round((score[i] / dataGridView1.RowCount), 4).ToString();                    
                   
                }
                else if (IndexForm.Text == "2")
                {
                    final[i] = Math.Round((score[i] / dataGridView1.RowCount), 4);
                }
            }
        }

        private void done_Click(object sender, EventArgs e)
        {
            count();
            this.Close();
        }


        private void normalized_Click(object sender, EventArgs e)
        {
            normalization();
            panel2.BringToFront();
        }

        public void normalization()
        {
            double[] normalise = new double[dataGridView2.RowCount];
            int y = dataGridView2.RowCount;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                normalise[i] = (from DataGridViewRow row in dataGridView2.Rows
                                where row.Cells[i + 1].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[i + 1].FormattedValue)).Sum();
            }

            //DataTable dt = new DataTable();
            //adapt = new SqlDataAdapter("select CriteriaName from criterias", con);
            //adapt.Fill(dt);

            if (y >= 1)
            {
                
                dataGridView1.ColumnCount = dataGridView2.ColumnCount;
                dataGridView1.RowCount = dataGridView2.RowCount;
                dataGridView1.Columns[0].Name = " ";
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView1.Columns[i + 1].Name = dataGridView2.Columns[i + 1].Name;
                    dataGridView1.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells[0].Value.ToString();
                }

                for (int i = 1; i < dataGridView2.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView2.RowCount; j++)
                    {
                        double x = Convert.ToDouble(dataGridView2.Rows[j].Cells[i].Value) / normalise[i - 1];
                        dataGridView1.Rows[j].Cells[i].Value = x.ToString();
                    }
                }
                
            }
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void criteriaScore_Load(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            normalization();
            count();
            this.Close();
        }   

        private void IndexForm_Click(object sender, EventArgs e)
        {

        }
    }
}
