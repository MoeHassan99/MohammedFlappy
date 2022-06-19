using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MohammedFlappy
{
    public partial class Form1 : Form
    {


        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void pipeTop_Click(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left-=pipeSpeed;
            scoreText.Text = " Score: " + score;   


            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left < -170)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Ground.Bounds) || FlappyBird.Top < -25
                )
                //Denna följande kod gör att användaren som spelar inte får röra pipes eller golvet annars recallar funktionen endGame
                //som betyder att användaren förlorar. 
            {
                endGame();
            }
             if(score > 5)
            {
                pipeSpeed = 15;
            }
             //Efter 5 poäng så görs spelet svårare med att snabba ut det. 

        }


        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }



        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }


        }
        
        

        private void endGame()
        {
            GameTimer.Stop();
            scoreText.Text += " Game over!";
        }
    }
}
