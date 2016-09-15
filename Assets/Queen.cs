using UnityEngine;
using System.Collections.Generic;

public class Queen : Piece
{
    Queen()
    {
        this.MovePehavior = new QueenMove();
    }
}
