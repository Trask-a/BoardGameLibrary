using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameLibrary
{
    class Board
    {
        private int boardSizeWidth = 0;
        public int BoardSizeWidth
        {
            get { return boardSizeWidth; }
            set { boardSizeWidth = value; }
        }
        //public int BoardSizeWidth { get; set; }

        int boardSizeHeight = 0;
        public int BoardSizeHeight
        {
            get { return boardSizeHeight; }
            set { boardSizeHeight = value; }
        }

        public Cell[,] board;
        
        public Board(int width, int height)
        {
            boardSizeWidth = width;
            boardSizeHeight = height;
            board = new Cell[height, width];
            FillBoard();
        }

        // Premade board for chess/checkers

        // fill array with 0, if piece at location then make it a 1
        // fill board with 0
        void FillBoard()
        {
            String cellColor = "white";
            
            for(int i = 0; i < boardSizeHeight; i++)
            {
                for(int j = 0; j < boardSizeWidth; j++)
                {
                    board[i,j] = new Cell(cellColor);
                    if(cellColor == "white")
                    {
                        cellColor = "black";
                    }
                    else if(cellColor == "black")
                    {
                        cellColor = "white";
                    }
                };
            };
        }
    }
}
