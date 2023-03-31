using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float PlayerMoveSpeed = 4f; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,PlayerMoveSpeed* horizontalInput);

        if (Input.GetKey(KeyCode.Space))
        {
        }
    }
}
