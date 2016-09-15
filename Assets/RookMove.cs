using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RookMove : Move
{
    public static bool RightWhiteRookisMoved = false;
    public static bool LeftBlackRookisMoved = false;
    public static bool LeftWhiteRookisMoved = false;
    public static bool RigthBlackRookisMoved = false;

    private bool Has_Ally(int x, int y)  // this over ride as this implement function  and the parent implement function are difference
    {
        if (BoardManager.allPieces[x, y] != null)
                return true;
       
        return false;
    }
    public override List<pair> Allowed_Moves(int Board_x, int Board_y, bool isWhite)
    {
        List<pair> ls = new List<pair>();

        int x = Board_x;
        int y = Board_y - 1;
        //left
        while (y >= 0)
        {
             if(Has_Ally(x, y))
             {   if (BoardManager.allPieces[x, y].isWhite != isWhite)
                 ls.Add(new pair(x, y));
                 break;
             }
            else
            {
                ls.Add(new pair(x, y));
            }
            y--;
        }
        //right
        x = Board_x;
        y = Board_y + 1;
        while (y <= 7)
        {

            if (Has_Ally(x, y))
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                ls.Add(new pair(x, y));
                break;
            }
            else
            {
                ls.Add(new pair(x, y));
            }
            y++;
        }
        //up
        x = Board_x + 1;
        y = Board_y;
        while (x <= 7)
        {

            if (Has_Ally(x, y))
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                    ls.Add(new pair(x, y));
                break;
            }
            else
            {
                ls.Add(new pair(x, y));
            }
            x++;
        }
        //down
        x = Board_x - 1;
        y = Board_y;
        while (x >= 0)
        {

            if (Has_Ally(x, y))
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                    ls.Add(new pair(x, y));
                break;
            }
            else
            {
                ls.Add(new pair(x, y));
            }
            x--;
        }
        return ls;
    }
}