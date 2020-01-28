using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBallGenerator : MonoBehaviour
{
    public GameObject surface;
    public GameObject prefab;
    public float time;

    public SphereCollider col;
    public int index;
    Vector3 instancePos;
    private void Start()
    {
        col = surface.GetComponent<SphereCollider>();
        StartCoroutine(generator());
    }

    private void FixedUpdate()
    {
        instancePos = Random.onUnitSphere * 5.2f * col.radius + surface.transform.position;
    }


    IEnumerator generator()
    {
        while (true)
        {

            yield return new WaitForSeconds(time);
            Instantiate(prefab, instancePos, Quaternion.identity);
        }

    }


}
