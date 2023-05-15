using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        List<string> fields = CreateEmptyFields();

        public Form1()
        {
            InitializeComponent();


            // Same event for buttons
            button1.Click += new EventHandler(multiBtnClick);
            button2.Click += new EventHandler(multiBtnClick);
            button3.Click += new EventHandler(multiBtnClick);
            button4.Click += new EventHandler(multiBtnClick);
            button5.Click += new EventHandler(multiBtnClick);
            button6.Click += new EventHandler(multiBtnClick);
            button7.Click += new EventHandler(multiBtnClick);
            button8.Click += new EventHandler(multiBtnClick);
            button9.Click += new EventHandler(multiBtnClick);
        }

        private void multiBtnClick(object sender, EventArgs e)
        {
            // Get clicked button
            Button clickedButton = (Button)sender;

            // check if field is empty
            if (fields[clickedButton.TabIndex] != "-")
            {
                Output.Text = "Niewłaściwy ruch!";
            }
            else
            {
                clickedButton.Text = "O";
                fields[clickedButton.TabIndex] = "O";
                if (CheckDraw())
                {
                    EndGame("draw");
                }
                else
                {
                    PcTurn();
                }
                
            }
            if (CheckWinnerPlayer())
            {
                EndGame("player");
            }

            
        }

        // Create empty lists
        private static List<string> CreateEmptyFields()
        {
            List<string> fields = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                fields.Add("-");
            }
            Console.WriteLine(fields[8]);
            return fields;
        }

        private bool CheckWinnerPlayer()
        {
            // 123 fields
            if (fields[0] == "O" && fields[1] == "O" && fields[2] == "O")
                return true;
            // 456 fields
            else if (fields[3] == "O" && fields[4] == "O" && fields[5] == "O")
                return true;
            // 789 fields
            else if (fields[6] == "O" && fields[7] == "O" && fields[8] == "O")
                return true;
            // 147 fields
            else if (fields[0] == "O" && fields[3] == "O" && fields[6] == "O")
                return true;
            // 258 fields
            else if (fields[1] == "O" && fields[4] == "O" && fields[7] == "O")
                return true;
            // 369 fields
            else if (fields[2] == "O" && fields[5] == "O" && fields[8] == "O")
                return true;
            // 159 fields
            else if (fields[0] == "O" && fields[4] == "O" && fields[8] == "O")
                return true;
            // 357 fields
            else if (fields[2] == "O" && fields[4] == "O" && fields[6] == "O")
                return true;
            else
                return false;
        }

        private bool CheckWinnerPC()
        {
            // 123 fields
            if (fields[0] == "X" && fields[1] == "X" && fields[2] == "X")
                return true;
            // 456 fields
            else if (fields[3] == "X" && fields[4] == "X" && fields[5] == "X")
                return true;
            // 789 fields
            else if (fields[6] == "X" && fields[7] == "X" && fields[8] == "X")
                return true;
            // 147 fields
            else if (fields[0] == "X" && fields[3] == "X" && fields[6] == "X")
                return true;
            // 258 fields
            else if (fields[1] == "X" && fields[4] == "X" && fields[7] == "X")
                return true;
            // 369 fields
            else if (fields[2] == "X" && fields[5] == "X" && fields[8] == "X")
                return true;
            // 159 fields
            else if (fields[0] == "X" && fields[4] == "X" && fields[8] == "X")
                return true;
            // 357 fields
            else if (fields[2] == "X" && fields[4] == "X" && fields[6] == "X")
                return true;
            else
                return false;
        }

        private bool CheckDraw()
        {
            if (fields.Contains("-"))
                return false;
            else
                return true;
        }

        // Pc Turn
        private void PcTurn()
        {
            

            

        Start:
            Random rnd = new Random();
            int choice = rnd.Next(8);

            if (fields[choice] != "-")
            {
                goto Start;
            }
            else
            {
                fields[choice] = "X";
                RefreshBoard();
            }

            if (CheckWinnerPC())
            {
                EndGame("pc");
            }

            if (CheckDraw())
            {
                EndGame("draw");
            }
        }

        // Refresh board after pc turn
        private void RefreshBoard()
        {
            button1.Text = fields[0];
            button2.Text = fields[1];
            button3.Text = fields[2];
            button4.Text = fields[3];
            button5.Text = fields[4];
            button6.Text = fields[5];
            button7.Text = fields[6];
            button8.Text = fields[7];
            button9.Text = fields[8];
        }

        // 
        private void EndGame(string winner)
        {
            if (winner == "player")
            {
                Output.Text = "Wygrałeś!";
            }
            else if (winner == "draw")
            {
                Output.Text = "Remis";
            }
            else
            {
                Output.Text = "Przegrałeś :(";
            }
        }
    }
}
