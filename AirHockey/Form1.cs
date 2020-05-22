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
        int padlleHeight = 60;
        int paddleSpeed = 4;

        int goalWidth = 100;
        int goal1X = 0;
        int goal2X = 600;
        int goalY = 150; 

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

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Paint (object sender, EventArgs e)
        {

        }
        private void Form1_KeyUp (object sender, KeyEventArgs e)
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

        private void Form1_KeyDown (object sender, KeyEventArgs e)
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
    }
}
