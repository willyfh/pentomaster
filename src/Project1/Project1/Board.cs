using System;
using System.Drawing;
using System.Drawing.Drawing2D;


//class yang menghandle pembuatan Board Puzzle
namespace Project1
{
    class Board
    {
        private int Cols; //kolom board
        private int Rows; // row board
        private int[,] matrix; // untuk bentuk board
        private int[,] Tmatrix; //menyimpan bentuk awal board "Temp"
        private int posBoardX; //posisi board pada sumbu X
        private int posBoardY; //posisi board pada sumbu Y
        private int typeBoard; // jenis board

        //contructor
        public Board()
        {
            matrix = new int[Cols, Rows];
            Tmatrix = new int [Cols, Rows];
            Cols = 0;
            Rows = 0;
            posBoardX = 100;
            posBoardY = 50;
        }

        //constructor base on other board
        public Board(Board B)
        {
            matrix = B.matrix;

            Cols = B.Cols;
            Rows = B.Rows;
        }

        //membuat board tergantung dari "type"nya
        public void createBoard(int typeB)
        {
            typeBoard = typeB;
            switch (typeB)
            {
                case 0:
                    Cols = 0;
                    Rows = 0;

                    break;
                case 1:
                    Cols = 10;
                    Rows = 6;
                    matrix = new int[Cols, Rows];
                     
                    
                    for (int i = 0; i < Cols; i++)
                    {
                        for (int j = 0; j < Rows; j++)
                        {
                            matrix[i, j] = 0;
                           
                        }
                    }
                    break;

                case 2:
                    Cols = 12;
                    Rows = 5;
                    matrix = new int[Cols, Rows];
                     
                    for (int i = 0; i < Cols; i++)
                    {
                        for (int j = 0; j < Rows; j++)
                        {
                            matrix[i, j] = 0;
                           
                        }
                    }
                    break;
                case 3:
                    Cols = 15;
                    Rows = 4;
                    matrix = new int[Cols, Rows];
                   
                    for (int i = 0; i < Cols; i++)
                    {
                        for (int j = 0; j < Rows; j++)
                        {
                            matrix[i, j] = 0;
                   
                        }
                    }
                    break;
                case 4:
                    Cols = 20;
                    Rows = 3;
                    matrix = new int[Cols, Rows];
                    for (int i = 0; i < Cols; i++)
                    {
                        for (int j = 0; j < Rows; j++)
                        {
                            matrix[i, j] = 0;
                        
                        }
                    }
                    break;
                case 5:
                    Cols = 15;
                    Rows = 6;
                    matrix = new int[Cols, Rows];
                  

                        for (int i = 0; i < Cols; i++)
                        {
                            for (int j = 0; j < Rows; j++)
                            {
                                matrix[i, j] = 0;
                               
                            }
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                matrix[i, j] = 1;
                                
                            }
                        }

                        for (int i = 10; i < 15; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                matrix[i, j] = 1;
                               
                            }
                        }

                    
                    break;

                case 6 :
                    Cols = 11;
                    Rows = 10;
                    matrix = new int[Cols, Rows];

                    for (int i = 0; i < Cols; i++)
                    {
                        for (int j = 0; j < Rows; j++)
                        {
                            matrix[i, j] = 0;

                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 3-i; j >= 0; j--)
                        {

                            matrix[i, j] = 1;
                          
                        }
                    }

                    for (int i = 7; i < Cols; i++)
                    {
                        for (int j = 0; j <= i-7; j++)
                        {

                            matrix[i, j] = 1;
                           
                        }
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 5+i; j <Rows; j++)
                        {

                            matrix[i, j] = 1;
                            
                        }
                    }

                    for (int i = 6; i < Cols; i++)
                    {
                        for (int j = Rows-1; j>= 15-i; j--)
                        {

                            matrix[i, j] = 1;

                        }
                    }
                    break;
                case 7 :                    
                    Cols = 11;
                    Rows = 7;
                    matrix = new int[Cols,Rows];
                    for (int i = 0; i<Cols; i++){
	                    for (int j=0; j<Rows; j++){
	
		                    matrix[i,j]=0;
	
	                    }
                    }
                    matrix[0,0] = 1;
                    matrix[0, 6] = 1;
                    matrix[3,1] = 1;
                    matrix[5,1] = 1;
                    matrix[7,1] = 1;
                    matrix[1,2] = 1;
                    matrix[1, 4] = 1;
                    matrix[3,1] = 1;
                    matrix[3,3] = 1;
                    matrix[3,5] = 1;
                    matrix[5,1] = 1;
                    matrix[5,3] = 1;
                    matrix[5,5] = 1;
                    matrix[7,1] = 1;
                    matrix[7,3] = 1;
                    matrix[7,5] = 1;
                    matrix[9,2] = 1;
                    matrix[9,4] = 1;
                    matrix[10, 0] = 1;
                    matrix[10,6]=1;
                    break;
            }
            Tmatrix = new int[Cols, Rows];
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Tmatrix[i, j] = matrix[i,j];

                }

            }
            
        }


        //membuat board dari edito
        public void createBoardFromEditor(Editor ed)
        {
            Rows = ed.getRows();
            Cols = ed.getCols();
            matrix = new int[Cols,Rows];
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    matrix[i, j] = ed.getMatrix()[i, j];
                }
            }
            Tmatrix = new int[Cols, Rows];
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Tmatrix[i, j] = matrix[i, j];

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


        //apakah board terisi semua?
        public Boolean isFull()
        {
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (matrix[i,j]== 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //apakah ada tumpukan pentomino di board?
        public Boolean isCollisionOnBoard()
        {
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (matrix[i, j]>1)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        //menginisiasi ulang board
        public void initinit()
        {
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    matrix[i, j] = Tmatrix[i,j];

                }
            }
        }

        //apakah valid, pentomino yang ditempatkan diboard berada di wilayah board
        public Boolean isValid(int i, int j, Pentominos p)
        {

            return ( i>=0 && j >=0 && i+p.GetWidthM()<=Cols && j+p.GetHeightM() <= Rows);
            
        }

        // mengeset nilai ketika ada pentomino dimasukan
        public Boolean setMatrixBoard(int i, int j, Pentominos p)
        {
           
            int x,y;
            int ia = i;
            int ja = j;
            Boolean notvalid = false;
            Boolean oke=false;
            for (int a = 0; a < 5; a++)
            {
              
                for (int b = 0; b < 5; b++)
                {

                    if (p.getMatrix()[a, b] == 1)
                    {
                        oke = true;
                        x = i + a;
                        y = j + b;

                        if (!isValid(i, j, p))
                        {
                            notvalid = true;
                            break;
                        }
                        matrix[x, y]++;
                    }
                    else
                    {
                        if (!oke)
                        {
                            j--;
                        }
                    }
                }
                if (notvalid)
                    break;
            }
            if (notvalid)
            {
                return false;
            }
            if (isCollisionOnBoard())
            {
                delMatrixBoard(ia, ja, p);
                return false;
            }
            else
            {
                return true;
            }

        }


        //mengurangi nilai matrix ketika pentomino dikeluarkan dari board
        public void delMatrixBoard(int i, int j, Pentominos p)
        {
            int x, y;
            Boolean oke = false;
            for (int a = 0; a < 5; a++)
            {
               
                for (int b = 0; b < 5; b++)
                {
                    if (p.getMatrix()[a, b] == 1)
                    {
                        oke = true;
                        x = i + a;
                        y = j + b;
                        matrix[x,y]--;
                    }
                    else
                    {
                        if (!oke)
                        {
                            j--;
                        }
                    }
                }
            }
        }


        //set posisi board
        public void setPosBoard(int x,int y)
        {
            posBoardX = x;
            posBoardY = y;
        }

        //melakukan draw board untuk tampilan
        public void Draw(Graphics oGraph)
        {
            Pen blackpen = new Pen(Color.Gray, 2);
            SolidBrush black = new SolidBrush(Color.DarkGray);
            SolidBrush colorkotak = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(posBoardX-10,posBoardY-10,(25*Cols)+20,(25*Rows)+20);
            if (Cols!=0 && Rows!=0){
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

        //apakah board kosong?
        public Boolean isNull()
        {
            if (Cols==0 || Rows==0)
            {
                return true;
            }
            return false;
        }
        

    }
}
