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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\DssPKL\DssPKL\PKL.mdf;Integrated Security=True");
        SqlDataAdapter da;


        public Form2()
        {
            InitializeComponent();
            display();
        }

        private void criteria_Click(object sender, EventArgs e)
        {
            this.Hide();
            kriteriaProyek kp = new kriteriaProyek();
            kp.Show();
        }

        public void display()
        {
            SqlCommand cmd = new SqlCommand("select CriteriaName from criterias", con);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Id from criterias", con);
            da.Fill(dt);

            con.Open();
            dataGridView1.ColumnCount = (dt.Rows.Count)+1;
            dataGridView1.Columns[0].Name = "Candidate Name";
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                dataGridView1.Columns[i+1].Name = dt.Rows[i].ItemArray[0].ToString();
            }
            con.Close();        
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string tes;
            tes = dataGridView1.Rows[0].Cells[0].Value.ToString();
            MessageBox.Show(tes);
        }

        public void ahp()
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
