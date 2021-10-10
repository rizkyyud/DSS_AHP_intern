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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Windows.Forms.DataVisualization.Charting;

namespace DssPKL
{
    public partial class Form2 : Form
    {
        public double[] final1;

        public Form2()
        {
            InitializeComponent();
            panel15.SendToBack();

        }        

        int indexRow;
        int indexRow2;
        int indexRow3;

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pKLDataSet.Criterias' table. You can move, or remove it, as needed.
            sidePanel.Height = cr.Height;
            sidePanel.Top = cr.Top;
            panel2.BringToFront();            
        }

        private void ClearData()
        {
            txtId.Text = "";
            txtCriteria.Text = "";
            alternativeName.Text = "";
            alternativeCode.Text = "";
        }

        ///////////Criteria//////////

        private void refresh_Click(object sender, EventArgs e)
        {

            chart1.Series["Criteria"].Points.Clear();
            if (dataGridView1.Rows.Count >= 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string name = dataGridView1.Rows[i].Cells["Column2"].Value.ToString();
                    chart1.Series["Criteria"].Points.AddXY(name, Convert.ToDouble(dataGridView1.Rows[i].Cells["Column3"].Value));
                }
            }

        }

        private void scoring_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.Rows.Count >= 1)
            {
                int x = dataGridView1.Rows.Count - 1;
                dataGridView6.ColumnCount = (dataGridView1.Rows.Count);
                dataGridView6.RowCount = (dataGridView1.Rows.Count - 1);
                dataGridView6.Columns[0].Name = "Criteria";
                for (int i = 0; i < x; i++)
                {
                    dataGridView6.Columns[i + 1].Name = dataGridView1.Rows[i].Cells["Column2"].Value.ToString();
                    dataGridView6.Rows[i].Cells[0].Value = dataGridView1.Rows[i].Cells["Column2"].Value.ToString();
                }

                for (int i = 0; i < x; i++)
                {
                    int j = i + 1;
                    dataGridView6.Rows[i].Cells[j].Value = "1";
                    dataGridView6.Rows[i].Cells[j].ReadOnly = true;
                    j++;
                }
            }
            panel14.BringToFront();
            //cs.TopMost = true;
            //cs.Show();
            IndexForm.Text = "1";
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (txtCriteria.Text != "")
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtId.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtCriteria.Text;
                dataGridView1.Rows[n].Cells[2].Value = 0;
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (txtCriteria.Text != "")
            {

                DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
                newDataRow.Cells["Column1"].Value = txtId.Text;
                newDataRow.Cells["Column2"].Value = txtCriteria.Text;
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = this.dataGridView1.Rows[e.RowIndex];
                txtId.Text = Row.Cells["Column1"].Value.ToString();
                txtCriteria.Text = Row.Cells["Column2"].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow Row = dataGridView1.Rows[indexRow];
            txtId.Text = Row.Cells["Column1"].Value.ToString();
            txtCriteria.Text = Row.Cells["Column2"].Value.ToString();
        }
        ///////////////////////////////

        /////Alternative Function/////
        private void insert1_Click(object sender, EventArgs e)
        {

            if (alternativeCode.Text != "" && alternativeName.Text != "")
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = alternativeCode.Text;
                dataGridView2.Rows[n].Cells[1].Value = alternativeName.Text;
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void edit1_Click(object sender, EventArgs e)
        {
            if (alternativeCode.Text != "" && alternativeName.Text != "")
            {

                DataGridViewRow newDataRow = dataGridView2.Rows[indexRow];
                newDataRow.Cells["Column4"].Value = alternativeCode.Text;
                newDataRow.Cells["Column5"].Value = alternativeName.Text;
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(rowIndex);
        }

        private void Result_Click(object sender, EventArgs e)
        {
            panel7.BringToFront();
            sidePanel.Height = Alternative.Height;
            sidePanel.Top = Alternative.Top;

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = this.dataGridView2.Rows[indexRow2];
                alternativeCode.Text = Row.Cells["Column4"].Value.ToString();
                alternativeName.Text = Row.Cells["Column5"].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow2 = e.RowIndex;
            DataGridViewRow Row = dataGridView2.Rows[indexRow2];
            alternativeCode.Text = Row.Cells["Column4"].Value.ToString();
            alternativeName.Text = Row.Cells["Column5"].Value.ToString();
        }


        private void load_Click(object sender, EventArgs e)
        {
            dataGridView3.RowCount = dataGridView1.Rows.Count - 1;
            dataGridView3.ColumnCount = 2;
            dataGridView3.Columns[0].Name = "Criteria";
            dataGridView3.Columns[1].Name = "Status";
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells[0].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                dataGridView3.Rows[i].Cells[1].Value = "Not Set";
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IndexForm.Text = "2";
            panel14.BringToFront();          
            if (dataGridView2.Rows.Count >= 1)
            {
                
                int y = dataGridView2.Rows.Count - 1;
                dataGridView6.ColumnCount = (dataGridView2.Rows.Count);
                dataGridView6.RowCount = (dataGridView2.Rows.Count - 1);
                dataGridView2.Columns[0].Name = "Alternative";
                for (int i = 0; i < y; i++)
                {
                    dataGridView6.Columns[i + 1].Name = dataGridView2.Rows[i].Cells["Column5"].Value.ToString();
                    dataGridView6.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells["Column5"].Value.ToString();
                }

                for (int i = 0; i < y; i++)
                {
                    int j = i + 1;
                    dataGridView6.Rows[i].Cells[j].Value = "1";
                    dataGridView6.Rows[i].Cells[j].ReadOnly = true;
                    j++;
                }

                 indexRow3 = e.RowIndex;     
            }
            else
            {
                MyMessageBox.ShowMessage("Please Fill Alternative !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        ////////////////////////////////
        

        ////////////Result////////////
        private void Ranking_Click(object sender, EventArgs e)
        {
            int i;            
            double[] final_scr = new double[dataGridView2.Rows.Count - 1];

            for (i = 0; i < dataGridView4.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView4.RowCount; j++)
                {
                    double divide = Convert.ToDouble(dataGridView1.Rows[j].Cells[2].Value);
                    final_scr[i] += (Convert.ToDouble(dataGridView4.Rows[j].Cells[i].Value)) * divide;
                }

            }

            dataGridView5.RowCount = dataGridView2.Rows.Count-1;
            for (i = 0; i < final_scr.Length; i++)
            {
                dataGridView5.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells[1].Value.ToString();
                dataGridView5.Rows[i].Cells[1].Value = final_scr[i].ToString();
            }
            chartS();
            final.BringToFront();
            sidePanel.Height = button4.Height;
            sidePanel.Top = button4.Top;
        }

        public void chartS()
        {
            chart2.Series["Alternative"].Points.Clear();
            if (dataGridView5.Rows.Count >= 1)
            {
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    string name = dataGridView5.Rows[i].Cells[0].Value.ToString();
                    string tambahan = name + "\n" +dataGridView5.Rows[i].Cells[1].Value.ToString();
                    chart2.Series["Alternative"].Points.AddXY(tambahan, Convert.ToDouble(dataGridView5.Rows[i].Cells[1].Value));
                }
            }
        }
        ////////////////////////////////

        /////////Scoring Data///////////
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int indexRow = dataGridView6.CurrentCell.OwningRow.Index;
            int indexCell = dataGridView6.CurrentCell.OwningColumn.Index;

            if (indexRow + 1 != indexCell)
            {
                if (trackBar2.Value == 1)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "9";
                }
                else if (trackBar2.Value == 2)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "7";
                }
                else if (trackBar2.Value == 3)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "5";
                }
                else if (trackBar2.Value == 4)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "3";
                }
                else if (trackBar2.Value == 5)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "1";
                }
                else if (trackBar2.Value == 6)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "0,333";
                }
                else if (trackBar2.Value == 7)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "0,200";
                }
                else if (trackBar2.Value == 8)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "0,142";
                }
                else if (trackBar2.Value == 9)
                {
                    dataGridView6.Rows[indexRow].Cells[indexCell].Value = "0,111";
                }
            }
            double tes = Convert.ToDouble(dataGridView6.Rows[indexRow].Cells[indexCell].Value);
            if (trackBar2.Value < 6)
            {
                double y = 1 / tes;
                dataGridView6.Rows[indexCell - 1].Cells[indexRow + 1].Value = (Math.Round((1 / tes), 3)).ToString();
            }
            else if (trackBar2.Value >= 6)
            {
                double convert = tes / 1000;
                dataGridView6.Rows[indexCell - 1].Cells[indexRow + 1].Value = (Convert.ToInt32(1 / convert)).ToString();
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView6.CurrentCell.OwningColumn.HeaderText.ToString();
            int var = dataGridView6.CurrentCell.OwningRow.Index;
            textBox1.Text = dataGridView6.Rows[var].Cells[0].Value.ToString();
        }

        public void normalization()
        {

            double[] normalise = new double[dataGridView6.RowCount];
            int y = dataGridView6.RowCount;
            for (int i = 0; i < dataGridView6.RowCount; i++)
            {
                normalise[i] = (from DataGridViewRow row in dataGridView6.Rows
                                where row.Cells[i + 1].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[i + 1].FormattedValue)).Sum();
            }

            if (y >= 1)
            {

                dataGridView7.ColumnCount = dataGridView6.ColumnCount;
                dataGridView7.RowCount = dataGridView6.RowCount;
                dataGridView7.Columns[0].Name = " ";
                for (int i = 0; i < dataGridView6.RowCount; i++)
                {
                    dataGridView7.Columns[i + 1].Name = dataGridView6.Columns[i + 1].Name;
                    dataGridView7.Rows[i].Cells[0].Value = dataGridView6.Rows[i].Cells[0].Value.ToString();
                }

                for (int i = 1; i < dataGridView6.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView6.RowCount; j++)
                    {
                        double x = Convert.ToDouble(dataGridView6.Rows[j].Cells[i].Value) / normalise[i - 1];
                        dataGridView7.Rows[j].Cells[i].Value = x.ToString();
                    }
                }


            }
        }

        private void normalize_Click(object sender, EventArgs e)
        {
            normalization();
            panel16.BringToFront();
        }

        public void count()
        {
            double[] score = new double[dataGridView7.RowCount];
            final1 = new double[dataGridView7.RowCount];
            dataGridView4.RowCount = dataGridView1.Rows.Count;

            for (int i = 0; i < dataGridView7.RowCount; i++)
            {
                for (int j = 1; j < dataGridView7.ColumnCount; j++)
                {
                    score[i] += Convert.ToDouble(dataGridView7.Rows[i].Cells[j].Value);
                }
                if (IndexForm.Text == "1")
                {
                    String y = dataGridView7.Rows[i].Cells[0].Value.ToString();
                    String x = Math.Round((score[i] / dataGridView7.RowCount), 4).ToString();
                    dataGridView1.Rows[i].Cells[2].Value = x;
                    double[] tes = { 0, 0, 0.58, 0.9, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49 };
                    double[] cr = new double[dataGridView6.RowCount-1];
                    for(int k = 1; k < dataGridView6.ColumnCount;k++)
                    {
                        double htg =0;
                        for(int l = 1; l < dataGridView6.RowCount;l++)
                        {

                            htg += Convert.ToDouble(dataGridView6.Rows[l].Cells[k].Value) * tes[2]; 
                        }
                        cr[i] = htg;
                    }
                    panel2.BringToFront();
                    dataGridView6.Rows.Clear();
                }
                else if (IndexForm.Text == "2")
                {
                    
                    dataGridView4.ColumnCount = final1.Length;
                    final1[i] = Math.Round((score[i] / dataGridView7.RowCount), 4);
                    for(int j = 0; j < final1.Length; j++)
                    {
                        dataGridView4.Rows[indexRow3].Cells[j].Value = final1[j].ToString();
                    }                                       
                    dataGridView3.Rows[indexRow3].Cells[1].Value = final1.Length;                                        
                    panel7.BringToFront();
                    dataGridView6.Rows.Clear();
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            normalization();
            count();
        }

        private void done_Click(object sender, EventArgs e)
        {
            count();
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            panel14.BringToFront();
        }
        ///////////////////////////////////////////////////// 


        ////button function/////
        private void btnCriteria_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            sidePanel.Height = cr.Height;
            sidePanel.Top = cr.Top;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel7.BringToFront();
            sidePanel.Height = Alternative.Height;
            sidePanel.Top = Alternative.Top;
        }

        private void Alternative_Click(object sender, EventArgs e)
        {
            panel7.BringToFront();
            sidePanel.Height = Alternative.Height;
            sidePanel.Top = Alternative.Top;

        }

        private void cr_Click(object sender, EventArgs e)
        {
            sidePanel.Height = cr.Height;
            sidePanel.Top = cr.Top;
            panel2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button4.Height;
            sidePanel.Top = button4.Top;
            Ranking_Click(sender, e);
            final.BringToFront();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }
        /////////////////////////////////////////////////

        //////Save File///////
        private void save_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Font pfont1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font pfont2 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font pfont3 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            Paragraph titel = new Paragraph("Result", pfont1);
            titel.Alignment = Element.ALIGN_CENTER;
            Paragraph goals = new Paragraph("Goal : " + goal.Text + "\n\n", pfont2);
            goals.Alignment = Element.ALIGN_CENTER;
            Paragraph tabelCr = new Paragraph("Tabel Criteria\n", pfont3);
            tabelCr.Alignment = Element.ALIGN_LEFT;
            Paragraph tabelAl = new Paragraph("Tabel Alternative Final Score\n", pfont3);
            tabelAl.Alignment = Element.ALIGN_LEFT;
            Paragraph sp = new Paragraph("  ");

            var chartImageAl = new MemoryStream();
            chart2.SaveImage(chartImageAl, ChartImageFormat.Png);
            iTextSharp.text.Image chart_image = iTextSharp.text.Image.GetInstance(chartImageAl.GetBuffer());

            PdfPTable crTb = new PdfPTable(dataGridView1.Columns.Count);
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                crTb.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
            }
            crTb.HeaderRows = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    if (dataGridView1[k, i].Value != null)
                    {
                        crTb.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                    }
                }
            }

            //tabel Alternative
            PdfPTable alTb = new PdfPTable(dataGridView5.Columns.Count);
            for (int j = 0; j < dataGridView5.Columns.Count; j++)
            {
                alTb.AddCell(new Phrase(dataGridView5.Columns[j].HeaderText));
            }
            alTb.HeaderRows = 1;
            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView5.Columns.Count; k++)
                {
                    if (dataGridView5[k, i].Value != null)
                    {
                        alTb.AddCell(new Phrase(dataGridView5[k, i].Value.ToString()));
                    }
                }
            }

            var saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".pdf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(titel);
                    pdfDoc.Add(goals);
                    pdfDoc.Add(tabelCr);
                    pdfDoc.Add(sp);
                    pdfDoc.Add(crTb);
                    pdfDoc.Add(tabelAl);
                    pdfDoc.Add(sp);
                    pdfDoc.Add(alTb);
                    pdfDoc.Add(chart_image);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }       
    }
}

    
