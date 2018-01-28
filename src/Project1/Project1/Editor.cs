using System;
using System.Drawing;
using System.Drawing.Drawing2D;

//class yang menghandle editor board
namespace Project1
{
    class Editor
    {
        private int Cols;
        private int Rows;
        private int[,] matrix;
        private int posBoardX;
        private int posBoardY;

        //contructor editor
        public Editor()
        {
            Cols = 0;
            Rows = 0;
            matrix = new int[Cols, Rows];
            posBoardX = 100;
            posBoardY = 50;

        }

        //membentuk editor board
        public void createEditorBoard()
        {
            Cols = 10;

            Rows = 10;
            matrix = new int[Cols, Rows];
            for (int i=0; i<Cols; i++){
                for (int j = 0; j < Rows; j++)
                {
                    matrix[i, j] = 1;
                }

            }
        }
        //get & set
        public int getCols()
        {
            return Cols;
        }

        public int getRows()
        {
            return Rows;
        }

        public int[,] getMatrix()
        {
            return matrix;
        }

        public void setCols(int c)
        {
            this.Cols = c;
        }

        public void setRows(int r)
        {
            this.Rows = r;
        }

        //mengembalikan integer untuk mengeset matrix pada board tergantung pada intial sel yang di klik sebelum di drag
        public int getSel(int x, int y)
        {

             for (int i = 0; i < Cols; i++)
             {
                for (int j = 0; j < Rows; j++)
                {

                    if (x == posBoardX + (i * 25) && y == posBoardY + (j * 25))
                    {
                        if (matrix[i, j] == 1)
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }

                    }
                }
            }
             return 90;
            
        }

        //jika tombol klik tepat didala board, maka set matrixnya tergantung pada set
        public void atPos(int iX, int iY, int set)
        {
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {

                    if (iX == posBoardX + (i * 25) && iY == posBoardY + (j * 25))
                    {
                        matrix[i, j] = set;
                    }
                }
            }
        }

        //validasi editor yang mengembalikan jumlah sel yang telah dibuat oleh user
        public int isEditorValid()
        {
            int count = 0;
            for (int i=0;i<Cols;i++){
                for (int j = 0; j < Rows; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
         }
        
        //menghandle draw untuk editor
        public void Draw(Graphics oGraph)
        {
            Pen blackpen = new Pen(Color.Gray, 2);
            SolidBrush black = new SolidBrush(Color.DarkGray);
            SolidBrush colorkotak = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(posBoardX - 10, posBoardY - 10, (25 * Cols) + 20, (25 * Rows) + 20);
            if (Cols != 0 && Rows != 0)
            {
                oGraph.DrawRectangle(blackpen, posBoardX - 10, posBoardY - 10, (25 * Cols) + 20, (25 * Rows) + 20);
                oGraph.FillRectangle(black, posBoardX - 10, posBoardY - 10, (25 * Cols) + 20, (25 * Rows) + 20);
            }

            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        oGraph.DrawRectangle(blackpen, posBoardX + (i * 25), posBoardY + (j * 25), 25, 25);
                        oGraph.FillRectangle(colorkotak, posBoardX + (i * 25) + 1, posBoardY + (j * 25) + 1, 25 - 2, 25 - 2);
                    }
                }
            }

            blackpen.Dispose();
            black.Dispose();
            colorkotak.Dispose();
        }
    }
}
