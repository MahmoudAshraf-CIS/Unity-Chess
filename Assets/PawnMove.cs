using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PawnMove : Move
{
    public override List<pair> Allowed_Moves(int Board_x, int Board_y, bool isWhite)
    {
        List<pair> ls = new List<pair>();
        if (isWhite)
        {//White
            // first move
            if (Board_x == 1)
            {
                if (BoardManager.allPieces[Board_x + 1, Board_y] == null)
                {
                    ls.Add(new pair(Board_x + 1, Board_y));
                    if (BoardManager.allPieces[Board_x + 2, Board_y] == null)
                        ls.Add(new pair(Board_x + 2, Board_y));
                }
            }
            //Diagonal && middle
            if (Board_x >= 1 && Board_x <= 6)
            {
                //ahead is empty - so it can Move forward
                if (BoardManager.allPieces[Board_x + 1, Board_y] == null)
                    ls.Add(new pair(Board_x + 1, Board_y));

                if (Board_y != 0 && Board_y != 7)
                {
                    if (BoardManager.allPieces[Board_x + 1, Board_y + 1] != null)
                        if (BoardManager.allPieces[Board_x + 1, Board_y + 1].isWhite != isWhite)
                            ls.Add(new pair(Board_x + 1, Board_y + 1));

                    if (BoardManager.allPieces[Board_x + 1, Board_y - 1] != null)
                        if (BoardManager.allPieces[Board_x + 1, Board_y - 1].isWhite != isWhite)
                            ls.Add(new pair(Board_x + 1, Board_y - 1));
                }
                else if (Board_y == 0 && BoardManager.allPieces[Board_x + 1, Board_y + 1] != null)
                {
                    if (BoardManager.allPieces[Board_x + 1, Board_y + 1].isWhite != isWhite)
                        ls.Add(new pair(Board_x + 1, Board_y + 1));
                }
                else if (Board_y == 7 && BoardManager.allPieces[Board_x + 1, Board_y - 1] != null)
                {
                    if (BoardManager.allPieces[Board_x + 1, Board_y - 1].isWhite != isWhite)
                        ls.Add(new pair(Board_x + 1, Board_y - 1));
                }
            }
        }
        else
        {//Black
            // first move
            if (Board_x == 6)
            {
                if (BoardManager.allPieces[Board_x - 1, Board_y] == null)
                {
                    ls.Add(new pair(Board_x - 1, Board_y));
                    if (BoardManager.allPieces[Board_x - 2, Board_y] == null)
                    {
                        ls.Add(new pair(Board_x - 2, Board_y));
                    }
                }


            }
            //Diagonal && middle
            if (Board_x <= 6 && Board_x >= 1)
            {
                if (BoardManager.allPieces[Board_x - 1, Board_y] == null)
                    ls.Add(new pair(Board_x - 1, Board_y));

                if (Board_y != 0 && Board_y != 7)
                {
                    if (BoardManager.allPieces[Board_x - 1, Board_y + 1] != null)
                        if (BoardManager.allPieces[Board_x - 1, Board_y + 1].isWhite != isWhite)
                            ls.Add(new pair(Board_x - 1, Board_y + 1));
                    if (BoardManager.allPieces[Board_x - 1, Board_y - 1] != null)
                        if (BoardManager.allPieces[Board_x - 1, Board_y - 1].isWhite != isWhite)
                            ls.Add(new pair(Board_x - 1, Board_y - 1));
                }
                else if (Board_y == 0 && BoardManager.allPieces[Board_x - 1, Board_y + 1] != null)
                {
                    if (BoardManager.allPieces[Board_x - 1, Board_y + 1].isWhite != isWhite)
                        ls.Add(new pair(Board_x - 1, Board_y + 1));
                }
                else if (Board_y == 7 && BoardManager.allPieces[Board_x - 1, Board_y - 1] != null)
                {
                    if (BoardManager.allPieces[Board_x - 1, Board_y - 1].isWhite != isWhite)
                        ls.Add(new pair(Board_x - 1, Board_y - 1));
                }
            }
        }


        return ls;
    }
}