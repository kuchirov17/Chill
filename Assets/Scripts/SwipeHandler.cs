using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeHandler : MonoBehaviour
{

    public GameObject Player;
    private void Start()
    {
    }

    public float sensitivity = 100f;
    public float turnTreshold = 5f;
    private Vector3 mouseStartPos;
    private Vector3 mouseEndPos;

    float deltaRot;
    float startRot;

    public float distance;
    public void Update()
    {
        var mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            //startRot = Player.GetComponent<PlayerController>().rotation;
            mouseStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            mouseEndPos = Input.mousePosition;
            Vector3 delta = mouseEndPos - mouseStartPos;
            distance = (mousePos - mouseStartPos).magnitude;
            if (distance > sensitivity)
            {
                Player.GetComponent<PlayerController>().rotationSpeed =Mathf.Abs(delta.x);
            }

            if (distance > turnTreshold)
            {
                if (distance > sensitivity)
                {
                    Player.GetComponent<PlayerController>().rotationSpeed = Mathf.Abs(distance);
                    
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Player.GetComponent<PlayerController>().rotationSpeed = 0;

        }

    }

}

/*
        if (Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            Debug.Log(mPosDelta.x);
            Player.GetComponent<PlayerController>().rotationSpeed = mPosDelta.x;

            if (mPosDelta.x > 0)
            {
                Player.GetComponent<PlayerController>().rotation = 1;
            }
            if (mPosDelta.x < 0)
            {
                Player.GetComponent<PlayerController>().rotation = -1;
            }
          
        }
        mPrevPos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            Player.GetComponent<PlayerController>().rotation = 0;
        }

        */

/*{
    public GameObject player;
    private Vector2 touchPos;
    public float swipeDistX = 70000.0f;
    private float dragDistance;
    private float f_difX;
    private float f_lastX;

    private void Start()
    {
        dragDistance = Screen.width * 5 / 100;
        player = GameObject.Find("Player");
    }
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             touchPos=Input.mousePosition;
         }
         else if (Input.GetMouseButton(0))
         {
             Vector2 deltaSwipe = touchPos - (Vector2)Input.mousePosition;

             if (Mathf.Abs(deltaSwipe.x) > dragDistance)
             {
                 player.GetComponent<PlayerController>().rotation = 1;
                 player.GetComponent<PlayerController>().rotationSpeed *= (0.01f*deltaSwipe.x);
             }
            else if(Input.mousePosition.x < touchPos.x && Mathf.Abs(deltaSwipe.x) > dragDistance)
            {
                player.GetComponent<PlayerController>().rotation = -1;
                player.GetComponent<PlayerController>().rotationSpeed *= (0.01f * deltaSwipe.x);
            }


        }

        else if (Input.GetMouseButtonUp(0))
        {
            player.GetComponent<PlayerController>().rotation = 0;
        }

        /* if (Input.GetMouseButtonDown(0))
         {
             f_difX = 0.0f;
         }
         else if (Input.GetMouseButton(0))
         {
             f_difX = Mathf.Abs(f_lastX - Input.GetAxis("Mouse X"));

             if (f_lastX < Input.GetAxis("Mouse X")*dragDistance)
             {
                 Debug.Log("Right");
                 player.GetComponent<PlayerController>().rotation = 1;
             }

             if (f_lastX > Input.GetAxis("Mouse X")*dragDistance)
             {
                 Debug.Log("Left");
                 player.GetComponent<PlayerController>().rotation = -1;
             }

             f_lastX = -Input.GetAxis("Mouse X");
         }
         else if (Input.GetMouseButtonUp(0))
         {
             player.GetComponent<PlayerController>().rotation = 0;
         }
    }

}
*/
