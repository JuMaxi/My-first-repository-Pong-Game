using System;
using System.Threading;
namespace Aula16_Pong_batedores_Movimentar
{
    class Program
    {
        static int PositionPlayer1 = 9;
        static int PositionPlayer2 = 13;
        static int PositionColumn = 55;
        static int PositionLine = 12;
        static bool BallGoingUp = false;
        static bool BallGoingRight = false;
        static int Player1 = 0;
        static int Player2 = 0;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int key);

        static bool CheckarTecla(int CodeKey)
        {
            return (0x8000 & GetAsyncKeyState(CodeKey)) != 0;
        }

        static void DrawFrame()
        {
            // Start Draw Frame
            for (int UpperFrame = 0; UpperFrame <= 111; UpperFrame++)
            {
                Console.SetCursorPosition(UpperFrame, 0);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═");
                Console.ResetColor();
            }
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╔");
            Console.ResetColor();

            for (int LeftFrame = 1; LeftFrame <= 25; LeftFrame++)
            {
                Console.SetCursorPosition(0, LeftFrame);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("║");
                Console.ResetColor();
            }

            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╚");
            Console.ResetColor();

            for (int BottomFrame = 1; BottomFrame <= 111; BottomFrame++)
            {
                Console.SetCursorPosition(BottomFrame, 26);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═");
                Console.ResetColor();
            }

            Console.SetCursorPosition(111, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╗");
            Console.ResetColor();

            for (int RightFrame = 1; RightFrame <= 25; RightFrame++)
            {
                Console.SetCursorPosition(111, RightFrame);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("║");
                Console.ResetColor();
            }

            Console.SetCursorPosition(111, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╝");
            Console.ResetColor();

            // End Start Draw Frame
        }

        static void DrawPlayers()
        {
            // Draw Player 1
            for (int Player1 = PositionPlayer1; Player1 <= PositionPlayer1 + 2; Player1++)
            {
                Console.SetCursorPosition(6, Player1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("▐ ");
                Console.ResetColor();
            }
            // End Draw Player 1

            // Draw Player 2
            for (int Player2 = PositionPlayer2; Player2 <= PositionPlayer2 + 2; Player2++)
            {
                Console.SetCursorPosition(105, Player2);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("▐ ");
                Console.ResetColor();
            }
            // End Draw Player 2
        }

        static void MovePlayers()
        {
            // Check if Q Key was pressed - Player 1 up
            bool KeyQPressed = CheckarTecla(81);
            if (KeyQPressed)
            {
                Console.SetCursorPosition(6, (PositionPlayer1 + 2));
                Console.WriteLine(" ");

                PositionPlayer1--;

                if (PositionPlayer1 == 0)
                {
                    PositionPlayer1 = 1;
                }
            }
            // End Check if Q Key was pressed - Player 1 up

            // Check if A Key was pressed - Player 1 down
            bool KeyAPressed = CheckarTecla(65);
            if (KeyAPressed)
            {
                Console.SetCursorPosition(6, PositionPlayer1);
                Console.WriteLine(" ");

                PositionPlayer1++;

                if (PositionPlayer1 == 24)
                {
                    PositionPlayer1 = 23;
                }
            }
            // End Check if A Key was pressed - Player 1 down



            // Check if P Key was pressed - Player 2 up
            bool KeyPPressed = CheckarTecla(80);
            if (KeyPPressed)
            {
                Console.SetCursorPosition(105, PositionPlayer2 + 2);
                Console.WriteLine(" ");

                PositionPlayer2--;

                if (PositionPlayer2 == 0)
                {
                    PositionPlayer2 = 1;
                }
            }
            // End Check if P Key was pressed - Player 2 up

            // Check if L Key was pressed - Player 2 down
            bool KeyLPressed = CheckarTecla(76);
            if (KeyLPressed)
            {
                Console.SetCursorPosition(105, PositionPlayer2);
                Console.WriteLine(" ");

                PositionPlayer2++;

                if (PositionPlayer2 == 24)
                {
                    PositionPlayer2 = 23;
                }
            }
            // End Check if L Key was pressed - Player 2 down
        }

        static void DrawBall()
        {
            // Draw the Ball
            Console.SetCursorPosition(PositionColumn, PositionLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("♥");
            Console.ResetColor();
            // End Draw the Ball
        }

        static void CleanBall()
        {
            // Clean the Ball
            Console.SetCursorPosition(PositionColumn, PositionLine);
            Console.WriteLine(" ");
            // End Clean the Ball
        }

        static void MoveBallLines()
        {

            // Move the Ball in the Position of Lines (up and down)
            if (BallGoingUp == false)
            {
                PositionLine--;


                if (PositionLine == 0)
                {
                   BallGoingUp = true;
                }
            }
            if (BallGoingUp == true)
            {
                PositionLine++;

                if (PositionLine == 25)
                {
                    BallGoingUp = false;
                }
            }
            // End Move the Ball in the Position of Lines (up and down)
        }

        static void MoveBallColumnAndScoreBoard()
        {
            // Move the Ball in the Position of Columns (Left and Right)
            if (BallGoingRight == false)
            {
                PositionColumn++;
                if (PositionColumn == 111)
                {
                    BallGoingRight = true;
                    PositionColumn = 55;
                    PositionLine = 12;
            // Here, there is Scoreboard Player 1 
                    Player1 = Player1 + 1;
            // End Scoreboard Player 1
                }
            }
            if (BallGoingRight == true)
            {
                PositionColumn--;
                if (PositionColumn == 1)
                {
                    BallGoingRight = false;
                    PositionColumn = 55;
                    PositionLine = 12;
            // Here, there is Scoreboard Player 1 
                    Player2 = Player2 + 1;
            // End Scoreboard Player 2
                }
            }
            // End Move the Ball in the Position of Columns (Left and Right)
        }

        static void PlayersTakeTheBall()
        {
            // Player 1 take the Ball and the Ball return
            if (PositionColumn == 7)
            {
                int PositionP1 = PositionPlayer1;
                for (int Player1 = PositionP1; Player1 <= PositionP1 + 2; Player1++)
                    if (Player1 == PositionLine)
                    {
                        BallGoingRight = false;
                    }
            }
            // End Player 1 take the Ball and the Ball return

            // Player 2 take the Ball and the Ball return
            if (PositionColumn == 104)
            {
                int PositionP2 = PositionPlayer2;
                for (int Player2 = PositionP2; Player2 <= PositionP2 + 2; Player2++)
                {
                    if (Player2 == PositionLine)
                    {
                        BallGoingRight = true;
                    }
                }
            }
            // End Player 2 take the Ball and the Ball return
        }

        static void DrawScoreBoard()
        {
            // Draw ScoreBoard
            Console.SetCursorPosition(52, 27);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SCOREBOARD:");
            Console.ResetColor();

            Console.SetCursorPosition(25, 28);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PLAYER 1");
            Console.ResetColor();

            Console.SetCursorPosition(74, 28);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("PLAYER 2");
            Console.ResetColor();
            // End Draw ScoreBoard
        }

        static void ShowScoreBoard()
        {
            // Show ScoreBoard Player 1
            Console.SetCursorPosition(29, 29);
            Console.WriteLine(Player1);
            // End Show ScoreBoard Player 1

            // Show ScoreBoard Player 2
            Console.SetCursorPosition(79, 29);
            Console.WriteLine(Player2);
            // End Show ScoreBoard Player 2
        }

        static void Main(string[] args)
        {
            DrawFrame();
            
            while (true)
            {
                DrawPlayers();

                MovePlayers();

                DrawBall();

                // Time Move Ball
                Thread.Sleep(150);
                // End Time Move Ball

                CleanBall();

                MoveBallLines();

                MoveBallColumnAndScoreBoard();

                PlayersTakeTheBall();

                DrawScoreBoard();

                ShowScoreBoard();
            }
        }
    }
    
}

