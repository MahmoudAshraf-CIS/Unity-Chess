using UnityEngine;
using System.Collections;

public class Camira : MonoBehaviour {

    public static bool rotate = false;
    public static int x=3, y=3;

    //Quaternion WhiteOrientation = new Quaternion(70, 90, 5,0);  
    //Quaternion WhiteOrientation = new Quaternion(3,3,3,3);
    Vector3 WhiteTurn_pos = new Vector3(-4.5f, 22, 4);
    Vector3 BlackTurn_pos = new Vector3(12.5f, 22, 4);

    //public Transform target;
    //public float speed;
    //public float distance;
    //private float currentAngle = 0;

  

	// Use this for initialization
	void Start () {
        TurnView();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (rotate)
            transform.RotateAround(BoardManager.getPiecePosOn_Board( x,y, true, 2), Vector3.up, Time.deltaTime * 10.0f);
        //if(!BoardManager.runing)
        //    transform.RotateAround(BoardManager.getPiecePosOn_Board(3,3, true, 2), Vector3.up, Time.deltaTime * 10.0f);

        TurnView();
	}
    void TurnView()
    {
        float t = 0.0f;
        Vector3 start = transform.position;

        if (BoardManager.WhiteTurn)
        {
            Camera.main.transform.rotation = Quaternion.Euler(70.0f, 90.0f, 0);
            //transform.position = WhiteTurn_pos;

            while (t < 20.0f)
            {
                t += Time.deltaTime * (Time.timeScale / 0.00005f);
                transform.position = Vector3.Lerp(start, WhiteTurn_pos, t);
            }
        }
        else
        {
            Camera.main.transform.rotation = Quaternion.Euler(70.0f, 270.0f, 0);
            //transform.position = BlackTurn_pos;

            while (t < 20.0f)
            {
                t += Time.deltaTime * (Time.timeScale / 0.00005f);
                transform.position = Vector3.Lerp(start, BlackTurn_pos, t);
            }
        }
    }
    public static void Start_Rotation(int Board_x,int Board_y){
        rotate = true;
        x = Board_x;
        y = Board_y;
    }

    public static void Stop_Rotation()
    {
        rotate = false;
    }

}
