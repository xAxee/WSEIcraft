using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrBlok : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.y > 0) rb.velocity = Vector3.down;
    }
}
