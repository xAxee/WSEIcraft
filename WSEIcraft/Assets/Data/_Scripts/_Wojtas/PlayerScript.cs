using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float playerMoveSpeed = 4f;
    [SerializeField] float jumpForce = 4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,playerMoveSpeed* horizontalInput);

        animator.SetFloat("MoveSpeed", playerMoveSpeed*horizontalInput);

        if (isGrounded())
        {
            animator.SetBool("Grounded", true);
        }
        else
        {
            animator.SetBool("Grounded", false);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            jump();
        }
        if(transform.position.y < 0)
        {
            playerDied();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyHead")) 
        {
            Destroy(other.transform.parent.gameObject);
            jump();
        }
        else if (other.gameObject.CompareTag("DestroyableBlock"))
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    }
    public void playerDied()
    {
        //transform.position = new Vector3(0, 1, 0);
        SceneManager.LoadScene("Mario");
    }
    public void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
