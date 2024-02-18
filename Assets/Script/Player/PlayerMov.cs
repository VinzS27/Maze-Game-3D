using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody rb;
    bool moveL;
    bool moveR;
    bool moveU;
    bool moveD;
    float horizontal;
    float vertical;
    public float speed = 200.0f;
    public float jumpSpeed = 5.0f;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PointerDownForward()
    {
        moveU = true;
    }

    public void PointerUpForward()
    {
        moveU = false;
    }

    public void PointerDownLeft()
    {
        moveL = true;
    }

    public void PointerUpLeft()
    {
        moveL = false;
    }
    public void PointerDownRight()
    {
        moveR = true;
    }

    public void PointerUpRight()
    {
        moveR = false;
    }

    public void PointerDownBackward()
    {
        moveD = true;
    }

    public void PointerUpBackward()
    {
        moveD = false;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (moveL)
        {
            horizontal = -speed;
        }
        else if (moveR)
        {
            horizontal = speed;
        }

        else
        {
            horizontal = 0;
        }

        if (moveU)
        {
            vertical = speed;
        }
        else if (moveD)
        {
            vertical = -speed;
        }
        else
        {
            vertical = 0;
        }
    }

    public void Jump()
    {
        if(isGrounded)
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * Time.deltaTime, 
            rb.velocity.y, vertical * Time.deltaTime);
    }
}
