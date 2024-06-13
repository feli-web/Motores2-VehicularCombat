using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float accelerationSpeed = 5f;
    public float brakeSpeed = 3f;
    public float rotationSpeed = 100f;
    
    private Animator animator;
    private Rigidbody2D rb;

    float verticalInput;

    public float planetPushback = 3f;

    void Start()
    {
        float x = Random.Range(-31f, -4f);
        float y = Random.Range(-31f, -4f);
        this.transform.position = new Vector2((float)x, (float)y);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {        

        // Rotate
        float horizontalInput = Input.GetAxis("Horizontal");
        if (verticalInput > 0)
        {
            transform.Rotate(Vector3.forward, horizontalInput * -rotationSpeed * Time.deltaTime);
        }


        animator.SetFloat("Speed", verticalInput);

    }
    public void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            rb.drag = 0;
            rb.AddForce(transform.up * verticalInput * accelerationSpeed * Time.deltaTime);
        }
        else if (verticalInput <= 0)
        {
            rb.drag = (brakeSpeed * Time.deltaTime);
        }
        

       /* if (verticalInput <= 0)
        {
            rb.angularVelocity = -rb.angularVelocity;
        }*/
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Limit") || collision.gameObject.CompareTag("Red Planet"))
        {
            Vector2 pushbackDirection = -(collision.contacts[0].point - (Vector2)transform.position).normalized;

            // Apply pushback force
            rb.AddForce(pushbackDirection * planetPushback, ForceMode2D.Impulse);
        }
    }
}
