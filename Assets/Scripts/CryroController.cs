using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryroController : MonoBehaviour
{

    Rigidbody2D rb;
    Collider2D col;

    public float leftSpawPoint;
    public float RightSpawPoint;

    public Animator anim;
    public GameObject soldier;
    public GameObject root;
    public GameObject gryFrag;

    public float moveSpeed;
    public bool goToLeft;
    private float solderDelay = 500;
    private int numOfSolider = 0;
    float timeLife = 1000;

    private bool isDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        gameObject.SetActive(false);
        gryFrag.SetActive(false);
        SpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(!goToLeft)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }

        solderDelay--;
        if (!isDestroy && solderDelay < 0 && numOfSolider < 3 && transform.position.x > leftSpawPoint && transform.position.x < RightSpawPoint)
        {
            if (transform.position.x > root.transform.position.x)
            {
                soldier.transform.localScale = new Vector3(-1, 1, 1);
                Instantiate(soldier, transform.position, Quaternion.identity);
            }
            else
            {
                soldier.transform.localScale = new Vector3(1, 1, 1);
                Instantiate(soldier, transform.position, Quaternion.identity);
            }
            solderDelay = 500;
            numOfSolider++;
        }

        if(isDestroy)
        {
            timeLife--;
            if(timeLife < 0)
            {
                if(gameObject.activeInHierarchy)
                {
                    gameObject.SetActive(false);
                    timeLife = 1000;
                }
            }
        }
    }


    
    public void SpawnPos()
    {
        int r = Random.Range(2, 5);
        int lr = Random.Range(0, 2);
        int z = Random.Range(0, 1);
        if(lr == 0)
        {
            float left = Random.Range(-12, -10);
            gameObject.transform.position = new Vector3(left, r, z);
            rb.transform.localScale = new Vector3(1, 1, 1);
            goToLeft = false;
        }
        else
        {
            float right = Random.Range(10, 12);
            gameObject.transform.position = new Vector3(right, r, z);
            rb.transform.localScale = new Vector3(-1, 1, 1);
            goToLeft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GryroSpawnBox")
        {
            if(gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
                SpawnPos();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Firer")
        {
            anim.SetBool("destroyed", true);
            isDestroy = true;
        }
    }

    public void onGryroDestroyed()
    {
       
        if (!gryFrag.activeInHierarchy)
        {
            gryFrag.SetActive(true);
        }
        
    }
}
