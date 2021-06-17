using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firer : MonoBehaviour
{
    Collider2D firerColl;
    Rigidbody2D firerRb;
    public float speed;
    ParticleSystem par;
    // Start is called before the first frame update
    void Start()
    {
        firerColl = GetComponent<Collider2D>();
        firerRb = GetComponent<Rigidbody2D>();
        par = GetComponent<ParticleSystem>();
        par.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        firerRb.AddForce(transform.up * speed * 500 * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "FirerBox" || collision.tag == "Soldier" || collision.tag == "Gryro")
        {
            Destroy(gameObject, par.main.duration);
        }
    }
}
