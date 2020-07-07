using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * 1.5f * Time.deltaTime;
    }

    void DoSomething()
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(1f, 0.5f, 0f);

    }
}
