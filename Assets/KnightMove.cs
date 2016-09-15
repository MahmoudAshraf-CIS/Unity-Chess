using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
    public class KnightMove : Move
    {

        public override List<pair> Allowed_Moves(int Board_x, int Board_y, bool isWhite)
        {
            this.isWhite = isWhite;
            List<pair> ls = new List<pair>();
            if (inRange(Board_x + 2))
            {
                //right L
                if (inRange(Board_y + 1) && ! Has_Ally(Board_x + 2, Board_y + 1))
                    ls.Add(new pair(Board_x + 2, Board_y + 1));

                if (inRange(Board_y - 1) && ! Has_Ally(Board_x + 2, Board_y - 1))
                    ls.Add(new pair(Board_x + 2, Board_y - 1));
            }
            if (inRange(Board_x - 2))
            {//left L
                if (inRange(Board_y + 1) && ! Has_Ally(Board_x - 2, Board_y + 1))
                    ls.Add(new pair(Board_x - 2, Board_y + 1));

                if (inRange(Board_y - 1) && ! Has_Ally(Board_x - 2, Board_y - 1))
                    ls.Add(new pair(Board_x - 2, Board_y - 1));
            }
            if (inRange(Board_y + 2))
            {//up L
                if (inRange(Board_x + 1) && ! Has_Ally(Board_x + 1, Board_y + 2))
                    ls.Add(new pair(Board_x + 1, Board_y + 2));

                if (inRange(Board_x - 1) && ! Has_Ally(Board_x - 1, Board_y + 2))
                    ls.Add(new pair(Board_x - 1, Board_y + 2));
            }
            if (inRange(Board_y - 2))
            {//Down L
                if (inRange(Board_x + 1) && ! Has_Ally(Board_x + 1, Board_y - 2))
                    ls.Add(new pair(Board_x + 1, Board_y - 2));
                if (inRange(Board_x - 1) && ! Has_Ally(Board_x - 1, Board_y - 2))
                    ls.Add(new pair(Board_x - 1, Board_y - 2));
            }
            return ls;
        }

    }

