using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

//class yang menghandle DFS dan BFS
namespace Project1
{

    class Solver
    {

        public Form f;
        public int count = 0; //berguna untuk basis solver, game selesai ketika count(sel)=60
        //contructor
        public Solver(Form fr)
        {
            f = fr;
        }

        //set count
        public void setCountSolver(int sc)
        {
            count = sc;
        }

        //mencari sel yang masih kosong untuk penempatan pentomino
        //pencarian dilakukan persel dari kiri-kanan dan atas-bawah
        public int[] searchPosisiPlace()
        {
            Boolean ketemuposisikosong = false;
            int[] posisi = new int[4];
            posisi[0] = 0; //posisi logic
            posisi[1] = 0;
            posisi[2] = 0; //posisi di interface
            posisi[3] = 0;

            for (int i = 0; i < f.getBoard().getCols(); i++)
            {
                for (int j = 0; j < f.getBoard().getRows(); j++)
                {
                    if (f.getBoard().getMatrix()[i, j] == 0)
                    {
                        posisi[2] = i;
                        posisi[3] = j;
                        posisi[0] = 100 + (i * 25);
                        posisi[1] = 50 + (j * 25);
                        ketemuposisikosong = true;
                        break;
                    }
                }
                if (ketemuposisikosong)
                {
                    break;
                }
            }
            return posisi;
        }

        //melakukan penempatan pentomino pada posisi x, y
        public void place_pentomino(Pentominos p, int x, int y)
        {
            int lalaye = 0;
            Boolean laye = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (p.getMatrix()[i, j] == 1)
                    {

                        p.SetPos(x, y - lalaye);

                        laye = true;
                        break;

                    }
                    else
                    {
                        lalaye += 25;
                    }
                }
                if (laye)
                {
                    break;
                }
            }
        
        }



        //serching algorithm DFS
        public Boolean solvedfs()
        {
            while (f.getPAUSE())
            {
                Application.DoEvents(); 

            }
            int lastplace2 = 0;
            int lastpop2 = 0;
            int lol = 0;
            int pop = 0;
            if (count >= 60)
            {
                return true;
            }

            if (f.getPlayer() || f.getNewGame() || f.getEditorB() || f.getSTOP())
            {
                
                return true; ;
            }
            if (f.getBoard().isNull())
            {
                return true;
            }
            int[] posisi = searchPosisiPlace();

            while (lol < 12)
            {
                if (!f.getPentomino()[lol].getPlaced())
                {
                    while (pop < f.getPentomino()[lol].getJRotate())
                    {
                        if (f.getBoard().setMatrixBoard(posisi[2], posisi[3], f.getPentomino()[lol])) 
                        {
                            
                            count += 5;
                            place_pentomino(f.getPentomino()[lol], posisi[0], posisi[1]);

                            if (f.getSHOW())
                            {
                                f.Invalidate();
                                System.Threading.Thread.Sleep(f.getDelay());
                            }
                            Application.DoEvents();
                            f.getPentomino()[lol].setPlaced(true);
                            lastplace2 = lol;
                            lastpop2 = pop;
                            //pop = 0;
                           
                            if (!solvedfs())
                            {
                                count -= 5;
                                lol = lastplace2;

                                f.getPentomino()[lol].setPlaced(false);
                                f.getBoard().delMatrixBoard(posisi[2], posisi[3], f.getPentomino()[lol]);
                                                                   
                                pop = lastpop2;
                               
                                if (lol >= 6)
                                {
                                    f.getPentomino()[lol].SetPos(50 + ((lol % 6) * 150), 500);

                                }
                                else
                                {
                                    f.getPentomino()[lol].SetPos(50 + ((lol % 6) * 150), 350);

                                }

                                if (f.getSHOW())
                                {
                                    f.Invalidate();
                                    System.Threading.Thread.Sleep(f.getDelay());
                                }
                                Application.DoEvents();
                            }
                            else
                            {
                                return true;
                            }
                        }
                        f.getPentomino()[lol].klikkanan();
                        pop++;
                      
                    }

                   
                    f.getPentomino()[lol].setBackPentaminos(f.getIPentomino()[lol]);
                    
                    pop = 0;
                    lol++;
                   

                }
                else
                {
                    lol++;
                }
            }

            return false;

        }

        //searching algorithm BFS
        public Boolean solveBFS()
        {
            Queue<Queue<int[]> > Qpent = new Queue<Queue<int[]> >();
          
            int lol = 0;
            int pop = 0;
            int[] posisi = searchPosisiPlace();
            Queue<int[]> Spent = new Queue<int[]>();
            Queue<int[]> SpentTemp = new Queue<int[]>();   

            while (!f.getBoard().isNull() && SpentTemp.Count() != 12 && !f.getPlayer() && !f.getNewGame() && !f.getEditorB() && !f.getSTOP())
            {
                while (f.getPAUSE())
                {
                    Application.DoEvents();
                }
                lol = 0;
                posisi = searchPosisiPlace();
                while (lol < 12)
                {
                    pop = 0;
                    if (!f.getPentomino()[lol].getPlaced())
                    {
                       
                        while (pop < f.getPentomino()[lol].getJRotate())
                        {

                            Spent.Clear();
                            Spent = new Queue<int[]>(SpentTemp);                           
                            if (f.getBoard().setMatrixBoard(posisi[2], posisi[3], f.getPentomino()[lol]))
                            {
                            
                                Spent.Enqueue(new int[]{lol,pop});
                                
                                Qpent.Enqueue(new Queue<int[]>(Spent));                                
                                f.getBoard().delMatrixBoard(posisi[2], posisi[3], f.getPentomino()[lol]);
                            }

                            f.getPentomino()[lol].klikkanan();
                            pop++;
                        }
                    }
                    lol++;
                }
                
                SpentTemp = Qpent.Dequeue();
               
               
                placepentominosfromstate(SpentTemp);
                Application.DoEvents();
               
            }

            f.Invalidate();
            Application.DoEvents();
            System.Threading.Thread.Sleep(f.getDelay());
            if (SpentTemp.Count() == 12)
            {
                return true;
            }
            return false;
             
        }

        //menempatkan pentomino dari state ke dalam board
        public void placepentominosfromstate(Queue<int[]> Q)
        {
            f.getBoard().initinit();
            int[] P;
            int[] posisi;
            for (int i = 0; i < 12; i++)
            {
                f.getPentomino()[i].setBackPentaminos(f.getIPentomino()[i]);
             
                if (i >= 6)
                {
                    f.getPentomino()[i].SetPos(50 + ((i % 6) * 150), 500);
                }
                else
                {
                    f.getPentomino()[i].SetPos(50 + ((i % 6) * 150), 350);
                }
            }
            int t;
            t = 0;
           int j;
           int h = Q.Count();
            while (h > 0)
            {
                posisi = searchPosisiPlace();
                P = Q.ElementAt(t);
                t++;
                h--;
               
                j = P[1];
                               
                while (j > 0)
                {
                   f.getPentomino()[P[0]].klikkanan();
                    j--;
                }
                f.getBoard().setMatrixBoard(posisi[2], posisi[3], f.getPentomino()[P[0]]);
                place_pentomino(f.getPentomino()[P[0]], posisi[0], posisi[1]);
                f.getPentomino()[P[0]].setPlaced(true);

            }
            if (f.getSHOW())
            {
                f.Invalidate();
                System.Threading.Thread.Sleep(f.getDelay());
            }
        }
    }
}
