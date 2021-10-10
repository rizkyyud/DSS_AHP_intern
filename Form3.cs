using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DssPKL
{
    public partial class Form3 : Form
    {
        int score;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pKLDataSet.Criterias' table. You can move, or remove it, as needed.

        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void trackBar2_Scroll(object sender, EventArgs e)
        {
            score = trackBar2.Value;
            setScore();
        }

        public int setScore()
        {
            return score;
        }
    }
}
