using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Froggy
{
    class Enemy: System.Windows.Forms.PictureBox
    {
        Image[] cars = new Image[2];
        
        public Enemy(int x, int y,byte pic)
        {
            cars[0] = Image.FromFile("car1.png");
            cars[1] = Image.FromFile("car2.png");
            this.Visible = true;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
            this.Width = 45;
            this.Height = 45;
            this.Left = x;
            this.Top = y;
            this.Image = cars[pic];
        }
        public void EnemyGo(int speed)
        {
            if (this.Left < 460) this.Left += speed;
            else this.Left = -50;
        }

        

    }
}
