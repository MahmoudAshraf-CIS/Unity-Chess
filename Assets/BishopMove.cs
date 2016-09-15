using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class BishopMove : Move
{
    public override List<pair> Allowed_Moves(int Board_x, int Board_y, bool isWhite)
    {
         this.isWhite = isWhite;
        List<pair> ls = new List<pair>();
        int x = Board_x + 1;
        int y = Board_y - 1;

        // upleft x++ , y--
        while (inRange(x) && inRange(y))
        {
            if (BoardManager.allPieces[x, y] != null)
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                    ls.Add(new pair(x, y));
                break;
            }

            else
            {
                ls.Add(new pair(x, y));
            }
            x++; y--;
        }
        //upright x++ , y++
        x = Board_x + 1;
        y = Board_y + 1;
        while (inRange(x) && inRange(y))
        {
            if (BoardManager.allPieces[x, y] != null)
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                    ls.Add(new pair(x, y));
                break;
            }

            else
            {
                ls.Add(new pair(x, y));
            }
            x++; y++;
        }
        // downright x-- , y++
        x = Board_x - 1;
        y = Board_y + 1;
        while (inRange(x) && inRange(y))
        {
            if (BoardManager.allPieces[x, y] != null)
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                    ls.Add(new pair(x, y));
                break;
            }

            else
            {
                ls.Add(new pair(x, y));
            }
            x--; y++;
        }
        // \downleft x-- , y--
        x = Board_x - 1;
        y = Board_y - 1;
        while (inRange(x) && inRange(y))
        {
            if (BoardManager.allPieces[x, y] != null)
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                    ls.Add(new pair(x, y));
                break;
            }

            else
            {
                ls.Add(new pair(x, y));
            }
            x--; y--;
        }
        return ls;
    }

}