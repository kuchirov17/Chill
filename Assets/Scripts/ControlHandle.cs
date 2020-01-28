using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlHandle: MonoBehaviour, IDragHandler,IEndDragHandler
{
    public bool left;
    public bool right;
    public GameObject player;
    float dragDistance = Screen.height*20/100;


    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))

        {
            
            if (eventData.delta.x > 10)
            {
                Debug.Log("Right");
                player.GetComponent<PlayerController>().rotation = 1;
            }
            else if(eventData.delta.x < -10)
            {
                Debug.Log("Left");
                player.GetComponent<PlayerController>().rotation = -1;
            }


        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        player.GetComponent<PlayerController>().rotation = 0;


    }

}
