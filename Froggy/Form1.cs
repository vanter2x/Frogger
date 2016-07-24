using Froggy.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Froggy
{
    public partial class frmGame1 : Form
    {
        Frog zaba = new Frog(210, 286);
        Enemy[] car = new Enemy[16];
        
        public frmGame1()
        {
            
            InitializeComponent();
            EnemyInit();
            pbWater.Controls.Add(zaba);
            
        }

        private void FrogGo(object sender, KeyEventArgs e)
        {
            if(tmrEnemy.Enabled == true)
            {
                button1.Text = zaba.PosX.ToString();
                zaba.FrogJump(e.KeyCode);
                button1.Text = zaba.Location.ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pbWater.CreateGraphics();
            Pen pencil = new Pen(Color.Black, 5);
            g.DrawLine(pencil, 10, 10, 300, 300);

            g.DrawImage(Image.FromFile("1.png"), 0, 0);


        }

        void EnemyInit()
        {
            for (int i = 0; i < 16; i++)
            {
                if (i < 4) car[i] = new Enemy(0, 61, 0);
                if (i>=4 && i<8) car[i] = new Enemy(0, 106, 1);
                if (i >= 8 && i < 12) car[i] = new Enemy(0, 196, 0);
                if (i >= 12 && i < 16) car[i] = new Enemy(0, 241, 1);
                pbWater.Controls.Add(car[i]);
                

            }
            car[0].Left = 0;
            car[1].Left = 150;
            car[2].Left = 200;
            car[3].Left = 450;
            car[4].Left = 450;
            car[5].Left = 50;
            car[6].Left = 250;
            car[7].Left = 350;
            car[8].Left = 150;
            car[9].Left = 350;
            car[10].Left = 250;
            car[11].Left = 0;
            car[12].Left = 400;
            car[13].Left = 150;
            car[14].Left = 300;
            car[15].Left = 210;
            

        }

        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                if (i < 4) car[i].EnemyGo(8);
                if (i >= 4 && i < 8) car[i].EnemyGo(18);
                if (i >= 8 && i < 12) car[i].EnemyGo(12);
                if (i >= 12 && i < 16) car[i].EnemyGo(15);
                zaba.EnemyKill(tmrEnemy, car[i],lblLives);

            }
            zaba.NextLvl(tmrEnemy, lblPoints);
            
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zaba.Location=new Point(210, 286);
            zaba.Lives = 5;
            zaba.Points = 0;
            tmrEnemy.Enabled = true;
            lblLives.Text = "Życia: " + zaba.Lives;
            lblPoints.Text = "Punkty: " + zaba.Points;
        }
    }
}
