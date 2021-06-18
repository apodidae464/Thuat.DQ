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
    private float solderDelay = 800;
    private float spawnSpeed = 0;
    private int numOfSolider = 0;
    private int limitSoldier = 3;
    float timeLife = 1000;
    Vector3 destroyedPos;
    GameObject clone;
    bool canAddPoint;
    
    bool isDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        gameObject.SetActive(false);
        SpawnPos();
        canAddPoint = false;
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
        if (!isDestroy && solderDelay < 0 && numOfSolider < limitSoldier && transform.position.x > leftSpawPoint && transform.position.x < RightSpawPoint)
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
            solderDelay = 800 - spawnSpeed;
            numOfSolider++;
        }

        if (canAddPoint)
        {
            GameManager.instance.addPoint();
            canAddPoint = false;
        }
        if (isDestroy)
        {
            timeLife--;
            if(timeLife < 0)
            {
                if (gameObject.activeInHierarchy)
                {
                    DestroyFrag();
                    gameObject.SetActive(false);
                    resetObj();
                }
            }
        }
    }

    void resetObj()
    {
        moveSpeed++;
        limitSoldier++;
        if (spawnSpeed < 500)
        {
            spawnSpeed++;
        }
        isDestroy = false;
        SpawnPos();
        timeLife = 1000;
        numOfSolider = 0;
        moveSpeed++;
    }

    
    public void SpawnPos()
    {
        int r = Random.Range(2, 5);
        int lr = Random.Range(0, 2);
        if(lr == 0)
        {
            gameObject.transform.position = new Vector3(-10, r, 0);
            rb.transform.localScale = new Vector3(1, 1, 1);
            goToLeft = false;
        }
        else
        {
            gameObject.transform.position = new Vector3(10, r, 0);
            rb.transform.localScale = new Vector3(-1, 1, 1);
            goToLeft = true;
        }
    }

    void DestroyFrag()
    {
        Destroy(clone);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Firer")
        {
            anim.SetBool("destroyed", true);
            destroyedPos = new Vector3(transform.position.x, transform.position.y,transform.position.z);
        }
        if (collision.tag == "horizon")
        {
            if (gameObject.activeInHierarchy)
            {
                resetObj();
            }
        }
    }

    public void onGryroDestroyed()
    {
        clone = Instantiate(gryFrag, destroyedPos, Quaternion.identity);
        clone.SetActive(true);
        isDestroy = true;
        canAddPoint = true;
    }
}
