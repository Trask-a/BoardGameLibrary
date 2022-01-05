using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameLibrary
{
    class Piece
    {
        private int team = 0;
        public int Team
        {
            get { return team; }
            set { team = value; }
        }

        public Piece(int t)
        {
            team = t;
        }
    }
}
