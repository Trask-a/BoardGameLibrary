using System;

namespace BoardGameLibrary
{
    class Program
    {
        // 1 or 2
        int playersTurn = 1;
        string playerInput;

        public void PrintBoard(Board b)
        {
            for (int i = 0; i < b.BoardSizeHeight; i++)
            {
                for (int j = 0; j < b.BoardSizeWidth; j++)
                {
                    Console.Write("[");
                    if (b.board[i, j].OpenCell == true)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write(b.board[i, j].PieceOnCell.Team);
                    }
                    Console.Write("]");
                };
                Console.WriteLine();
            };
        }

        //check input from user is exactly = 0,0 or = number,number so the string = "0,0"
        public string CheckInput(string input)
        {
            while(true)
            {
                if ((input[0] == '0' || input[0] == '1' || input[0] == '2') && input[1] == ',' && (input[2] == '0' || input[2] == '1' || input[2] == '2'))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input. Input Row then column (ex. 0,0). Please put in correct input: ");
                    input = Console.ReadLine();
                }

            }
            return input;
            
        }

        public void PlayerTurn(Board b)
        {
            Console.WriteLine("Input Row then column (ex. 0,0)");
            Console.WriteLine("Player " + playersTurn + " turn: ");
            playerInput = Console.ReadLine();
            playerInput = CheckInput(playerInput);
            
           
            while(true)
            {
                if (b.board[(int)Char.GetNumericValue(playerInput[0]), (int)Char.GetNumericValue(playerInput[2])].OpenCell == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Space already taken, input new space: ");
                    playerInput = Console.ReadLine();
                    playerInput = CheckInput(playerInput);
                }
                
            }
            //adds to the board
            b.board[(int)Char.GetNumericValue(playerInput[0]), (int)Char.GetNumericValue(playerInput[2])].PieceOnCell = new Piece(playersTurn);

        }
        // 00 01 02
        // 10 11 12
        // 20 21 22

        // horizontal 3 ways, vertical 3 ways, diagonal 2 ways
        public bool CheckWin(Board b)
        {
            // horizontal wins
            if (b.board[0, 0].PieceOnCell.Team == playersTurn && b.board[0, 1].PieceOnCell.Team == playersTurn && b.board[0, 2].PieceOnCell.Team == playersTurn)
            {
                return true;
            }
            else if (b.board[1, 0].PieceOnCell.Team == playersTurn && b.board[1, 1].PieceOnCell.Team == playersTurn && b.board[1, 2].PieceOnCell.Team == playersTurn)
            {
                return true;
            }
            else if (b.board[2, 0].PieceOnCell.Team == playersTurn && b.board[2, 1].PieceOnCell.Team == playersTurn && b.board[2, 2].PieceOnCell.Team == playersTurn)
            {
                return true;
            }

            // vertical wins
            else if (b.board[0, 0].PieceOnCell.Team == playersTurn && b.board[1, 0].PieceOnCell.Team == playersTurn && b.board[2, 0].PieceOnCell.Team == playersTurn)
            {
                return true;
            }
            else if (b.board[0, 1].PieceOnCell.Team == playersTurn && b.board[1, 1].PieceOnCell.Team == playersTurn && b.board[2, 1].PieceOnCell.Team == playersTurn)
            {
                return true;
            }
            else if (b.board[0, 2].PieceOnCell.Team == playersTurn && b.board[1, 2].PieceOnCell.Team == playersTurn && b.board[2, 2].PieceOnCell.Team == playersTurn)
            {
                return true;
            }

            // diagonal wins
            else if (b.board[0, 0].PieceOnCell.Team == playersTurn && b.board[1, 1].PieceOnCell.Team == playersTurn && b.board[2, 2].PieceOnCell.Team == playersTurn)
            {
                return true;
            }
            else if (b.board[2, 0].PieceOnCell.Team == playersTurn && b.board[1, 1].PieceOnCell.Team == playersTurn && b.board[0, 2].PieceOnCell.Team == playersTurn)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Board ticTacToeBoard = new Board(3,3);
            int turn = 1;
            while(true)
            {
                p.PrintBoard(ticTacToeBoard);
                p.PlayerTurn(ticTacToeBoard);
                if (p.CheckWin(ticTacToeBoard) && turn > 4)
                {
                    p.PrintBoard(ticTacToeBoard);
                    Console.WriteLine("Player " + p.playersTurn + " wins!!!");
                    break;
                }
                
                if (p.playersTurn == 1)
                {
                    p.playersTurn = 2;
                }
                else
                {
                    p.playersTurn = 1;
                }
                turn++;
            }
           

        }

        // TODO Move playing of game to its own class
        // TODO Create a checkers and chess pieces that inherit from piece
       
    }
}
