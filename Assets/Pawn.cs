using UnityEngine;
using System.Collections.Generic;

public class Pawn : Piece {
    Pawn()
    {
        this.MovePehavior = new PawnMove();
    }
}
