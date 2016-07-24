using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Froggy.Game
{
    class Frog: System.Windows.Forms.PictureBox
    {
        Image[] froger = new Image[4];
        public int Lives { get; set; }
        public int Points { get; set; }

        public int PosX
        {
            get
            {
                return this.Left;
            }
            set
            {
                this.Left = value;
            }
        }

        public int PosY
        {
            get
            {
                return this.Top;
            }
            set
            {
                this.Top = value;
            }
        }

        public Frog(int x, int y)
        {
            Lives = 3;
            for(int i=0; i<4; i++) froger[i] = Image.FromFile(i.ToString()+".png");
            this.PosX = x;
            
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PosY = y;
            this.DoubleBuffered = true;
            this.Width = 45;
            this.Height = 45;
            this.BackColor = Color.Transparent;
            this.Image = froger[0];
            //this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Visible = true;
        }

        public void FrogJump(Keys x)
        {
            Graphics r = this.CreateGraphics();
            
                switch (x)
                {
                    case Keys.W:
                    if (this.PosY >= 61) this.PosY -= 45;
                    this.Image = froger[0];
                    
                        break;
                    case Keys.S:
                    if (this.PosY <= 241) this.PosY += 45;
                        this.Image = froger[1];
                        break;
                    case Keys.A:
                    if (this.PosX >= 51) this.PosX -= 45;
                        this.Image = froger[3];
                        break;
                    case Keys.D:
                    if (this.PosX <= 366) this.PosX += 45;
                        this.Image = froger[2];
                        break;
                }
            
        }
        public void EnemyKill(Timer timer, Enemy enemy,ToolStripMenuItem label)
        {
            if (this.Top == enemy.Top)
            {
                if (this.Left > enemy.Left - 40 && this.Left < enemy.Left + 40)
                {
                    this.Location = new Point(210, 286);
                    Lives -= 1;
                    label.Text = "Życia: " + Lives;
                    if (Lives == 0) timer.Enabled = false;

                }
            }
        }
        public void NextLvl(Timer timer, ToolStripMenuItem label)
        {
            if(this.Location==new Point(390, 16))
            {
                this.Location = new Point(210, 286);
                Points += 1;
                label.Text = "Punkty: " + Points;
                if (Points == 50)
                {
                    timer.Enabled = false;
                    label.Text = "BRAWO";
                    MessageBox.Show("Brawo to już koniec Twojej wędrówki :)");
                    Points = 0;
                }
                timer.Interval = 100 - (Points * 2);
            }
            
            
        }

    }
}
