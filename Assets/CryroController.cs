using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryroController : MonoBehaviour
{

    Rigidbody2D rb;
    Collider2D col;

    public GameObject soldier;

    public float moveSpeed;
    public bool goToLeft;
    private float solderDelay = 500;
    private int numOfSolider = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
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
        if (solderDelay < 0 && numOfSolider < 3)
        {
            Instantiate(soldier, transform.position, Quaternion.identity);
            solderDelay = 500;
            numOfSolider++;
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
            goToLeft = false;
        }
        else
        {
            float right = Random.Range(10, 12);
            gameObject.transform.position = new Vector3(right, r, z);
            goToLeft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GryroSpawnBox")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Gryro" && collision.transform.position.z == gameObject.transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Firer")
        {
            Destroy(gameObject);
        }
    }
}
