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
    private float solderDelay = 8;
    private float spawnSpeed;
    private float spawnTime = 0;
    private int numOfSolider = 0;
    private int limitSoldier = 3;
    Vector3 destroyedPos;
    GameObject clone;
    
    bool isDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpeed = Random.Range(0,8);
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        gameObject.SetActive(false);
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
        spawnSpeed -= Time.deltaTime;

        if (!isDestroy && spawnSpeed < 0 && numOfSolider < limitSoldier && transform.position.x > leftSpawPoint && transform.position.x < RightSpawPoint && !PlayerContoller.instance.isDead)
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
            numOfSolider++;
            if(spawnTime < spawnSpeed - 2)
            {
                spawnTime++;
            }
            spawnSpeed = solderDelay;
            spawnSpeed -= spawnTime;
            if (spawnSpeed < 3)
            {
                spawnSpeed = 3;
            }
        }

       
        
    }

    void resetObj()
    {
        if(moveSpeed < 5)
            moveSpeed++;
        if(moveSpeed == 4)
        {
            moveSpeed = 1;
        }
        if(limitSoldier < 5)
            limitSoldier++;
        if (solderDelay > 3)
        {
            solderDelay--;
        }
        isDestroy = false;
        SpawnPos();
        numOfSolider = 0;
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
        AudioMgr.instance.playSfx(AudioMgr.MUSIC.GRYRO_BROKEN);

        clone = Instantiate(gryFrag, destroyedPos, Quaternion.identity);
        clone.SetActive(true);
        GameManager.instance.addPoint();
        gameObject.SetActive(false);
        isDestroy = true;
        resetObj();
    }

}
