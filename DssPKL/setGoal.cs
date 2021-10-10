using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DssPKL
{
    public partial class setGoal : Form
    {
        public setGoal()
        {
            InitializeComponent();

        }
        void SaveData()
        {
            for(int i = 0; i < 400; i++)
            {
                Thread.Sleep(10);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
           if(textBox1.Text == "")
            {
                MyMessageBox.ShowMessage("Please Fill Your Goal !","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                Form2 kp = new Form2();
                kp.goal.Text = textBox1.Text;
                
                using(waitingDialog wd = new waitingDialog(SaveData))
                {
                    wd.ShowDialog(this);
                    kp.TopMost = true;
                    kp.Show();
                    this.Close();
                }
            }            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
