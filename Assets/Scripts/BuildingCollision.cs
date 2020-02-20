using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildingCollision : MonoBehaviour
{
    bool gameOver = false;
    public GameObject Builder;
    private void Start()
    {
        Builder = GameObject.FindWithTag("MainCamera");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You DEAD");
            Builder.GetComponent<Paint>().GameOver = true;
        }
    }

  
}
