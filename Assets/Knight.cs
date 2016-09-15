using UnityEngine;
using System.Collections.Generic;

public class Knight : Piece
{
    Knight()
    {
        this.MovePehavior = new KnightMove();
    }
}
