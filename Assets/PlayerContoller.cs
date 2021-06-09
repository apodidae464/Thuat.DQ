using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public GameObject gun;
    public GameObject firer;
    public GameObject ciu;
    public float speed;
    public static PlayerContoller instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && gun.transform.rotation.z < 0.7)
        {
            gun.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && gun.transform.rotation.z > -0.7)
        {
            gun.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Instantiate(firer, ciu.transform.position, ciu.transform.rotation);
            
        }    
    }
}
