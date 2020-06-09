using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformsGenerator : MonoBehaviour
{
    public GameObject[] transforms=new GameObject[1000];
    public GameObject planet;
    public GameObject prefab;
    public GameObject parentPositions;
    void Start()
    {
        for(int i = 0; i < 1000; i++)
        {
            transforms[i] = Instantiate(prefab, Random.onUnitSphere *5.1f*planet.GetComponent<SphereCollider>().radius+planet.transform.position, Quaternion.identity) as GameObject;
            transforms[i].transform.SetParent(parentPositions.transform);
        }

    }
    void Update()
    {
        
    }
}
