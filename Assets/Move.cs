using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class Move
    {
        protected bool isWhite ;
        public abstract List<pair> Allowed_Moves(int Board_X,int Board_Y,bool IsWWhite);
        protected bool inRange(int x)
        {
            return (x >= 0 && x <= 7);
        }
        protected virtual bool Has_Ally(int x, int y)
        {
            if (BoardManager.allPieces[x, y] != null)
            {
                if (BoardManager.allPieces[x, y].isWhite == this.isWhite)
                    return true;
            }
            return false;
        }
    }



