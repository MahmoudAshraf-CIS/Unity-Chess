using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Timers;
 
    class Timer : MonoBehaviour 
    {
        public static float timeInSec =50;
        public static float timeReset = 50;
        public static bool counting = false;

        public TextMesh textOnPlane;

        void Start()
        {

            textOnPlane = textOnPlane.GetComponent<TextMesh>();
            Camira.rotate = true;
            textOnPlane.color = UnityEngine.Color.black;          
        }

        void Update()
        {
            

            if ( textOnPlane != null && BoardManager.running && counting )
            {
                Debug.Log("timer is working");
                timeInSec -= Time.deltaTime;

                textOnPlane.text = Mathf.RoundToInt((int)timeInSec / 60).ToString("00") + ":" + Mathf.RoundToInt((int)timeInSec % 60).ToString("00");

                if (timeInSec < 10)
                    textOnPlane.color = UnityEngine.Color.red;

                if (timeInSec < 1)
                { 
                    textOnPlane.color = UnityEngine.Color.black;
                    
                    timeInSec = timeReset +5;
                    BoardManager.WhiteTurn = !BoardManager.WhiteTurn;
                }
            }
               
        }


    }

