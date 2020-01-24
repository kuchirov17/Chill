using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlHandle: MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool left;
    public bool right;
    public GameObject player;
    float dragDistance = Screen.height*20/100;

    public void OnBeginDrag(PointerEventData eventData)
    {
        /*
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))

        {

            if (eventData.delta.x > 0)
            {
                Debug.Log("Right");
                player.GetComponent<PlayerController>().rotation = 1;
            }
            else
            {
                Debug.Log("Left");
                player.GetComponent<PlayerController>().rotation = -1;
            }

         
        }

        else

        {

            if (eventData.delta.y > 0) Debug.Log("Up");

            else Debug.Log("Down");
        }*/
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))

        {
            
            if (eventData.delta.x > 20)
            {
                Debug.Log("Right");
                player.GetComponent<PlayerController>().rotation = 1;
            }
            else if(eventData.delta.x < -20)
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

    

   /* private void OnMouseDrag()
    {

        GetComponent<Image>().color = new Color32(255, 255, 255, 150);

        if (left)
        {
            player.GetComponent<PlayerController>().rotation = -1;
        }

        if (right)
        {
            player.GetComponent<PlayerController>().rotation = 1;
        }
    }

    private void OnMouseUp()
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        player.GetComponent<PlayerController>().rotation = 0;


    }

    */
}
