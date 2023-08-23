using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        private PictureBox[,] board;
        private int x, y;
        private bool flag = true;
        private Button b;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Button();
            b.Width = 150;
            b.Height = 50;
            this.Controls.Add(b);
            b.Click += b_Click;
            this.Width = 400;
            this.Height = 200;
            b.Location = new Point(110, 20);
            b.Text = "התחל";
            lab.Text = "";
            startOver.Visible = false;
            startOver.Text = "התחל מחדש";




        }

        void b_Click(object sender, EventArgs e)
        {
            b.Visible = false;
            comboBox1.Visible = false;
            this.Width = 600;
            this.Height = 650;
            board = new PictureBox[int.Parse(comboBox1.Text), int.Parse(comboBox1.Text)];
            x = 75;
            y = 100;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {

                    PictureBox t = new PictureBox();
                    t.Width = 450 / int.Parse(comboBox1.Text);
                    t.Height = 450 / int.Parse(comboBox1.Text);

                    t.Location = new Point(x, y);
                    t.BackColor = Color.Yellow;
                    t.BorderStyle = BorderStyle.Fixed3D;
                    t.SizeMode = PictureBoxSizeMode.StretchImage;
                    t.Click += t_Click;
                    t.Tag = 0;
                    this.Controls.Add(t);
                    board[i, j] = t;
                    x += 450 / int.Parse(comboBox1.Text);
                }
                y += 450 / int.Parse(comboBox1.Text);
                x = 75;
            }
        }

        void t_Click(object sender, EventArgs e)
        {
            bool flagche = true;
            bool flagF = true;
            if (((PictureBox)sender).Tag.Equals(1) || ((PictureBox)sender).Tag.Equals(2))
            {
                lab.Text = "המקום כבר תפוס תבחר מקום אחר";
            }
            else
            {
                if (flag == true)
                {
                    ((PictureBox)sender).Image = Image.FromFile("..\\..\\pic\\1.jpg");
                    flag = false;
                    ((PictureBox)sender).Tag = 1;
                    lab.Text = "";

                }
                else
                {
                    ((PictureBox)sender).Image = Image.FromFile("..\\..\\pic\\2.jpg");
                    flag = true;
                    ((PictureBox)sender).Tag = 2;
                    lab.Text = "";
                }

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    flagche = true;
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        if (!(board[i, j].Tag.Equals(((PictureBox)sender).Tag)))
                            flagche = false;
                    }
                    if (flagche == true)
                    {
                        startOver.Visible = true;
                        flagF = false;
                        if ((((PictureBox)sender)).Tag.Equals(1))
                            lab.Text = "איקס ניצח";
                        else
                            lab.Text = "עיגול ניצח";
                    }

                }
                if (flagF)
                {
                    for (int k = 0; k < board.GetLength(0); k++)
                    {
                        flagche = true;
                        for (int i = 0; i < board.GetLength(1); i++)
                        {
                            if (!(board[k, i].Tag.Equals(((PictureBox)sender).Tag)))
                                flagche = false;
                        }

                        if (flagche == true)
                        {
                            startOver.Visible = true;
                            flagF = false;
                            if ((((PictureBox)sender)).Tag.Equals(1))
                                lab.Text = "איקס ניצח";
                            else
                                lab.Text = "עיגול ניצח";
                        }
                    }
                }
                if (flagF)
                {
                   flagche = true;
                    for (int f = 0; f < board.GetLength(0); f++)
                    { 
                        if (!(board[f, f].Tag.Equals(((PictureBox)sender).Tag)))
                            flagche = false;
                    }
                    if (flagche == true)
                    {
                        startOver.Visible = true;
                        flagF = false;
                        if ((((PictureBox)sender)).Tag.Equals(1))
                            lab.Text = "איקס ניצח";
                        else
                            lab.Text = "עיגול ניצח";
                    }
                }
                if (flagF)
                {
                    flagche = true;
                    for (int w = 0; w < board.GetLength(0); w++)
                    {
                        if (!(board[w, (board.GetLength(0) - 1) - w].Tag.Equals(((PictureBox)sender).Tag)))
                            flagche = false;
                    }
                    if (flagche == true)
                    {
                        startOver.Visible = true;
                        flagF = false;
                        if ((((PictureBox)sender)).Tag.Equals(1))
                            lab.Text = "איקס ניצח";
                        else
                            lab.Text = "עיגול ניצח";
                    }
                }
            }
        }
        private void startOver_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].Image = null;
                    board[i, j].Tag= "";
                }
            }
            lab.Text = "";

        }
    }
}