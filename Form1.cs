using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdClone
{
    public partial class Form1 : Form
    {
        private bool jumping = false;
        int pipeSpeed = 5;
        int gravity = 5;
        int score = 0;

        public Form1()
        {
            InitializeComponent();

            endText1.Text = "Game Over!" ;
            gameDesigner.Text = "Made by Scott Coffman";

            endText1.Visible = false;
            replayButton.Visible = false;
            replayButton.Enabled = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FlappyBird_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;
            scoreText.Text = "" + score;


            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 1000;
                score += 1;
            }
            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = 1100;
                score += 1;
            }


            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }
        }

        private void pipeBottom_Click(object sender, EventArgs e)
        {

        }

        private void gameDesigner_Click(object sender, EventArgs e)
        {

        }

        private void endText1_Click(object sender, EventArgs e)
        {

        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }

        private void endGame()
        {
            gameTimer.Stop();
            endText2.Text = "Your final score is: " + score;
            endText1.Visible = true;
            endText2.Visible = true;
            replayButton.Visible = true;
            replayButton.Enabled = true;
            //gameDesigner.Visible = true;
        }


        private void InGameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -7;

            }
        }

        private void InGameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 4;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0); 
        }
    }
}
