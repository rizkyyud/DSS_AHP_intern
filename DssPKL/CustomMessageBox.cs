﻿using System;
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
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        public Image MessageIcon
        {
            get{ return pictureBox1.Image; }
            set{ pictureBox1.Image = value; }
        }
        public string Message
        {
            get { return message.Text; }
            set { message.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
