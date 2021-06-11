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
        anim.SetBool("onGround", onGround);
        if (onGround && PlayerContoller.instance)
        {
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
        rb.AddForce(-transform.up);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Firer" || collision.tag == "Soldier")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "something")
        {
            onGround = true;
        }
    }

    
}
