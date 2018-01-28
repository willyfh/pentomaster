using System;
using System.Drawing;
using System.Drawing.Drawing2D;

//class yang menghandle ke dua belas pentomino
namespace Project1
{
    class Pentominos
    {
        private int[,] matrix; //matrix untuk bentuk pentomino
        private int urutan; //urutan pentomino pada insial pentomino
        private int index; // jenis pentomino berdasarkan index
        private int jumlahrotate; // jumlah putaran +flip yang dapat dilakukan pentomino
        public SolidBrush pentominosbrush; // untuk warna
        public int turn; //berapakali putaran sudah dilakukan
        public int posX; //posisi pentomino
        public int posY;
        public Boolean placed=false; //apakah sudah ditempatkan pada board atau belum

        //constructor
        public Pentominos()
        {
            matrix = new int[5, 5];
            turn = 0;
        }

      
        //set posisi
        public void SetPos(int iX, int iY)
        {
            posX = iX;
            posY = iY;
        }
        //membuat pentomino berdasarkan jenisnya/bentuk
        public void Createpentominos(int ipentominosType, int ur)
        {
            switch (ipentominosType)
            {
                case 12:
                    matrix[0, 0] = 0;
                    matrix[1, 0] = 1;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 1;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 12;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.DarkRed);
                    jumlahrotate = 8;
                    break;
                case 11:
                    matrix[0, 0] = 0;
                    matrix[1, 0] = 1;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 1;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 0;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 11;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.Chocolate);
                    jumlahrotate = 1;
                    break;
                case 10:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 0;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 0;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 1;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 10;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.GreenYellow);
                    jumlahrotate = 4;
                    break;
                case 9:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 1;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 0;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 0;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 1;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.Crimson);
                    index = 9;
                    jumlahrotate = 4;
                    break;
                case 8:
                    matrix[0, 0] = 0;
                    matrix[1, 0] = 1;
                    matrix[2, 0] = 1;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 0;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 8;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.Lavender);
                    jumlahrotate = 8;
                    break;

                case 7:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 0;
                    matrix[2, 0] = 1;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 1;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 0;
                    matrix[1, 2] = 0;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 7;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.Magenta);
                    jumlahrotate = 4;
                    break;
                case 6:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 0;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 0;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 1;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 1;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 6;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.Cyan);
                    jumlahrotate = 4;
                    break;
                case 5:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 1;
                    matrix[2, 0] = 1;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 0;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 0;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 0;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 5;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.PaleGoldenrod);
                    jumlahrotate = 4;
                    break;
                case 4:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 0;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 0;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 1;
                    matrix[1, 2] = 0;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 1;
                    matrix[1, 3] = 1;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 4;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.DarkOrange);
                    jumlahrotate = 8;
                    break;
                case 3:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 0;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 1;
                    matrix[1, 2] = 0;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 1;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 3;
                    urutan= ur;
                    pentominosbrush = new SolidBrush(Color.HotPink);
                    jumlahrotate = 8;
                    break;
                case 2:
                    matrix[0, 0] = 0;
                    matrix[1, 0] = 1;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 0;
                    matrix[1, 1] = 1;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 1;
                    matrix[1, 2] = 1;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 1;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 0;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 2;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.ForestGreen);
                    jumlahrotate = 8;
                    break;
                case 1:
                    matrix[0, 0] = 1;
                    matrix[1, 0] = 0;
                    matrix[2, 0] = 0;
                    matrix[3, 0] = 0;
                    matrix[4, 0] = 0;

                    matrix[0, 1] = 1;
                    matrix[1, 1] = 0;
                    matrix[2, 1] = 0;
                    matrix[3, 1] = 0;
                    matrix[4, 1] = 0;

                    matrix[0, 2] = 1;
                    matrix[1, 2] = 0;
                    matrix[2, 2] = 0;
                    matrix[3, 2] = 0;
                    matrix[4, 2] = 0;

                    matrix[0, 3] = 1;
                    matrix[1, 3] = 0;
                    matrix[2, 3] = 0;
                    matrix[3, 3] = 0;
                    matrix[4, 3] = 0;

                    matrix[0, 4] = 1;
                    matrix[1, 4] = 0;
                    matrix[2, 4] = 0;
                    matrix[3, 4] = 0;
                    matrix[4, 4] = 0;
                    index = 1;
                    urutan = ur;
                    pentominosbrush = new SolidBrush(Color.LightGreen);
                    jumlahrotate = 2;
                    break;
            }

        }

       //method untuk get
        public int getJRotate()
        {
            return jumlahrotate;
        }
        public int GetX()
        {
            return posX;
        }

        public int GetY()
        {
            return posY;
        }


       
        public int GetWidth()
        {
            int Greater = 0;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (i > Greater)
                            Greater = i;
                    }
                }
            }

            return (Greater + 1) * 25;
        }


        public int GetWidthM()
        {
            int Greater = 0;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (i > Greater)
                            Greater = i;
                    }
                }
            }

            return (Greater + 1);
        }

        public int GetHeight()
        {
            int Greater = 0;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (j > Greater)
                            Greater = j;
                    }
                }
            }

            return (Greater + 1) * 25;

        }

        public int GetHeightM()
        {
            int Greater = 0;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (j > Greater)
                            Greater = j;
                    }
                }
            }

            return (Greater + 1);

        }
        //apakah pentomino berada pada posisi iX, iY
        public bool atPos(int iX, int iY)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (iX == posX + (i * 25) && iY == posY + (j * 25))
                            return true;
                    }
                }
            }

            return false;
        }

        //get  & set
        public int[,] getMatrix()
        {
            return matrix;
        }

        public Boolean getPlaced()
        {
            return placed;
        }

        public void setPlaced(Boolean pl)
        {
            placed = pl;
        }

        public int getIndex()
        {
            return index;
        }

        public int getUrutan()
        {
            return urutan;
        }

        //melakukan flip pada pentomino
        public void Flippentomino()
        {
            int[,] TmpMatrix = new int[5, 5];
            int i, j;

            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    TmpMatrix[j, i] = matrix[4 - j, i];
                }
            }

            while (TmpMatrix[0, 0] == 0 &&
                TmpMatrix[0, 1] == 0 &&
                TmpMatrix[0, 2] == 0 &&
                TmpMatrix[0, 3] == 0 &&
                TmpMatrix[0, 4] == 0)
            {
                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        TmpMatrix[j, i] = TmpMatrix[j + 1, i];
                    }
                    TmpMatrix[4, i] = 0;
                }
            }

            matrix = TmpMatrix;

        }
        //set putaran
        public void setTurns(int t)
        {
            turn = t;
        }
        //mengembalikan pentomino kembali ke awal berdasarkan pentomino awal
        public void setBackPentaminos(Pentominos p)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = p.matrix[i, j];

                }
            }
            turn = p.turn;
            placed = false;
        }

        //menghandle putaran dimana rotate & flip sekaligus dilakukan pada satu tombol (kilk kanan)
        public void klikkanan()
        {
            if (jumlahrotate > 1)
            {
                
                if (turn == (jumlahrotate / 2) - 1)
                {
                    Rotatepentomino();
                    if (index != 6 && index != 10)
                    {
                        Flippentomino();
                    }
                        turn = 0;
                        return;
                    
                }


                Rotatepentomino();
                turn++;
            }
            

        }
        //menghandle rotasi pada pentomino
        public void Rotatepentomino()
        {
         

            int[,] TmpMatrix = new int[5, 5];
            int i, j;

            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    TmpMatrix[j, i] = matrix[i, 4 - j];
                }
            }

            while (TmpMatrix[0, 0] == 0 &&
                TmpMatrix[1, 0] == 0 &&
                TmpMatrix[2, 0] == 0 &&
                TmpMatrix[3, 0] == 0 &&
                TmpMatrix[4, 0] == 0)
            {
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        TmpMatrix[j, i] = TmpMatrix[j, i + 1];
                    }
                    TmpMatrix[i, 4] = 0;

                }
            }

            while (TmpMatrix[0, 0] == 0 &&
                TmpMatrix[0, 1] == 0 &&
                TmpMatrix[0, 2] == 0 &&
                TmpMatrix[0, 3] == 0 &&
                TmpMatrix[0, 4] == 0)
            {
                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        TmpMatrix[j, i] = TmpMatrix[j + 1, i];
                    }
                    TmpMatrix[4, i] = 0;
                }
            }

            matrix = TmpMatrix;

        }


       //menghandle draw dari pentomino
        public void Draw(Graphics oGraph)
        {
            Pen pen = new Pen(Color.DarkGray, 2);
          
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == 1)
                    {

                        oGraph.DrawRectangle(pen, posX + (i * 25), posY + (j * 25), 25, 25);


                        oGraph.FillRectangle(pentominosbrush, new Rectangle(posX +1+ (i * 25), posY+1 + (j * 25), 23, 23));
                    }
                }
            }
            pen.Dispose();
        }
    }
}
