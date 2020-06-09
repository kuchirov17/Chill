using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject game;
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        game.SetActive(true);
    }

}
