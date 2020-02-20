using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Paint : MonoBehaviour {


    public GameObject brush;
    public GameObject player;
    public PlayerCollision playerCollision;
    private Vector3 spawnPos;

    public GameObject loseText;
    public bool GameOver;

    private void Start()
    {
        StartCoroutine(Build());
    }
    void Update () {
        if (GameOver)
        {
            StartCoroutine(reloadGame());
            player.GetComponent<PlayerController>().moveSpeed = 0;

        }
    }
    public void Painting(GameObject brushPrefab)
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y, hit.point.z) + hit.normal * 0.1f;
            GameObject building = Instantiate(brushPrefab, pos, Quaternion.FromToRotation(Vector3.forward * -1.0f, hit.normal));
            StartCoroutine(scale(building, Random.Range(0.2f,1.3f)));
            StartCoroutine(enableCollision(building));
            
        }
    }

    IEnumerator scale(GameObject prefab, float scaleSize)
    {
        for(float i = 0; i < scaleSize; i+=0.1f)
        {
            prefab.transform.localScale = new Vector3(prefab.transform.localScale.x, prefab.transform.localScale.y,i);
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator Build()
    {
        while (!GameOver)
        {
            Painting(brush);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator enableCollision(GameObject prefab)
    {
        yield return new WaitForSeconds(0.5f);
        prefab.AddComponent<BuildingCollision>();

    }

    IEnumerator reloadGame()
    {
        loseText.SetActive(true);
        for (byte opasity = 0; opasity != 255; opasity++)
        {
            yield return new WaitForSeconds(0.0001f);
            loseText.GetComponent<Text>().color = new Color32(0, 0, 0, opasity);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
