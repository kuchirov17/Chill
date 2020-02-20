using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballGenerator : MonoBehaviour
{
    public GameObject surface;
    public GameObject prefab;
    public float time;

    Vector3 instancePos;

  
    public transformsGenerator generatorOfTransforms;
    private void Start()
    {
        StartCoroutine(generator());
    }

    private void Update()
    {
        GameObject pos = generatorOfTransforms.transforms[Random.Range(0, 99)];
        if (pos.GetComponent<Transforms>().isVisible == false)
        {
            instancePos = pos.transform.position;
        }
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
