using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameLibrary
{
    class Cell
    {
        string color = "white";
        private bool openCell = true;
		public bool OpenCell
        {
			get { return openCell; }
			set { openCell = value; }
        }
        private Piece pieceOnCell = new Piece(0);
		public Piece PieceOnCell
        {
			get { return pieceOnCell; }
			set { 
				pieceOnCell = value;
				openCell = false;
				}
        }

		Cell(){}

		public Cell(String c)
		{
			color = c;
		}

		public Cell(String c, Piece p)
        {
			color = c;
			openCell = false;
			pieceOnCell = p;
        }

    }

	/*Board
	- create size of board
		- 2d array for positions of board
			- created based on size of board
	- Cell or squares of the board
	- Pieces 2d array
	- Place piece

Pieces
	- Team

Cell
	- color
	- open or closed
		- closed if space taken
	- piece on the cell*/
}
