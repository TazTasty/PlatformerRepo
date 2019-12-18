using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //publIc variables (Movement)
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJump = 2;
    //public variables (Animator)
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Script
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if(Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }
        float x = Input.GetAxisRaw("Horizontal");
        //x velocity animator

        if (velocity.x == 0)
        {
            anim.SetInteger("x", 0);
        }
        else
        {
            anim.SetInteger("x", 1);
        }
        //y velocity animator
        
        if (velocity.y > 0)
        {
            anim.SetInteger("y", 1);
        }
        else if (velocity.y < 0)
        {
            anim.SetInteger("y", -1);
        }
        else
        {
            anim.SetInteger("y", 0);
        }
        if(x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } 
    }
        public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
    }
    //grounded defined
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            anim.SetBool("grounded", grounded);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            anim.SetBool("grounded", grounded);
        }

    }
        private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
        anim.SetBool("grounded", grounded);
    }
}
