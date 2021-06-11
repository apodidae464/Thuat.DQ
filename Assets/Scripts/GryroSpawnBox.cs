using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GryroSpawnBox : MonoBehaviour
{
    
    public GameObject gryro;

    public int numOfGryPerFrame;

    int count = 1000;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gryro);
    }

    // Update is called once per frame
    void Update()
    {

        count--;
        if(count < 0)
        {
            int time = Random.Range(1, 4);
            for (int i = 0; i < time; i ++)
            {
                Instantiate(gryro);
            }
            count = 1000;
        }



    }

}
