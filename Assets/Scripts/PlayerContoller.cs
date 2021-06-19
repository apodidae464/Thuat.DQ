using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public Animator anim;
    public GameObject gun;
    public GameObject firer;
    public GameObject ciu;
    public GameObject box;
    public GameObject cat;
    public float speed;
    public static PlayerContoller instance;
    private float fireRate;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        box.SetActive(false);
        cat.SetActive(false);
        fireRate = 0;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            ControlAndFire();
        }
    }

    private void ControlAndFire()
    {
        fireRate -= Time.deltaTime;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.y < transform.position.y)
        {
            Vector3 lookat = new Vector3(mousePos.x - transform.position.x, 0, 0);
            gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, lookat);
        }
        else
        {
            gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (fireRate < 0)
            {
                Instantiate(firer, ciu.transform.position, ciu.transform.rotation);
                AudioMgr.instance.playSfx(AudioMgr.MUSIC.FIRE);
                fireRate = 0.25f;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Soldier")
        {
            isDead = true;
            ciu.SetActive(false);
            box.SetActive(true);
            anim.SetBool("catdead", true);
            AudioMgr.instance.playSfx(AudioMgr.MUSIC.PLAYER_DEAD);
        }
    }

    void PlayerDead()
    {
        gameObject.SetActive(false);
        cat.SetActive(true);
    }
}
