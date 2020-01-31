using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformsGenerator : MonoBehaviour
{
    public GameObject[] transforms=new GameObject[100];
    public GameObject planet;
    public GameObject prefab;
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            transforms[i] = Instantiate(prefab, Random.onUnitSphere *5.1f*planet.GetComponent<SphereCollider>().radius+planet.transform.position, Quaternion.identity) as GameObject;
        }

    }
    void Update()
    {
        
    }
}
