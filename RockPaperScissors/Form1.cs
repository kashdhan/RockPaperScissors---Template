using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;
        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;//to get away from inserting numbers, we want to insert more variables

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;//image variables: objects, easy to draw
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        Point playerLocation = new Point(168, 70); // point objects (like a variable) 
        Point cpuLocation = new Point(360, 70); // x y coordinates that control where things go
        Point outcomeLocation = new Point(225, 5);


        Graphics g; // can't tell the form to use it as a canvas because it has not been initialized yet

        public Form1()//begins to build your form
        {
            InitializeComponent();
            g = this.CreateGraphics();//tell it to use it as a canvas
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            /// TODO Set the playerchoice value, draw the appropriate image,
            /// play a sound, wait for a second; repeat for the computer turn 
            playerChoice = "rock";

            g.DrawImage(rockImage, playerLocation);//image and coordinates, they were pre-set b4

            int randValue = randGen.Next(1, 4);

            ComputerTurn();

            jabPlayer.Play();
            Thread.Sleep(choicePause);

            DetermineWinner();

            gongPlayer.Play();
            Thread.Sleep(outcomePause);
            Refresh();

        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";

            g.DrawImage(paperImage, playerLocation);//image and coordinates, they were pre-set b4

            ComputerTurn();

            jabPlayer.Play();
            Thread.Sleep(choicePause);

            DetermineWinner();

            gongPlayer.Play();
            Thread.Sleep(outcomePause);
            Refresh();


        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";

            g.DrawImage(scissorImage, playerLocation);//image and coordinates, they were pre-set b4

            ComputerTurn();

            jabPlayer.Play();
            Thread.Sleep(choicePause);

            DetermineWinner();

            gongPlayer.Play();
            Thread.Sleep(outcomePause);
            Refresh();
        }

        public void ComputerTurn()
        {
            int randValue = randGen.Next(1, 4);
            switch (randValue)
            {
                case 1:
                    cpuChoice = "rock";
                    g.DrawImage(rockImage, cpuLocation);
                    break;
                case 2:
                    cpuChoice = "paper";
                    g.DrawImage(paperImage, cpuLocation);
                    break;
                case 3:
                    cpuChoice = "scissor";
                    g.DrawImage(scissorImage, cpuLocation);
                    break;
            }
        }
        public void DetermineWinner()//combine the "restrictions" for wins into 1 line and put losses under else
        {
            if (playerChoice == cpuChoice)
            {
                g.DrawImage(tieImage, outcomeLocation);
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
            }
            else if ((playerChoice == "rock" && cpuChoice == "scissors") ||
                    (playerChoice == "paper" && cpuChoice == "rock") ||
                    (playerChoice == "scissors" && cpuChoice == "paper"))
            {
                g.DrawImage(winImage, outcomeLocation);
                wins++;
                winsLabel.Text = $"Wins: {wins}";
            }
            else
            {
                g.DrawImage(loseImage, outcomeLocation);
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
            }
        }
    }
}