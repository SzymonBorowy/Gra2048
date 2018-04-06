using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra2048
{
    public partial class Test : Form
    {
        public int[,] tablicaWartosci;
        private int wielkoscPlanszy;
        private PictureBox[,] tablicaPictureBox;
        private Label[,] tablicaLabel;
        private int wynik;

        public Test(int wielkosc)
        {
            InitializeComponent();

            this.wielkoscPlanszy = wielkosc;
            tablicaWartosci = new int[wielkosc, wielkosc];
            tablicaPictureBox = new PictureBox[wielkosc, wielkosc];
            tablicaLabel = new Label[wielkosc, wielkosc];
            wynik = 0;
            start();
            
        }

        enum Kolory
        {
            jasnoszary =0,
            szary = 2,
            ciemnoszary = 4,
            pomaranczowy = 8,
            ciemnopomaranczowy = 16,
            czerwony = 32,
            ciemnoczerwony = 64,
            zolty1 = 128,
            zolty2 = 256,
            zolty3 = 512,
            zielony = 1024,
            czarny = 2048
        }
        private Color ustawKolorEnuma(Kolory kolor)
        {
            Color k = new Color();
            switch (kolor)
            {
                case Kolory.jasnoszary:
                    k = Color.LightGray;
                    break;
                case Kolory.szary:
                    k = Color.Gray;
                    break;
                case Kolory.ciemnoszary:
                    k = Color.DarkGray;
                    break;
                case Kolory.pomaranczowy:
                    k = Color.Orange;
                    break;
                case Kolory.ciemnopomaranczowy:
                    k = Color.DarkOrange;
                    break;
                case Kolory.czerwony:
                    k = Color.Red;
                    break;
                case Kolory.ciemnoczerwony:
                    k = Color.DarkRed;
                    break;
                case Kolory.zolty1:
                    k = Color.IndianRed;
                    break;
                case Kolory.zolty2:
                    k = Color.Yellow;
                    break;
                case Kolory.zolty3:
                    k = Color.YellowGreen;
                    break;
                case Kolory.zielony:
                    k = Color.Green;
                    break;
                case Kolory.czarny:
                    k = Color.Black;
                    break;
            }
            return k;
        }

        private void start()
        {
            Size rozmiar = new Size(50, 50);
            panel1.Size = new Size(10 + rozmiar.Width * wielkoscPlanszy + 5 * (wielkoscPlanszy - 1) + 10, 10 + rozmiar.Height * wielkoscPlanszy + 5 * (wielkoscPlanszy - 1) + 10);

            for (int i = 0; i < wielkoscPlanszy; i++)
            {
                for (int j = 0; j < wielkoscPlanszy; j++)
                {
                    tablicaWartosci[i, j] = 0;
                    tablicaPictureBox[i, j] = new PictureBox
                    {
                        Size = new Size(50, 50),
                        BackColor = Color.LightGray,
                        Location = new Point(10 + rozmiar.Width * j + 5 * j, 10 + rozmiar.Height * i + 5 * i)
                    };
                    tablicaLabel[i, j] = new Label
                    {
                        Text = "",
                        AutoSize = true,
                        BackColor = Color.LightGray,
                        ForeColor = Color.White,
                        Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                        Location = new Point(10 + rozmiar.Width * j + 5 * j, 10 + rozmiar.Height * i + 5 * i + 15)
                    };
                }
            }
            tablicaWartosci[0, 0] = 2;
            tablicaWartosci[1, 0] = 4;
            tablicaWartosci[2, 0] = 8;
            tablicaWartosci[3, 0] = 16;
            tablicaWartosci[4, 0] = 32;
            tablicaWartosci[0, 1] = 64;
            tablicaWartosci[1, 1] = 128;
            tablicaWartosci[2, 1] = 256;
            tablicaWartosci[3, 1] = 512;
            tablicaWartosci[4, 1] = 1024;
            tablicaWartosci[0, 2] = 2048;
            losuj();
            losuj();
            dodajKwadratyDoformy();
            wyswietl();
        }
        private void losuj()
        {
            Random rnd = new Random();
            int i;
            int j;
            do
            {
                i = rnd.Next(0, wielkoscPlanszy);
                j = rnd.Next(0, wielkoscPlanszy);
            } while (tablicaWartosci[i, j] != 0);
            tablicaWartosci[i, j] = 2;


        }

        private void Test_KeyDown(object sender, KeyEventArgs e)
        {
            bool losujPoUdanymRuchu = false;
            if(e.KeyCode == Keys.Down)
            {
                losujPoUdanymRuchu = moveDown();
            }
            else if (e.KeyCode == Keys.Up)
            {
                losujPoUdanymRuchu = moveUp();
            }
            else if (e.KeyCode == Keys.Left)
            {
                losujPoUdanymRuchu = moveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                losujPoUdanymRuchu = moveRight();
            }
            if (losujPoUdanymRuchu)
                losuj();
            wyswietl();
        }
        public void swap(int i1, int j1, char kierunek)
        {
            switch (kierunek)
            {
                case 'd':
                    var tmp = tablicaWartosci[i1, j1];
                    tablicaWartosci[i1, j1] = tablicaWartosci[i1 + 1, j1];
                    tablicaWartosci[i1 + 1, j1] = tmp;

                    break;
                case 'u':
                    tmp = tablicaWartosci[i1, j1];
                    tablicaWartosci[i1, j1] = tablicaWartosci[i1 - 1, j1];
                    tablicaWartosci[i1 - 1, j1] = tmp;

                    break;
                case 'l':
                    tmp = tablicaWartosci[i1, j1];
                    tablicaWartosci[i1, j1] = tablicaWartosci[i1, j1-1];
                    tablicaWartosci[i1, j1-1] = tmp;

                    break;
                case 'r':
                    tmp = tablicaWartosci[i1, j1];
                    tablicaWartosci[i1, j1] = tablicaWartosci[i1 , j1+1];
                    tablicaWartosci[i1, j1+1] = tmp;

                    break;
            }
        }
        public bool moveDown()
        {
            bool czySwap = false;
            for (int i = wielkoscPlanszy-2; i >=0; i--)
            {
                for (int j = wielkoscPlanszy-1; j >=0; j--)
                {
                    wyswietl();
                    int k = i;
                    if (tablicaWartosci[i, j] > 1 && tablicaWartosci[i + 1, j] < 1)
                    {
                        do
                        {
                            swap(k, j, 'd');
                            czySwap = true;
                            k++;
                        } while (k < wielkoscPlanszy - 1 && tablicaWartosci[k + 1, j] < 1);
                    }

                    if(k<wielkoscPlanszy-1)
                    {
                        if(tablicaWartosci[k, j] == tablicaWartosci[k+1, j])
                        {
                            tablicaWartosci[k + 1, j] += tablicaWartosci[k, j];
                            tablicaWartosci[k, j] = 0;
                            wynik += tablicaWartosci[k + 1, j];
                        }
                    }
                    wyswietl();
                }
            }
            return czySwap;
        }
        public bool moveUp()
        {
            bool czySwap = false;
            for (int i = 1; i <wielkoscPlanszy ; i++)
            {
                for (int j = 0; j < wielkoscPlanszy; j++)
                {
                    wyswietl();
                    int k = i;
                    if (tablicaWartosci[i, j] > 1 && tablicaWartosci[i - 1, j] < 1)
                    {
                        do
                        {
                            swap(k, j, 'u');
                            czySwap = true;
                            k--;
                        } while (k >0 && tablicaWartosci[k - 1, j] < 1);
                    }

                    if (k >0)
                    {
                        if (tablicaWartosci[k, j] == tablicaWartosci[k - 1, j])
                        {
                            tablicaWartosci[k - 1, j] += tablicaWartosci[k, j];
                            tablicaWartosci[k, j] = 0;
                            wynik += tablicaWartosci[k - 1, j];
                        }
                    }
                    wyswietl();
                }
            }
            return czySwap;
        }
        public bool moveLeft()
        {
            bool czySwap = false;
            for (int j =1; j<wielkoscPlanszy; j++)
            {
                for (int i = 0; i <wielkoscPlanszy; i++)
                {
                    wyswietl();
                    int k = j;
                    if (tablicaWartosci[i, j] > 1 && tablicaWartosci[i, j - 1] < 1)
                    {
                        do
                        {
                            swap(i, k, 'l');
                            czySwap = true;
                            k--;
                        } while (k >0 && tablicaWartosci[i, k - 1] < 1);
                    }

                    if (k >0)
                    {
                        if (tablicaWartosci[i, k] == tablicaWartosci[i, k - 1])
                        {
                            tablicaWartosci[i, k - 1] += tablicaWartosci[i, k];
                            tablicaWartosci[i, k] = 0;
                            wynik += tablicaWartosci[i, k-1];
                        }
                    }
                    wyswietl();
                }
            }
            return czySwap;
        }
        public bool moveRight()
        {
            bool czySwap = false;
            for (int j = wielkoscPlanszy - 2; j >= 0; j--)
            {
                for (int i = wielkoscPlanszy - 1; i >= 0; i--)
                {
                    wyswietl();
                    int k = j;
                    if (tablicaWartosci[i, j] > 1 && tablicaWartosci[i, j+1] < 1)
                    {
                        do
                        {
                            swap(i, k, 'r');
                            czySwap = true;
                            k++;
                        } while (k < wielkoscPlanszy - 1 && tablicaWartosci[i, k+1] < 1);
                    }

                    if (k < wielkoscPlanszy - 1)
                    {
                        if (tablicaWartosci[i, k] == tablicaWartosci[i, k + 1])
                        {
                            tablicaWartosci[i, k + 1] += tablicaWartosci[i, k];
                            tablicaWartosci[i, k] = 0;
                            wynik += tablicaWartosci[i, k + 1];
                        }
                    }
                    wyswietl();
                }
            }
            return czySwap;
        }

        private void wyswietl()
        {
            for (int i = 0; i < wielkoscPlanszy; i++)
            {
                for (int j = 0; j < wielkoscPlanszy; j++)
                {
                    tablicaPictureBox[i, j].BackColor = ustawKolorEnuma((Kolory)tablicaWartosci[i, j]);
                    tablicaLabel[i, j].BackColor = ustawKolorEnuma((Kolory)tablicaWartosci[i, j]);
                    tablicaLabel[i, j].Text = tablicaWartosci[i, j].ToString();
                    
                }
            }
            label1.Text = wynik.ToString();
        }

        private void dodajKwadratyDoformy()
        {
            for (int i = 0; i < wielkoscPlanszy; i++)
            {
                for (int j = 0; j < wielkoscPlanszy; j++)
                {
                    panel1.Controls.Add(tablicaPictureBox[i,j]);
                    panel1.Controls.Add(tablicaLabel[i, j]);
                    tablicaLabel[i, j].BringToFront();
                }
            }
            panel1.Refresh();
        }
    }
}
