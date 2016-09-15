using UnityEngine;
using System.Collections.Generic;

public class Bishop : Piece
{
    Bishop()
    {
        this.MovePehavior = new BishopMove();
    }
  
}
