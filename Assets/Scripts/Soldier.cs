using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;
    bool onGround = false;
    public Animator anim;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround && PlayerContoller.instance)
        {
            anim.SetBool("onGround", onGround);
            col.isTrigger = true;
            if(transform.position.x < PlayerContoller.instance.transform.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
            } 
            else
            {
                rb.transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(-speed, 0);

            }

        }
    }

    private void FixedUpdate()
    {
        if(!onGround)
            rb.AddForce(-transform.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Firer")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "something")
        {
            onGround = true;
        }
        if(collision.tag == "Player")
        {
            rb.AddForce(transform.up * 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "border")
        {
            Destroy(gameObject);

        }
    }

}
