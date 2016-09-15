using UnityEngine;
using System.Collections.Generic;

public class Rook : Piece
{
    Rook()
    {
        this.MovePehavior = new RookMove();
    }
     
}
