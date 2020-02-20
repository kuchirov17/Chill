using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transforms : MonoBehaviour
{
    public bool isVisible;

       private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "PlayerPos")
            {
                isVisible = true;
                Debug.Log("isVisible");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "PlayerPos")
            {
                isVisible = false;
                Debug.Log("isnt Visible");
            }
        }
}
