using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

    public class KingMove : Move
    {
        public static bool WhiteKingisMoved = false;
        public static bool BlackKingisMoved = false;
        public override List<pair> Allowed_Moves(int Board_x, int Board_y, bool isWhite)
        {
            this.isWhite = isWhite;
            List<pair> ls = new List<pair>();
            int x = Board_x;
            int y = Board_y;
       // Castle for white king 
            if (!WhiteKingisMoved && isWhite)
            {
                if (!RookMove.LeftWhiteRookisMoved)
                  if (!Has_Ally(x, y +2) && !Has_Ally(x, y +1))
                    ls.Add(new pair(x , y +2));
                if (!RookMove.RightWhiteRookisMoved)
                    if (!Has_Ally(x, y - 2) && !Has_Ally(x, y - 1) && !Has_Ally(x, y - 3))
                     ls.Add(new pair(x, y -2));
            }
          ////////////
            // Castle for Black king 
            else if (!BlackKingisMoved && !isWhite)
            {
                if (!RookMove.LeftBlackRookisMoved)
                    if (!Has_Ally(x, y + 2) && !Has_Ally(x, y + 1))
                        ls.Add(new pair(x, y + 2));
                if (!RookMove.RigthBlackRookisMoved) 
                    if (!Has_Ally(x, y - 2) && !Has_Ally(x, y - 1)&&!Has_Ally(x, y - 3))
                        ls.Add(new pair(x, y - 2));
            }
            //////////
            if (inRange(x + 1) && inRange(y - 1) && ! Has_Ally(x + 1, y - 1))
                ls.Add(new pair(x + 1, y - 1));
            if (inRange(x + 1) && inRange(y) && ! Has_Ally(x + 1, y))
                ls.Add(new pair(x + 1, y));
            if (inRange(x + 1) && inRange(y + 1) && ! Has_Ally(x + 1, y + 1))
                ls.Add(new pair(x + 1, y + 1));
            if (inRange(x - 1) && inRange(y - 1) && ! Has_Ally(x - 1, y - 1))
                ls.Add(new pair(x - 1, y - 1)  );
            if (inRange(x - 1) && inRange(y) && ! Has_Ally(x - 1, y))
                ls.Add(new pair(x - 1, y));
            if (inRange(x - 1) && inRange(y + 1) && ! Has_Ally(x - 1, y + 1))
                ls.Add(new pair(x - 1, y + 1));  
            if (inRange(x) && inRange(y + 1) && ! Has_Ally(x, y + 1))
                ls.Add(new pair(x, y + 1));       
            if (inRange(x) && inRange(y - 1) && ! Has_Ally(x, y - 1))
                ls.Add(new pair(x, y - 1));
            return ls;

        }
    }

