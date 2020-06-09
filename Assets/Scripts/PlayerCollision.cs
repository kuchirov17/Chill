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

    [SerializeField] 
    private Material green;
    [SerializeField]
    private Material red;

    int score = 0;

    private void Start()
    {
        scoreText = scoreTextObj.GetComponent<Text>();
    }

    private void Update()
    {
        if (score < 0)
        {
            score = 0;
            scoreText.text = score.ToString();
            player.GetComponent<PlayerController>().moveSpeed = 0;
            StartCoroutine(reloadGame());
            SwipeField.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.SetActive(false);
            score++;
            scoreText.text = score.ToString();
            player.GetComponent<PlayerController>().moveSpeed += 0.1f;

        }

        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.SetActive(false);
            score--;
            scoreText.text = score.ToString();
            player.GetComponent<PlayerController>().moveSpeed-=0.1f;
        }
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
