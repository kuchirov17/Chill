using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    public GameObject scoreTextObj;
    private Text scoreText;
    public GameObject player;
    public GameObject cam;
    public GameObject loseText;
    public GameObject SwipeField;

    public Paint paintObj;
    public GameObject greenSplashObject;
    public GameObject redSplashObject;
    public float timeForGreen = 0;
    public float timeForRed = 0;

    int score = 0;

    private void Start()
    {
        scoreText = scoreTextObj.GetComponent<Text>();
    }

    public bool canPaint;
    public bool red;
    public bool green;
    private void Update()
    {
        if (score < 0)
        {
            score = 0;
            scoreText.text = score.ToString();
        }


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="ball")
        {
            //StopAllCoroutines();
            //StartCoroutine(paintingTimeForGreen());
            collision.gameObject.SetActive(false);
            score++;
            scoreText.text = score.ToString();
        }

        if (collision.gameObject.tag == "enemy")
        {
           // StopAllCoroutines();
           //StartCoroutine(paintingTimeForRed());
            collision.gameObject.SetActive(false);
            score--;
            scoreText.text = score.ToString();
        }
    }


     IEnumerator paintingTimeForGreen()
    {
        timeForGreen += 1f;
        paintObj.enabled = true;
        paintObj.brush = greenSplashObject;
        yield return new WaitForSeconds(timeForGreen);
        paintObj.enabled = false;
        paintObj.brush = null;
        timeForGreen = 0f;
    }
    IEnumerator paintingTimeForRed()
    {
        timeForRed += 1f;
        paintObj.enabled = true;
        paintObj.brush = redSplashObject;
        yield return new WaitForSeconds(timeForRed);
        paintObj.enabled = false;
        paintObj.brush = null;
        timeForRed = 0;

    }

    IEnumerator reloadGame()
    {
        loseText.SetActive(true);
        for(byte opasity = 0; opasity != 255; opasity++)
        {
            yield return new WaitForSeconds(0.01f);
            loseText.GetComponent<Text>().color = new Color32(0, 0, 0, opasity);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
