using UnityEngine;
using System.Collections.Generic;

public class King : Piece
{
    King()
    {
        this.MovePehavior = new KingMove();
    }

}
