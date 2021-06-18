using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GryroFragment : MonoBehaviour
{
    public GameObject[] gryroFrag;
    public GameObject target;
    public GameObject root;
    Vector2 direct;
    Vector2 perpen;
    bool isForce = false;
    int time;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(100, 500);
        
    }

        // Update is called once per frame
        void Update()
    {
        if(!isForce)
        {
            direct.x = target.transform.position.x - root.transform.position.x;
            direct.y = target.transform.position.y - root.transform.position.y;
            for (int i = 0; i < gryroFrag.Length; i++)
            {
                int r = Random.Range(-10, 10);

                perpen.x = direct.y * 1 - 0 * 0;
                perpen.y = 0 * 0 - direct.x * 1;
                if (i % 2 == 0)
                {
                    gryroFrag[i].GetComponent<Rigidbody2D>().AddForce(perpen * r);
                }
                else
                {
                    gryroFrag[i].GetComponent<Rigidbody2D>().AddForce(-perpen * r);
                }
                time--;
                if(time < 0)
                    isForce = true;
            }
        
        }
        
        
    }
    

}
