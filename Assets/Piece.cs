using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour {

    public int Board_x { set; get; }
    public int Board_y { set; get; }
    public Vector3 position { set; get; }

    public Move MovePehavior;

    public bool isWhite;
    public int List_Index;
    public GameObject obj;
    
   public void remove() // remove a piece  that  is died 
    {
        this.obj.SetActive(false);
        BoardManager.allPieces[Board_x, Board_y] = null;
    }
    public void SetData(bool IsWhite,int List_Index ,int Board_x,int Board_y,Vector3 position , GameObject obj)
    {
        // set a basic attrubutes for any piece 
        this.isWhite = IsWhite;
        this.List_Index = List_Index;
        this.Board_x = Board_x;
        this.Board_y = Board_y;
        this.position = position;
        this.obj = obj;
    }
    public virtual bool allowed_ToMoveTO(int x, int y)
    {// to check if the piece allowed to move or not 
        bool b = false;
        pair p = new pair(x, y);
        List<pair> ls = this.MovePehavior.Allowed_Moves(Board_x, Board_y, isWhite);
        for (int i = 0; i < ls.Count; i++)
        {
            if (p.x == ls[i].x && p.y == ls[i].y)
            {
                b = true;
                break;
            }
        }
        return b;
    }
}
