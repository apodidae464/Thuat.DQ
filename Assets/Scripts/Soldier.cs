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
    private float increSpeedTime = 10;
    bool isDestroyed;
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
        increSpeedTime -= Time.deltaTime;
        if(increSpeedTime < 0)
        {
            increSpeedTime = 10;
            speed++;
        }
        if(isDestroyed)
        {
            GameManager.instance.addPoint();
            isDestroyed = false;
            Destroy(gameObject);

        }
    }

    private void FixedUpdate()
    {
        if(!onGround)
            rb.AddForce(-transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Firer")
        {
            isDestroyed = true;
            int r = Random.Range(0, 2);
            if (r == 1)
                AudioMgr.instance.playSfx(AudioMgr.MUSIC.OH_NO);
            AudioMgr.instance.playSfx(AudioMgr.MUSIC.SOLDIER_HURT);
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
