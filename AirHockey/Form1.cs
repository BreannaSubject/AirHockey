using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirHockey
{
    public partial class Form1 : Form
    {
        #region global variables

        int paddle1X = 10;
        int paddle1Y = 170;
        int player1Score = 0;

        int paddle2X = 580;
        int paddle2Y = 170;
        int player2Score = 0;

        int paddleWidth = 10;
        int paddleHeight = 60;
        int paddleSpeed = 4;

        int goal1X = 100;
        int goal2X = 300; 

        int ballX = 295;
        int ballY = 195;
        int ballXSpeed = 6;
        int ballYSpeed = 6;
        int ballWidth = 10;
        int ballHeight = 10;

        bool nDown = false;
        bool bDown = false;
        bool mDown = false;
        bool spaceDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush purpleBrush = new SolidBrush(Color.FromArgb(155, 41, 153));
        SolidBrush blueBrush = new SolidBrush(Color.FromArgb(41, 153, 155));
        Pen yellowPen = new Pen(Color.FromArgb(153, 155, 41));
        Font screenFont = new Font("Arial", 16);

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.B:
                    bDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ballX += ballXSpeed;
            ballY += ballYSpeed;

            if (nDown == true && paddle1Y > 0)
            {
                paddle1Y -= paddleSpeed;
            }

            if (bDown == true && paddle1X > 0)
            {
                paddle1X -= paddleSpeed;
            }

            if (spaceDown == true && paddle1Y < this.Height - paddleHeight)
            {
                paddle1Y += paddleSpeed; 
            }

            if (mDown == true && paddle1X < 299 - paddleWidth)
            {
                paddle1X += paddleSpeed; 
            }

            if (upArrowDown == true && paddle2Y > 0)
            {
                paddle2Y -= paddleSpeed;
            }

            if (leftArrowDown == true && paddle2X < 600 - paddleWidth)
            {
                paddle2X -= paddleSpeed;
            }

            if ( downArrowDown == true && paddle2Y < this.Height - paddleHeight)
            {
                paddle2Y += paddleSpeed;
            }

            if (rightArrowDown == true && paddle2X > 300 - paddleWidth)
            {
                paddle2X += paddleSpeed;
            }

            if (ballY < 0 || ballY > this.Height - ballHeight)
            {
                ballYSpeed *= -1;
            }

            Rectangle player1rectangle = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            Rectangle player2rectangle = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
            Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);

            if (player1rectangle.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = paddle1X + paddleWidth + 1; 
            }
            else if (player2rectangle.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = paddle2X - ballWidth - 1; 
            }

            if (ballX < 0 && ballY > goal1X && ballY < goal2X)
            {
                player2Score++;
                ballX = 295;
                ballY = 195;

                paddle1Y = 170;
                paddle1X = 10;
                paddle2Y = 170;
                paddle2X = 580; 
            }
            else if (ballX > 600 && ballY > goal1X && ballY < goal2X)
            {
                player1Score++;
                ballX = 295;
                ballY = 195;

                paddle1Y = 170;
                paddle1X = 10;
                paddle2Y = 170;
                paddle2X = 580;
            }
            else if (ballX < 0 )
            {
                ballXSpeed *= -1;
            }
            else if (ballX > 600)
            {
                ballXSpeed *= -1;
            }

            if (player1Score == 3 || player2Score == 3)
            {
                gameTimer.Enabled = false; 
            }

            Refresh();
        }

        private void Form1_Paint (object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(purpleBrush, paddle1X, paddle1Y, paddleWidth, paddleHeight);
            e.Graphics.FillRectangle(purpleBrush, paddle2X, paddle2Y, paddleWidth, paddleHeight);

            e.Graphics.FillEllipse(blueBrush, ballX, ballY, ballWidth, ballHeight);

            e.Graphics.DrawString($"{player1Score}", screenFont, blueBrush, 20, 10);
            e.Graphics.DrawString($"{player2Score}", screenFont, blueBrush, 560, 10);

        }
      

       
    }
}
