using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    public float direction;
    private Rigidbody rb;
    public GameObject SwipeHandlerObj;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(checkDir());
    }

    public Vector3 yRotation = Vector3.zero;
    float oldDir;
    void FixedUpdate()
    {
        oldDir = direction;
        if (rotationSpeed > 300) rotationSpeed = 300;
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        yRotation = Vector3.up * oldDir * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
    }


    float newDir;
    IEnumerator checkDir()
    {
        
        while (true)
        {
            yield return new WaitForEndOfFrame();
            newDir = direction;

            if (oldDir != newDir)
            {
                Debug.Log("DIRECTION IS CHANGED!");
                rotationSpeed = 0;
            }
            else
            {
                Debug.Log("old Direction");
            }
        }
    }
}
