using UnityEngine;
using UnityEngine.EventSystems;

public class ControlHandle: MonoBehaviour, IDragHandler,IEndDragHandler
{
    public GameObject player;
    float dragDistance = Screen.width*20/100;
    public PlayerController pC;


    public void OnDrag(PointerEventData eventData)
    {

        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > dragDistance*0.025f)
            {
                pC.direction = 1;
                pC.rotationSpeed += 15f;
               
            }

            else if(eventData.delta.x < -dragDistance*0.025f)
            {
                pC.direction = -1;
                pC.rotationSpeed += 15f;

            }

        }


    }

 
    public void OnEndDrag(PointerEventData eventData)
    {
        pC.direction = 0;
        //player.GetComponent<PlayerController>().rotationSpeed = 0;
    }



}

   

