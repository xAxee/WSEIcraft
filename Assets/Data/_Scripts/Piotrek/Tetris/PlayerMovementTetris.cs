using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementTetris : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public float fallSpeed = 40f;
    public bool isGrounded = false;
    private Vector3 movement;

    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (inputHorizontal < 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -90f,0f), 1);
        else if(inputHorizontal > 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 90f ,0f), 1);
        //transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        movement = new Vector3(inputHorizontal * speed, rb.velocity.y, rb.velocity.z);

        rb.velocity = movement;
        animator.SetFloat("MoveSpeed", Mathf.Abs(inputHorizontal));
        //Debug.Log(rb.velocity.y);

        //if (rb.velocity.y < 0 && !Input.GetKey(KeyCode.W)) rb.velocity = new Vector3(rb.velocity.x, -Mathf.Abs(rb.velocity.y * fallSpeed * Time.fixedDeltaTime), rb.velocity.z);
        //if (rb.velocity.y < -15) rb.velocity = new Vector3(rb.velocity.x, -15, rb.velocity.z);
    }

    void LateUpdate()
    {
        if (movement == Vector3.zero)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.2f))
        { //TODO Mozna skakac gdy dotknie sie sciany
            isGrounded = true;
            animator.SetBool("Grounded", true);
        }

    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        animator.SetBool("Grounded", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Debug.Log("test");
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

}
