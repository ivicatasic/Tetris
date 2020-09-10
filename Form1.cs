using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {

        public Button[,] kvadrati = new Button[9, 18];
        public Button[,] oblici = new Button[6, 6];
        public int brojac;
        public bool kombinacija1;
        public bool kombinacija2;
        public bool kombinacija3;
        public bool kombinacija4;
        public bool kombinacija5;
        public bool kombinacija6;

        //matrica sa 0 i 1, 0-slobodno polje za spustanje
        //1-zauzeto
        public int[,] matrica = new int[9, 18];
        public Form1()
        {
            brojac = 0;

            //na pocetku su sve 0, jer su sva polja slobodna
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 18; j++)
                {
                    matrica[i, j] = 0;
                }
            }


            kombinacija1 = false;
            kombinacija2 = false;
            kombinacija3 = false;
            kombinacija4 = false;
            kombinacija5 = false;
            kombinacija6 = false;

            InitializeComponent();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    kvadrati[i, j] = new Button();
                    kvadrati[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    kvadrati[i, j].Location = new System.Drawing.Point(2, 2);
                    kvadrati[i, j].Size = new System.Drawing.Size(26, 42);
                    kvadrati[i, j].Name = i.ToString() + " " + j.ToString();
                    kvadrati[i, j].TabIndex = 0;

                    kvadrati[i, j].UseVisualStyleBackColor = true;
                    this.tableLayoutPanel2.Controls.Add(kvadrati[i, j], j, i);
                    kvadrati[i, j].Click += new System.EventHandler(this.dugme_klik);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    oblici[i, j] = new Button();
                    oblici[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    oblici[i, j].Location = new System.Drawing.Point(3, 3);
                    oblici[i, j].Size = new System.Drawing.Size(26, 42);
                    oblici[i, j].Name = i.ToString() + " " + j.ToString();
                    oblici[i, j].TabIndex = 0;

                    oblici[i, j].UseVisualStyleBackColor = true;
                    this.tableLayoutPanel3.Controls.Add(oblici[i, j], j, i);
                    oblici[i, j].Click += new System.EventHandler(this.dugme2_klik);
                }
            }

        }

        public void dugme_klik(object sender, EventArgs e)
        {
            Button dugme = sender as Button;
            string s = dugme.Name;
            string[] sar = s.Split(' ');
            int i = Convert.ToInt32(sar[0]);
            int j = Convert.ToInt32(sar[1]);
            //kvadrati[i, j].BackColor = Color.White;

            if (kombinacija1)
            {
                for (int ii = 8; ii >= 0; --ii)
                {
                    if (j >= 15)
                    {
                        MessageBox.Show("Van opsega!");
                        break;
                    }
                    else
                    {
                        if (matrica[ii, j] == 0 && matrica[ii, j + 1] == 0 && matrica[ii, j + 2] == 0 && matrica[ii, j + 3] == 0)
                        {
                            kvadrati[ii, j].BackColor = Color.Red;
                            kvadrati[ii, j + 1].BackColor = Color.Red;
                            kvadrati[ii, j + 2].BackColor = Color.Red;
                            kvadrati[ii, j + 3].BackColor = Color.Red;

                            matrica[ii, j] = 1;
                            matrica[ii, j + 1] = 1;
                            matrica[ii, j + 2] = 1;
                            matrica[ii, j + 3] = 1;
                            break;
                        }
                    }
                }

            }

            if (kombinacija2)
            {
                for (int ii = 8; ii >= 0; --ii)
                {
                    if (j >= 18)
                    {
                        MessageBox.Show("Van opsega!");
                        break;
                    }
                    else
                    {
                        if(matrica[ii,j]==0 && matrica[ii-1,j]==0 && matrica[ii-2,j]==0 && matrica[ii - 3, j] == 0)
                        {
                            kvadrati[ii, j].BackColor = Color.Blue;
                            kvadrati[ii - 1, j].BackColor = Color.Blue;
                            kvadrati[ii - 2, j].BackColor = Color.Blue;
                            kvadrati[ii - 3, j].BackColor = Color.Blue;

                            matrica[ii, j] = 1;
                            matrica[ii - 1, j] = 1;
                            matrica[ii - 2, j] = 1;
                            matrica[ii - 3,j] = 1;
                            break;
                        }

                    }

                }

            }
            if (kombinacija3)
            {
                for(int ii = 8; ii >= 0; --ii)
                {
                    if (j >= 18)
                    {
                        MessageBox.Show("Van opsega!");
                        break;
                    }
                    else
                    {
                        if(matrica[ii,j]==0 && matrica[ii,j+1]==0 && matrica[ii-1, j+1]==0 && matrica[ii - 2, j+1] == 0)
                        {
                            kvadrati[ii, j].BackColor = Color.Green;
                            kvadrati[ii, j+1].BackColor = Color.Green;
                            kvadrati[ii - 1, j+1].BackColor = Color.Green;
                            kvadrati[ii - 2, j+1].BackColor = Color.Green;

                            matrica[ii, j ] = 1;
                            matrica[ii, j+1] = 1;
                            matrica[ii - 1, j+1] = 1;
                            matrica[ii - 2, j+1] = 1;
                            break;
                        }


                    }
                }
            }

            if (kombinacija4)
            {
                for (int ii = 8; ii >= 0; --ii)
                {
                    if (j >= 18 && ii>=8)
                    {
                        MessageBox.Show("Van opsega!");
                        break;
                    }
                    else
                    if(ii<8)
                    {
                        if (matrica[ii, j] == 0 && matrica[ii, j + 1] == 0 && matrica[ii, j+2]==0 && matrica[ii + 1, j + 2] == 0)
                        {
                            kvadrati[ii, j].BackColor = Color.Black;
                            kvadrati[ii, j + 1].BackColor = Color.Black;
                            kvadrati[ii, j + 2].BackColor = Color.Black;
                            kvadrati[ii + 1, j + 2].BackColor = Color.Black;

                            matrica[ii, j] = 1;
                            matrica[ii, j + 1] = 1;
                            matrica[ii, j + 2] = 1;
                            matrica[ii + 1, j + 2] = 1;
                            break;

                        }
                    }
                }
            }
            
            if (kombinacija5)
            {
                for (int ii = 8; ii >= 0; --ii)
                {
                    if (j >= 18 && ii >= 6)
                    {
                        MessageBox.Show("Van opsega!");
                        break;
                    }
                    else
                    if (ii < 6)
                    {
                        if (matrica[ii, j] == 0 && matrica[ii, j + 1] == 0 && matrica[ii+1, j] == 0 && matrica[ii + 2, j] == 0)
                        {
                            kvadrati[ii, j].BackColor = Color.Yellow;
                            kvadrati[ii, j + 1].BackColor = Color.Yellow;
                            kvadrati[ii+1, j].BackColor = Color.Yellow;
                            kvadrati[ii + 2, j].BackColor = Color.Yellow;

                            matrica[ii, j] = 1;
                            matrica[ii, j + 1] = 1;
                            matrica[ii+1, j] = 1;
                            matrica[ii + 2, j] = 1;
                            break;

                        }
                    }
                }
                
            }
            
            if (kombinacija6)
            {
                for (int ii = 8; ii >= 0; --ii)
                {
                    if (j >= 18 && ii >= 8)
                    {
                        MessageBox.Show("Van opsega!");
                        break;
                    }
                    else
                    if (ii < 8)
                    {
                        if (matrica[ii, j] == 0 && matrica[ii, j + 1] == 0 && matrica[ii, j+2] == 0 && matrica[ii -1, j] == 0)
                        {
                            kvadrati[ii, j].BackColor = Color.Pink;
                            kvadrati[ii, j + 1].BackColor = Color.Pink;
                            kvadrati[ii , j+2].BackColor = Color.Pink;
                            kvadrati[ii -1, j].BackColor = Color.Pink;

                            matrica[ii, j] = 1;
                            matrica[ii, j + 1] = 1;
                            matrica[ii, j+2] = 1;
                            matrica[ii -1, j] = 1;
                            break;

                        }
                    }
                }

            }

    


        }




        public void dugme2_klik(object sender, EventArgs e)
        {
            Button dugme = sender as Button;
            string s = dugme.Name;
            string[] sar = s.Split(' ');
            int i = Convert.ToInt32(sar[0]);
            int j = Convert.ToInt32(sar[1]);
            oblici[i, j].BackColor = Color.Gray;
            int p = 2;
            
            if (brojac == 7)
            {
                brojac = 0;
            }

            brojac++;

            for (int ii = 0; ii < 6; ii++)
            {
                for (int jj = 0; jj < 6; jj++)
                {
                    oblici[ii, jj].BackColor = Color.Gray;
                }
            }

            if (brojac == 1) {
                for (int ii = p; ii < p + 1; ii++)
                {
                    for (int jj = p; jj < p + 4; jj++)
                    {
                        oblici[ii, jj].BackColor = Color.Red;
                    }
                }
                kombinacija1 = true;
                kombinacija2 = false;
                kombinacija3 = false;
                kombinacija4 = false;
                kombinacija5 = false;
                kombinacija6 = false;

            }

            if (brojac == 2)
            {

                for (int ii = p; ii < p + 4; ii++)
                {
                    for (int jj = p; jj < p + 1; jj++)
                    {
                        oblici[ii, jj].BackColor = Color.Blue;
                    }
                }

                kombinacija1 = false;
                kombinacija2 = true;
                kombinacija3 = false;
                kombinacija4 = false;
                kombinacija5 = false;
                kombinacija6 = false;

            }

            if (brojac == 3)
            {
                for (int ii = p; ii < p + 3; ii++)
                {
                    for (int jj = p; jj < p + 1; jj++)
                    {
                        oblici[ii, jj].BackColor = Color.Red;
                    }
                    oblici[p + 2, p - 1].BackColor = Color.Red;
                }

                kombinacija1 = false;
                kombinacija2 = false;
                kombinacija3 = true;
                kombinacija4 = false;
                kombinacija5 = false;
                kombinacija6 = false;

            }

            if (brojac == 4)
            {
                for (int ii = p; ii < p + 1; ii++)
                {
                    for (int jj = p; jj < p + 3; jj++)
                    {
                        oblici[ii, jj].BackColor = Color.Red;

                    }
                    oblici[p + 1, p + 2].BackColor = Color.Red;
                }

                kombinacija1 = false;
                kombinacija2 = false;
                kombinacija3 = false;
                kombinacija4 = true;
                kombinacija5 = false;
                kombinacija6 = false;

            }
            if (brojac == 5)
            {
                for (int ii = p; ii < p + 3; ii++)
                {
                    for (int jj = p; jj < p + 1; jj++)
                    {
                        oblici[ii, jj].BackColor = Color.Red;
                    }
                    oblici[p, p + 1].BackColor = Color.Red;
                }

                kombinacija1 = false;
                kombinacija2 = false;
                kombinacija3 = false;
                kombinacija4 = false;
                kombinacija5 = true;
                kombinacija6 = false;
            }
            if (brojac == 6)
            {
                for (int ii = p; ii < p + 1; ii++)
                {
                    for (int jj = p; jj < p + 3; jj++)
                    {
                        oblici[ii, jj].BackColor = Color.Green;
                    }
                    oblici[p - 1, p].BackColor = Color.Green;
                }

                kombinacija1 = false;
                kombinacija2 = false;
                kombinacija3 = false;
                kombinacija4 = false;
                kombinacija5 = false;
                kombinacija6 = true;
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(theDialog.FileName);

            }
        }
            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
            SaveFileDialog saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                //savucaj igru
                StreamWriter writer = new StreamWriter(saveDialog.FileName);
            }

            }

            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Open Text File";
                theDialog.Filter = "TXT files|*.txt";
                theDialog.InitialDirectory = @"C:\Users\student\Desktop\Ivica Tasic 50";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    //ucitaj sacuvanu igru
                }
            }



        
    }        
    
}

