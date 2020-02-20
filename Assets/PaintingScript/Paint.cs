using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {


    public GameObject brush;
    public GameObject player;
    public PlayerCollision playerCollision;

    private void Start()
    {
        StartCoroutine(Build());
    }
    void Update () {
    }
    public void Painting(GameObject brushPrefab)
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y, hit.point.z) + hit.normal * 0.1f;
            GameObject building = Instantiate(brushPrefab, pos, Quaternion.FromToRotation(Vector3.forward * -1.0f, hit.normal));
            building.transform.position = pos;
        }
    }

    IEnumerator Build()
    {
        while (true)
        {
            Painting(brush);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
