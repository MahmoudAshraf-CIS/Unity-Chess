using System.Runtime;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class BoardManager : MonoBehaviour {
    
    public static bool running; 
    public static Piece[,] allPieces;
    private bool endGame = false;
    private const float TileSize = 1.0f;
    private const float TileOffset = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;
    private Piece theSellectedPiece = null;

    public GameObject Graphicl_Plane;
    public GameObject HighLight;
    private GameObject [] HightLight_arr;

    private Quaternion orientation = Quaternion.Euler(-90.0f,270.0f,0);
    
    public List<GameObject> White_Team;
    public List<GameObject> Black_Team;

    public static bool WhiteTurn = true;
    public static int PawnToWhat = 4;
    //private Vector3 point = Vector3.zero;
	void Start () {
        GameObject go = (GameObject)Instantiate(Graphicl_Plane, new Vector3(4, 0, 4), orientation);  // draws the graohical plane
        go.transform.SetParent(transform);
        Initial_Draw_AllPieces();

    }
	// Update is called once per frame
	void Update () {
        Update_MouseHover();
        DrawChessBoard();
        Take_Turn();
	}

    private void HeghLight_theAllowed(List<pair> ls)
    {
        HightLight_arr = new GameObject[ls.Count];
        for (int i = 0; i < ls.Count; i++)
        {
            GameObject tile_HeighLight = (GameObject)Instantiate(HighLight,
                                                       new Vector3(ls[i].x+TileOffset , 0.01f, ls[i].y+TileOffset),
                                                       new Quaternion(0, 0, 0, 0)
                                                       );

            tile_HeighLight.transform.SetParent(transform);
            HightLight_arr[i] = tile_HeighLight;
             
        }
    }
    private void Un_HeghLight_theAllowed(List<pair> ls)
    {
        if (HightLight_arr != null)
        {
            for (int i = 0; i < ls.Count; i++)
            {
                Destroy(HightLight_arr[i]);
            }
            HightLight_arr = null;
        }
    }
    private void Take_Turn()
    {
        if (theSellectedPiece != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Un_HeghLight_theAllowed(theSellectedPiece.MovePehavior.Allowed_Moves(theSellectedPiece.Board_x, theSellectedPiece.Board_y, theSellectedPiece.isWhite));
                if (WhiteTurn == true && theSellectedPiece.isWhite == true)
                {
                    move_TheSellected_Piece(selectionX, selectionY);
                    if (!WhiteTurn)
                        Check_King();
                    Timer.timeInSec = Timer.timeReset;
                }
                else if (WhiteTurn == false && theSellectedPiece.isWhite == false)
                {
                    move_TheSellected_Piece(selectionX, selectionY);
                    if (WhiteTurn)
                        Check_King();
                    Timer.timeInSec = Timer.timeReset;
                }
                else
                {
                    theSellectedPiece = null;
                }
            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(selectionX>=0 && selectionX<=7 && selectionY>=0 && selectionY<=7)
                    theSellectedPiece = allPieces[selectionX, selectionY];
                if (theSellectedPiece != null && theSellectedPiece.isWhite == WhiteTurn)
                    HeghLight_theAllowed(theSellectedPiece.MovePehavior.Allowed_Moves(theSellectedPiece.Board_x, theSellectedPiece.Board_y, theSellectedPiece.isWhite));
                
            }
        }
    }
    private void move_TheSellected_Piece(int To_Board_x, int To_Board_y)
    {
        // check if the piece can move to a specific loction  

        if (theSellectedPiece.allowed_ToMoveTO(To_Board_x, To_Board_y) == false)
        {
            //Debug.Log("NOT allowed to move to this Tile *_* ");
            theSellectedPiece = null;
            return;
        }
            
        if (allPieces[To_Board_x, To_Board_y] != null)    // check if the selected laction if has a piece or not  
        {
            if ( allPieces[To_Board_x, To_Board_y].isWhite == theSellectedPiece.isWhite )
            {//same team
                theSellectedPiece = null;
                return; 
            }
            else
            {
                if(allPieces[To_Board_x,To_Board_y].GetType()== typeof(King)) // check the king is died 
                {
                    endGame = true;
                }
                allPieces[To_Board_x, To_Board_y].remove();
            }
        }
        allPieces[theSellectedPiece.Board_x, theSellectedPiece.Board_y].remove();
        Vector3 ve = getPiecePosOn_Board(To_Board_x, To_Board_y, theSellectedPiece.isWhite, theSellectedPiece.List_Index);
        theSellectedPiece.transform.position = ve;              /* move the sellected */
       

        theSellectedPiece.SetData(theSellectedPiece.isWhite, theSellectedPiece.List_Index, To_Board_x, To_Board_y, ve, theSellectedPiece.obj);
        theSellectedPiece.obj.SetActive(true);
        allPieces[To_Board_x, To_Board_y] = theSellectedPiece.GetComponent<Piece>();
       //  to end game 
        if (EndGame())  // check if the game is Ended 
            return;
        ////**//// 
        if (theSellectedPiece.GetType() == typeof(King) && theSellectedPiece.isWhite && !KingMove.WhiteKingisMoved)
        {
            if (To_Board_x == 0 && To_Board_y == 6 && !RookMove.LeftWhiteRookisMoved)
            {
                allPieces[0, 7].remove();
                DrawOnePieceOnBoard(0, 0, 5, true);
                RookMove.LeftWhiteRookisMoved = true;

            }
            if (To_Board_x == 0 && To_Board_y == 2 && !RookMove.RightWhiteRookisMoved)
            {
                allPieces[0, 0].remove();
                DrawOnePieceOnBoard(0, 0, 3, true);
                RookMove.RightWhiteRookisMoved = true;
            }
            KingMove.WhiteKingisMoved = true;
        }
        else if (theSellectedPiece.GetType() == typeof(King) && !theSellectedPiece.isWhite && !KingMove.BlackKingisMoved)
        {
            if (To_Board_x == 7 && To_Board_y == 6 && !RookMove.LeftBlackRookisMoved)
            {
                allPieces[7, 7].remove();
                DrawOnePieceOnBoard(0, 7, 5, false);
                RookMove.LeftBlackRookisMoved = true;

            }
            if (To_Board_x == 7 && To_Board_y == 2 && !RookMove.RigthBlackRookisMoved)
            {
                allPieces[7, 0].remove();
                DrawOnePieceOnBoard(0, 7, 3, false);
                RookMove.RigthBlackRookisMoved = true;
            }
            KingMove.BlackKingisMoved = true;
        }
        ///////////////////////
        if (theSellectedPiece.GetType() == typeof(Rook) && theSellectedPiece.Board_x == 0 && theSellectedPiece.Board_y == 0)
            RookMove.RightWhiteRookisMoved = true;
        if (theSellectedPiece.GetType() == typeof(Rook) && theSellectedPiece.Board_x == 0 && theSellectedPiece.Board_y == 7)
            RookMove.LeftWhiteRookisMoved = true;
        if (theSellectedPiece.GetType() == typeof(Rook) && theSellectedPiece.Board_x == 7 && theSellectedPiece.Board_y == 0)
            RookMove.RigthBlackRookisMoved = true;
        if (theSellectedPiece.GetType() == typeof(Rook) && theSellectedPiece.Board_x == 7 && theSellectedPiece.Board_y == 7)
            RookMove.LeftBlackRookisMoved = true;
        if (theSellectedPiece.GetType() == typeof(King) && theSellectedPiece.Board_x == 0 && theSellectedPiece.Board_y == 4)
            KingMove.WhiteKingisMoved = true;
        if (theSellectedPiece.GetType() == typeof(King) && theSellectedPiece.Board_x == 7 && theSellectedPiece.Board_y == 4)
            KingMove.BlackKingisMoved = true;
        // Promotion  
        if (theSellectedPiece.GetType() == typeof(Pawn) && To_Board_x == 7)
        {
            allPieces[To_Board_x, To_Board_y].remove();
            DrawOnePieceOnBoard(PawnToWhat, To_Board_x, To_Board_y, true);
        }
        if (theSellectedPiece.GetType() == typeof(Pawn) && To_Board_x == 0)
        {
            allPieces[To_Board_x, To_Board_y].remove();
            DrawOnePieceOnBoard(PawnToWhat, To_Board_x, To_Board_y, false);
        }
        ////////////////////////////////////////////////////////////////
        WhiteTurn = !WhiteTurn;  
        theSellectedPiece = null;
    }

    private void Initial_Draw_AllPieces()
    {
        //White_Team = new List<GameObject>();
        allPieces = new Piece[8,8];
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                allPieces[i, j] = null;
        //Black team
        DrawOnePieceOnBoard(0, 7, 0, false);//rook        
        DrawOnePieceOnBoard(1, 7, 1, false);//knight
        DrawOnePieceOnBoard(2, 7, 2, false);//bishop
        DrawOnePieceOnBoard(3, 7, 4, false);//king
        DrawOnePieceOnBoard(4, 7, 3, false);//queen
        DrawOnePieceOnBoard(2, 7, 5, false);//bishop
        DrawOnePieceOnBoard(1, 7, 6, false);//knight
        DrawOnePieceOnBoard(0, 7, 7, false);//rook
        for (int i = 8; i <= 15; i++) //pawns
            DrawOnePieceOnBoard(5 , 6, i - 8, false);

        //white team
        DrawOnePieceOnBoard(0, 0, 0, true);//rook
        DrawOnePieceOnBoard(1, 0, 1, true);//knight
        DrawOnePieceOnBoard(2, 0, 2, true);//bishop
        DrawOnePieceOnBoard(3, 0, 4, true);//king
        DrawOnePieceOnBoard(4, 0, 3, true);//queen
        DrawOnePieceOnBoard(2, 0, 5, true);//bishop
        DrawOnePieceOnBoard(1, 0, 6, true);//knight
        DrawOnePieceOnBoard(0, 0, 7, true);//rook
        for (int i = 8; i <= 15; i++) //pawns
            DrawOnePieceOnBoard(5,  1, i - 8, true);
    }
    private void DrawOnePieceOnBoard(int List_ele_index , int Board_x ,int Board_y, bool Is_White_Team)
    {
        Vector3 position = getPiecePosOn_Board(Board_x, Board_y, Is_White_Team, List_ele_index);

        GameObject go = null ;

        if (Is_White_Team)
        {
            if (White_Team[List_ele_index] != null)
                 go = (GameObject)Instantiate( White_Team[List_ele_index], position, orientation);
        }
        else
        {
            if (Black_Team[List_ele_index] != null)
                 go = (GameObject)Instantiate( Black_Team[List_ele_index], position, orientation);
        }
        go.transform.SetParent(transform);
        allPieces[Board_x, Board_y] = go.GetComponent<Piece>();
        //////////////////////////////////////   
        allPieces[Board_x, Board_y].SetData(Is_White_Team, List_ele_index, Board_x, Board_y, position , go);
        
    }

    public static Vector3 getPiecePosOn_Board(int Board_x, int Board_y,bool isWhite,int GameObject_Index)
    {
        Vector3 v3 = new Vector3(Board_x * TileSize + TileOffset , 0 , Board_y * TileSize + TileOffset);
        
        switch (GameObject_Index)
        {
            case 0://Rook
                v3.y = 0.75f;
                break;
            case 1://knight
                {
                    if (isWhite)
                    {//Wknight
                       v3.y = 1.2f;
                    }
                    else
                    {//Bknight
                        v3.y = 0.235f;
                    }
                    break;
                }
            case 2://bisho
                v3.y = 1.1f;
                break;

            case 3: //king
                v3.y = 1.146f;
                break;
            case 4: //queen
                v3.y = 1.179f;
                break;

            case 5://pawn
                v3.y = 0.644f;
                break;
        }
        return v3;    
    }
    private void DrawChessBoard(){
        //draws the empy grid
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start , start+widthLine);
                start = Vector3.right * i;
                Debug.DrawLine(start, start + heightLine);
        }
        //draw at the selected cell an X
        if (selectionY >= 0 && selectionX >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1)
                );
            Debug.DrawLine(
                 Vector3.forward * (selectionY+1) + Vector3.right * selectionX,
                 Vector3.forward * selectionY  + Vector3.right * (selectionX + 1)
                );
        }
   } 
    private void Update_MouseHover()
    {
        //sets the selectedX and selectedY accoring to the mouse hover
        if (!Camera.main)
            return;

        RaycastHit hit ;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 40.0f, LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
         //   Debug.Log(selectionX + " " + selectionY);
        }
        else
        {
            selectionX = selectionY = -1;
        }
    }
    /// Cash al King 
    private void Check_King()
    {
        List<pair> possiblemoves = allPieces[selectionX, selectionY].MovePehavior.Allowed_Moves(selectionX,
                selectionY, !WhiteTurn);

        for (int i = 0; i < possiblemoves.Count; i++)
        {
            if (allPieces[possiblemoves[i].x, possiblemoves[i].y] != null)
            {
                if (allPieces[possiblemoves[i].x, possiblemoves[i].y].GetType() == typeof(King))
                {
                    Debug.Log("Check ");
                }
            }
        }
    }
    private bool EndGame()
    {
        if (endGame)
        {
            Debug.Log("End Game");
            theSellectedPiece = null;
            WhiteTurn = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (allPieces[i, j] != null)
                        allPieces[i, j].remove();
                }
            }
            Initial_Draw_AllPieces();
            DrawChessBoard();
            endGame = false;
            return true;
        }
        return false;
    }
}
