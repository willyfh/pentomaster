using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


//class yang menghandle interface windows form
namespace Project1
{
    class Form : System.Windows.Forms.Form
    {
        public int count = 0;
        private int set = 0;
        public int delayKecepatan = 0;
        public Boolean player = false;
        public Boolean newgame = false;
        public Boolean editorB = false;
        public Boolean STOP = true;
        public Boolean PAUSE = false;
        public Boolean INVALIDATE = false;
        public Boolean SHOW = true;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MainMenu PentominosMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuplayer;
        private System.Windows.Forms.MenuItem menucomputer;
        private System.Windows.Forms.MenuItem menu6x10;
        private System.Windows.Forms.MenuItem menu5x12;
        private System.Windows.Forms.MenuItem menu4x15;
        private System.Windows.Forms.MenuItem menu3x20;
        private System.Windows.Forms.MenuItem menuTR;
        private System.Windows.Forms.MenuItem menuDiamond;
        private System.Windows.Forms.MenuItem menuBolaBolong;
        private System.Windows.Forms.MenuItem menuDFS;
        private System.Windows.Forms.MenuItem menuBFS;
        private System.Windows.Forms.MenuItem menulambat;
        private System.Windows.Forms.MenuItem menusedang;
        private System.Windows.Forms.MenuItem menucepat;
        private System.Windows.Forms.MenuItem menucarapakai;
        private System.Windows.Forms.MenuItem menuabout;
        private System.Windows.Forms.StatusBar stBar;
        private System.Windows.Forms.Timer TimerElapsed;
        private Button btn = new Button();
        private Button btn2 = new Button();
        private Button btn3 = new Button();
        private Button btn4 = new Button();
        public int typeBoard;
        public DateTime TStart;
        private Pentominos draggedpentomino;
        public Pentominos[] pentomino = new Pentominos[12];
        public Pentominos[] initialpentomino = new Pentominos[12];
        public Board board = new Board();
        public Editor editor = new Editor();
        private Solver solve;
        Bitmap Image2 = new Bitmap(Project1.Properties.Resources.pentominoes);
        
        System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer(Properties.Resources.shoot);
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.Sonic_Boom);

        //contructor form
        public Form()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            solve = new Solver(this);
            InitializeComponent();
            randomPentominos();
            init();

            typeBoard = 0;
        }

        //menghandle interface yang ditampilkan ke user
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawImage(Image2, 0, 0); // draw background image
 
            Pen pen = new Pen(Color.Black, 2);

            board.Draw(e.Graphics); //draw board
            editor.Draw(e.Graphics); //draw editor
            Brush brush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            e.Graphics.DrawRectangle(pen, 20, 320, 930, 330);
            e.Graphics.FillRectangle(brush, 21, 321, 928, 328);
            for (int i = 0; i < 12; i++)
            {
                pentomino[i].Draw(e.Graphics); //draw pentomino
            }
            pen.Dispose();

        }

        //menginisialisasi kompononen komponen yang ada pada windows form
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PentominosMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuplayer = new System.Windows.Forms.MenuItem();
            this.menucomputer = new System.Windows.Forms.MenuItem();
            this.menuDFS = new System.Windows.Forms.MenuItem();
            this.menuBFS = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menu6x10 = new System.Windows.Forms.MenuItem();
            this.menu5x12 = new System.Windows.Forms.MenuItem();
            this.menu4x15 = new System.Windows.Forms.MenuItem();
            this.menu3x20 = new System.Windows.Forms.MenuItem();
            this.menuTR = new System.Windows.Forms.MenuItem();
            this.menuDiamond = new System.Windows.Forms.MenuItem();
            this.menuBolaBolong = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menulambat = new System.Windows.Forms.MenuItem();
            this.menusedang = new System.Windows.Forms.MenuItem();
            this.menucepat = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menucarapakai = new System.Windows.Forms.MenuItem();
            this.menuabout = new System.Windows.Forms.MenuItem();
            this.stBar = new System.Windows.Forms.StatusBar();
            this.TimerElapsed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            //button untuk editor

            btn.Name = "Btn-" + 1;
            btn.Size = new Size(100, 40);
            btn.Tag = 0;
            btn.Text = "SET THIS !!";
            btn.Location = new Point(550, 270);
            btn.Click += new EventHandler(btn_Click);

            //button stop

            btn2.Name = "Btn-" + 2;
            btn2.Size = new Size(100, 40);
            btn2.Tag = 0;
            btn2.Text = "STOP";
            btn2.Location = new Point(550, 270);
            btn2.Click += new EventHandler(btn2_Click);

            //buton pause

            btn3.Name = "Btn-" + 3;
            btn3.Size = new Size(100, 40);
            btn3.Tag = 0;
            btn3.Text = "PAUSE";
            btn3.Location = new Point(550, 210);
            btn3.Click += new EventHandler(btn3_Click);


            btn4.Name = "Btn-" + 4;
            btn4.Size = new Size(100, 40);
            btn4.Tag = 0;
            btn4.Text = "HIDE";
            btn4.Location = new Point(550, 150);
            btn4.Click += new EventHandler(btn4_Click);


            // 
            // PentominosMenu
            // 
            this.PentominosMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuplayer,
            this.menucomputer});
            this.menuItem1.Text = "Mode";
            // 
            // menuplayer
            // 
            this.menuplayer.Index = 0;
            this.menuplayer.Text = "Player";
            this.menuplayer.Click += new System.EventHandler(this.menuplayer_Click);
            // 
            // menucomputer
            // 
            this.menucomputer.Index = 1;
            this.menucomputer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuDFS,
            this.menuBFS});
            this.menucomputer.Text = "Computer";
            // 
            // menuDFS
            // 
            this.menuDFS.Index = 0;
            this.menuDFS.Text = "DFS";
            this.menuDFS.Click += new System.EventHandler(this.menuDFS_Click);
            // 
            // menuBFS
            // 
            this.menuBFS.Index = 1;
            this.menuBFS.Text = "BFS";
            this.menuBFS.Click += new System.EventHandler(this.menuBFS_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu6x10,
            this.menu5x12,
            this.menu4x15,
            this.menu3x20,
            this.menuTR,
            this.menuDiamond,
            this.menuBolaBolong
           });
            this.menuItem2.Text = "New";
            // 
            // menu6x10
            // 
            this.menu6x10.Index = 0;
            this.menu6x10.Text = "level 1 (6 x 10)";
            this.menu6x10.Click += new System.EventHandler(this.menu6x10_Click);
            // 
            // menu5x12
            // 
            this.menu5x12.Index = 1;
            this.menu5x12.Text = "level 2 (5 x 12)";
            this.menu5x12.Click += new System.EventHandler(this.menu5x12_Click);
            // 
            // menu4x15
            // 
            this.menu4x15.Index = 2;
            this.menu4x15.Text = "level 3 (4 x 15)";
            this.menu4x15.Click += new System.EventHandler(this.menu4x15_Click);
            // 
            // menu3x20
            // 
            this.menu3x20.Index = 3;
            this.menu3x20.Text = "level 4 (3 x 20)";
            this.menu3x20.Click += new System.EventHandler(this.menu3x20_Click);

            //menuboard T
            this.menuTR.Index = 4;
            this.menuTR.Text = "level 5 (Flip T)";
            this.menuTR.Click += new System.EventHandler(this.menuTR_Click);

            //menu DIAMOND
            this.menuDiamond.Index = 5;
            this.menuDiamond.Text = "level 6 (Diamond)";
            this.menuDiamond.Click += new System.EventHandler(this.menuDiamond_Click);

            //menu Bola Bolong
            this.menuBolaBolong.Index = 6;
            this.menuBolaBolong.Text = "level 7 (Holey oval)";
            this.menuBolaBolong.Click += new System.EventHandler(this.menuBolaBolong_Click);


            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menulambat,
            this.menusedang,
            this.menucepat});
            this.menuItem3.Text = "Speed";
            // 
            // menulambat
            // 
            this.menulambat.Index = 0;
            this.menulambat.Text = "Lambat";
            this.menulambat.Click += new System.EventHandler(this.menulambat_Click);
            // 
            // menusedang
            // 
            this.menusedang.Index = 1;
            this.menusedang.Text = "Sedang";
            this.menusedang.Click += new System.EventHandler(this.menusedang_Click);
            // 
            // menucepat
            // 
            this.menucepat.Checked = true;
            this.menucepat.Index = 2;
            this.menucepat.Text = "Cepat";
            this.menucepat.Click += new System.EventHandler(this.menucepat_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menucarapakai,
            this.menuabout});
            this.menuItem4.Text = "Help";
            //menu editor


            this.menuItem5.Index = 3;
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            this.menuItem5.Text = "Editor";
            // 
            // menucarapakai
            // 
            this.menucarapakai.Index = 0;
            this.menucarapakai.Text = "Cara Penggunaan";
            this.menucarapakai.Click += new System.EventHandler(this.menucarapakai_Click);
            // 
            // menuabout
            // 
            this.menuabout.Index = 1;
            this.menuabout.Text = "About";
            this.menuabout.Click += new System.EventHandler(this.menuabout_Click);
            // 
            // stBar
            // 
            this.stBar.Location = new System.Drawing.Point(0, 618);
            this.stBar.Name = "stBar";
            this.stBar.ShowPanels = true;
            this.stBar.Size = new System.Drawing.Size(970, 22);
            this.stBar.SizingGrip = false;
            this.stBar.TabIndex = 0;
            // 
            // TimerElapsed
            // 
            this.TimerElapsed.Enabled = true;
            this.TimerElapsed.Interval = 1000;
            this.TimerElapsed.Tick += new System.EventHandler(this.TimerElapsed_Tick);



            // Form
            // 
            this.MaximizeBox = false;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(970, 680);
            this.Controls.Add(this.stBar);
            this.Menu = this.PentominosMenu;
            this.Name = "Form";
            this.Text = "PentoMaster";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPentominos_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPentominos_MouseMove);
            this.ResumeLayout(false);

        }

        //menginisialisasi form
        public void init()
        {

            stBar.Panels.Clear();
            this.Controls.Remove(btn);
            this.Controls.Remove(btn2);
            this.Controls.Remove(btn3);
            this.Controls.Remove(btn4);
            StatusBarPanel pane1 = new StatusBarPanel();
            pane1.AutoSize = StatusBarPanelAutoSize.Spring;
            pane1.Text = "Time: 00:00:00";
            stBar.Panels.Add(pane1);

            board.initinit();
            for (int i = 0; i < 12; i++)
            {
                pentomino[i].setBackPentaminos(initialpentomino[i]);
                if (i >= 6)
                {
                    initialpentomino[i].SetPos(500 + ((i % 6) * 150), 200);
                    pentomino[i].SetPos(50 + ((i % 6) * 150), 500);
                }
                else
                {
                    pentomino[i].SetPos(50 + ((i % 6) * 150), 350);
                    initialpentomino[i].SetPos(500 + ((i % 6) * 150), 0);
                }
            }
            TStart = DateTime.Now;
            TimerElapsed.Enabled = false;
            count = 0;

        }

        //menghandle penekanan tombol pada mouse
        private void frmPentominos_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (player)
            {


                if (e.Button == MouseButtons.Right && draggedpentomino != null)
                {
                    sp2.Play();
                    
                    draggedpentomino.klikkanan();
                    Invalidate(new Rectangle(draggedpentomino.GetX() - 2, draggedpentomino.GetY() - 2, 150, 150));
                }

                if (e.Button == MouseButtons.Left && draggedpentomino != null)
                {
                    if (!pentominoCollision(draggedpentomino, draggedpentomino.getUrutan()))
                    {
                        new System.Media.SoundPlayer(Properties.Resources.shoot).Play();
                        draggedpentomino = null;
                        isFinish();
                    }
                    return;
                }

                if (e.Button == MouseButtons.Left && draggedpentomino == null)
                {
                    int iPosX = e.X / 25;
                    int iPosY = e.Y / 25;

                    iPosX *= 25;
                    iPosY *= 25;
                    for (int i = 0; i < 12; i++)
                    {
                        if (pentomino[i].atPos(iPosX, iPosY))
                        {
                            draggedpentomino = pentomino[i];
                            new System.Media.SoundPlayer(Properties.Resources.shoot).Play();
                            break;
                        }
                    }
                }
            }
            else if (editorB)
            {


                if (e.Button == MouseButtons.Left)
                {
                    int iPosX = e.X / 25;
                    int iPosY = e.Y / 25;

                    iPosX *= 25;
                    iPosY *= 25;
                    set = editor.getSel(iPosX, iPosY);
                    editor.atPos(iPosX, iPosY, set);
                    Invalidate();
                }

            }
        }

        //menghandel pergerakan mouse
        private void frmPentominos_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (draggedpentomino != null)
            {

                int iPosX = e.X / 25;
                int iPosY = e.Y / 25;

                iPosX *= 25;
                iPosY *= 25;

                if (iPosX != draggedpentomino.GetX() || iPosY != draggedpentomino.GetY())
                {
                    Rectangle rect = new Rectangle(draggedpentomino.GetX() - 2, draggedpentomino.GetY() - 2, draggedpentomino.GetWidth() + 4, draggedpentomino.GetHeight() + 4);
                    draggedpentomino.SetPos(iPosX, iPosY);
                    Region rgn = new Region(rect);
                    rect = new Rectangle(iPosX - 2, iPosY - 2, draggedpentomino.GetWidth() + 4, draggedpentomino.GetHeight() + 4);
                    rgn.Union(rect);
                    Invalidate(rgn);
                }

            }
            if (editorB)
            {
                int iPosX = e.X / 25;
                int iPosY = e.Y / 25;

                iPosX *= 25;
                iPosY *= 25;

                if (e.Button == MouseButtons.Left)
                {
                    editor.atPos(iPosX, iPosY, set);
                    Rectangle rect = new Rectangle(100, 50, 350, 300);

                    Region rgn = new Region(rect);
                    rect = new Rectangle(100, 50, 350, 300);
                    rgn.Union(rect);
                    Invalidate(rgn);
                }
            }
        }

        //menentukan apakah game sudah diselesaikan atau belum
        //berguna untuk mode player agar lebih mudah, lebih memudahkan daripada harus mengeset matrix pada board
        public void isFinish()
        {
            count = 0;

            for (int iPosX = 100; iPosX < 100 + (board.getCols() * 25); iPosX += 25)
            {
                for (int iPosY = 50; iPosY < 50 + (board.getRows() * 25); iPosY += 25)
                {
                    if (board.getMatrix()[(iPosX - 100) / 25, (iPosY - 50) / 25] == 0)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            if (pentomino[i].atPos(iPosX, iPosY))
                            {
                                count++;
                                break;
                            }
                        }
                    }
                }
            }

            if (count >= 60)
            {

                player = false;
                TimerElapsed.Enabled = false;
                sp.Play();
                MessageBox.Show("You have finished the game !!", "PentoMaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //menghandle waktu yang ditampilkan di windows form
        private void TimerElapsed_Tick(object sender, System.EventArgs e)
        {
            TimeSpan tmElapsed = new TimeSpan();

            tmElapsed = DateTime.Now - TStart;
            String sTime = String.Format("Time: {0:00}:{1:00}:{2:00}", tmElapsed.TotalHours, tmElapsed.Minutes, tmElapsed.Seconds);

            stBar.Panels[0].Text = sTime;

        }

        //menghandle klik pada menu editor
        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                editorB = true;

                newgame = false;
                player = false;

                typeBoard = 0;
                board.createBoard(0);
                editor.createEditorBoard();
                init();
                this.Controls.Add(btn);

                TimerElapsed.Enabled = false;
                Invalidate();
            }

        }
        //menghandle klik button stop
        private void btn2_Click(object sender, System.EventArgs e)
        {
            STOP = true;
            TimerElapsed.Enabled = false;

        }
        //menghandle klik button pause
        private void btn3_Click(object sender, System.EventArgs e)
        {

            if (PAUSE == false)
            {
                PAUSE = true;
                btn3.Text = "CONTINUE";
                TimerElapsed.Enabled = false;
            }
            else
            {
                btn3.Text = "PAUSE";
                TimerElapsed.Enabled = true;
                PAUSE = false;
            }

        }

        private void btn4_Click(object sender, System.EventArgs e)
        {

            if (SHOW == false)
            {
                SHOW = true;
                btn4.Text = "HIDE";
            }
            else
            {
                btn4.Text = "SHOW";
                SHOW = false;
            }

        }

        //menghandle klik button untuk mengeset hasil editor
        private void btn_Click(object sender, System.EventArgs e)
        {
            int jumlah = editor.isEditorValid();
            if (jumlah == 60)
            {
                newgame = true;
                player = false;
                board.createBoardFromEditor(editor);
                init();
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                Invalidate();
            }
            else
            {
                MessageBox.Show("Jumlah sel belum 60, jumlah sel sekarang  = " + jumlah, "PentoMaster", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        //menghandle klik menu cara penggunaan
        private void menucarapakai_Click(object sender, System.EventArgs e)
        {
            string carapakai = "1. Buka menu New dan pilih Level / Board yang di inginkan, atau bisa juga membuat board sendiri dengan membuka pada menu Editor \n\n";
            carapakai += "2. Buka menu Mode dan pilih Player atau Komputer untuk menyelesaikan game\n\n";
            carapakai += "3. Jika memilih mode Player, gunakan klik kiri untuk melakukan drag pada pentominos dan klik kanan untuk melakukan rotate sekaligus flip\n\n";
            carapakai += "4. Jika memilih mode Komputer, kecepatan pencarian dapat di atur pada menu Speed\n\n";
            carapakai += "5. Game akan berakhir ketika seluruh papan puzzle berhasil terisi penuh oleh seluruh pentominos yang ada\n\n";
            carapakai += "\nCATATAN :\nPastikan Board sudah di set dengan memilih Level/Board pada menu New atau menu Editor sebelum memulai mode Player atau mode Komputer\n\n";

            carapakai += "Jika ingin mengakses mode lain sementara searching masih berjalan, hentikan searching terlebih dahulu dengan menekan tombol STOP";
            MessageBox.Show(carapakai, "Cara Penggunaan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //menghandle klik pada menu about
        private void menuabout_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("PentoMaster\n\nVersi 1.0\n\n@2013", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //menghandle klik pada menu player
        private void menuplayer_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {

                player = true;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);

                init();
                TimerElapsed.Enabled = true;
                Invalidate();
            }
        }
        //menghandle klik untuk menu lambat
        private void menulambat_Click(object sender, System.EventArgs e)
        {
            menucepat.Checked = false;
            menusedang.Checked = false;
            menulambat.Checked = true;
            delayKecepatan = 1000;
        }
        //menghandle klik pada menu sedang
        private void menusedang_Click(object sender, System.EventArgs e)
        {
            menucepat.Checked = false;
            menusedang.Checked = true;
            menulambat.Checked = false;
            delayKecepatan = 500;
        }
        //menghandle klik pada menu cepat
        private void menucepat_Click(object sender, System.EventArgs e)
        {
            menucepat.Checked = true;
            menusedang.Checked = false;
            menulambat.Checked = false;
            delayKecepatan = 0;
        }

        //menghandle klik untuk jenis levelboard
        public void menu3x20_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                newgame = true;
                player = false;

                typeBoard = 4;
                board.createBoard(typeBoard);

                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                init();
                Invalidate();
            }
        }
        //menghandle klik untuk jenis levelboard
        public void menu6x10_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                newgame = true;
                player = false;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                typeBoard = 1;
                board.createBoard(typeBoard);
                init();
                Invalidate();
            }
        }
        //menghandle klik untuk jenis levelboard
        public void menuTR_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                newgame = true;
                player = false;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                typeBoard = 5;
                board.createBoard(typeBoard);
                init();
                Invalidate();
            }
        }

        //menghandle klik untuk jenis levelboard
        public void menuDiamond_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                newgame = true;
                player = false;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                typeBoard = 6;
                board.createBoard(typeBoard);
                init();
                Invalidate();
            }
        }
        //menghandle klik untuk jenis levelboard
        public void menuBolaBolong_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                newgame = true;
                player = false;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                typeBoard = 7;
                board.createBoard(typeBoard);
                init();
                Invalidate();
            }
        }
        //menghandle klik untuk jenis levelboard
        public void menu5x12_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                newgame = true;
                player = false;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                typeBoard = 2;
                board.createBoard(typeBoard);
                init();
                Invalidate();
            }
        }
        //menghandle klik untuk jenis levelboard
        public void menu4x15_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                newgame = true;
                player = false;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                typeBoard = 3;
                board.createBoard(typeBoard);
                init();
                Invalidate();
            }
        }

        //menghandle klik untuk menu DFS
        private void menuDFS_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                solve = new Solver(this);
                STOP = false;
                PAUSE = false;
                SHOW = true;
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                player = false;
                newgame = false;
                init();
                this.Controls.Add(btn3);
                this.Controls.Add(btn2);
                this.Controls.Add(btn4);
                btn4.Text = "HIDE";
                TimerElapsed.Enabled = true;
                if (solve.solvedfs() && !player && !newgame && !editorB && !board.isNull() && !STOP)
                {

                    Invalidate();
                    TimerElapsed.Enabled = false;
                    new System.Media.SoundPlayer(Properties.Resources.Sonic_Boom).Play();
                    MessageBox.Show("You have finished the game !!", "PentoMaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Invalidate();
                    STOP = true;

                }
                else
                {
                    MessageBox.Show("Solusi tidak ketemu!!", "PentoMaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimerElapsed.Enabled = false;
                    STOP = true;

                }
            }

        }
        //menghandle klik untuk menu BFS
        private void menuBFS_Click(object sender, System.EventArgs e)
        {
            if (STOP)
            {
                STOP = false;
                PAUSE = false;
                SHOW = true;
                solve = new Solver(this);
                editorB = false;
                editor.setCols(0);
                editor.setRows(0);
                player = false;
                newgame = false;
                init();
                this.Controls.Add(btn3);
                this.Controls.Add(btn2);
                this.Controls.Add(btn4);
                btn4.Text = "HIDE";
                Invalidate();
                Application.DoEvents();
                TimerElapsed.Enabled = true;
                if (solve.solveBFS())
                {
                    new System.Media.SoundPlayer(Properties.Resources.Sonic_Boom).Play();
                    TimerElapsed.Enabled = false;
                    MessageBox.Show("You have finished the game !!", "PentoMaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    STOP = true;

                }
                else
                {

                    MessageBox.Show("Solusi tidak ketemu !!", "PentoMaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimerElapsed.Enabled = false;
                    STOP = true;

                }
            }

        }

        //untuk melakukan random pada inisial pentomino
        public void randomPentominos()
        {
            Random rnd = new Random();
            Queue<int> N = new Queue<int>();
            List<int> Nu = new List<int>();
            int lol;
            int[] la = new int[12];
            int pop;
            for (int i = 0; i < 12; i++)
            {
                Nu.Add(i);
            }

            for (int i = 0; i < 12; i++)
            {

                lol = rnd.Next(0, Nu.Count());

                pop = Nu.ElementAt(lol) + 1;
                Nu.RemoveAt(lol);


                pentomino[i] = new Pentominos();
                pentomino[i].Createpentominos(pop, i);
                initialpentomino[i] = new Pentominos();
                initialpentomino[i].Createpentominos(pop, i);
                lol = rnd.Next(0, pentomino[i].getJRotate());

                while (lol > 0)
                {
                    pentomino[i].klikkanan();
                    initialpentomino[i].klikkanan();
                    lol--;
                }


            }
        }

        //mengecek apakah terdapat pentomino yang bertumpukan
        public Boolean pentominoCollision(Pentominos p, int z)
        {
            for (int j = 0; j < 12; j++)
            {
                for (int a = 0; a < 5; a++)
                {
                    for (int b = 0; b < 5; b++)
                    {
                        if (p.getMatrix()[a, b] == 1)
                        {
                            for (int c = 0; c < 5; c++)
                            {
                                for (int d = 0; d < 5; d++)
                                {
                                    if (pentomino[j].getMatrix()[c, d] == 1)
                                    {
                                        if (p.GetX() + (a * 25) == pentomino[j].GetX() + (c * 25) &&
                                            p.GetY() + (b * 25) == pentomino[j].GetY() + (d * 25) && z != j)
                                        {
                                            return true;

                                        }
                                    }

                                }
                            }

                        }
                    }
                }
            }

            return false;
        }


        //get & set
        public Boolean getPlayer()
        {
            return player;
        }

        public Boolean getNewGame()
        {
            return newgame;
        }

        public Pentominos[] getPentomino()
        {
            return pentomino;
        }


        public Pentominos[] getIPentomino()
        {
            return initialpentomino;
        }

        public Board getBoard()
        {
            return board;
        }

        public Boolean getSHOW()
        {
            return SHOW;
        }

        public Boolean getPAUSE()
        {
            return PAUSE;
        }
        public Boolean getSTOP()
        {
            return STOP;
        }

        public Boolean getEditorB()
        {
            return editorB;
        }
        public int getDelay()
        {
            return delayKecepatan;
        }


    }
}
