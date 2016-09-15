using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
    public class QueenMove : Move
    { 
        public override List<pair> Allowed_Moves(int Board_x, int Board_y, bool isWhite)
        {
            List<pair> ls = new List<pair>();
            this.isWhite = isWhite;
            /*************************************Rook*****/
            int x = Board_x;
            int y = Board_y - 1;
            //Down
            while (y >= 0)
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
                y--;
            }
           
            //left
            x = Board_x;
            y = Board_y + 1;
            while (y <= 7)
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
                y++;
            }
            
            //ahead
            x = Board_x + 1;
            y = Board_y;
            while (x <= 7)
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
                x++;
            }
            
            //backword
            x = Board_x - 1;
            y = Board_y;
            while (x >= 0)
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
                x--;
            }
            if (x >= 0)
            {
                if (BoardManager.allPieces[x, y].isWhite != isWhite)
                    ls.Add(new pair(x, y));
            }
            /*************************************************Bishop***/
            x = Board_x + 1;
            y = Board_y - 1;

            // /up x++ , y--
            while (x <= 7 && y >= 0)
            {
                if (BoardManager.allPieces[x, y] != null)
                {
                    if (BoardManager.allPieces[x, y].isWhite != isWhite)
                        ls.Add(new pair(x, y));
                    break ;
                }
                else
                {
                    ls.Add(new pair(x, y));
                }
                x++; y--;
            }
            

            // \up x++ , y++
            x = Board_x + 1;
            y = Board_y + 1;
            while (x <= 7 && y <= 7)
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
             
            // /down x-- , y++
            x = Board_x - 1;
            y = Board_y + 1;
            while (x >= 0 && y <= 7)
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
             
            // \down x-- , y--
            x = Board_x - 1;
            y = Board_y - 1;
            while (x >= 0 && y >= 0)
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

