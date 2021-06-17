using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GryroSpawnBox : MonoBehaviour
{
    
    public GameObject gryro;

    public int numOfGryPerFrame;
    public List<GameObject> gryros = new List<GameObject>();
    GameObject temp;
    int speed = 1000;
    int numOfGry = 20;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gryro);
        for (int i = 0; i < numOfGry; i++)
        {
            temp = Instantiate(gryro);
            gryros.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed--;
        if(speed < 0 && numOfGry > 0)
        {
            for(int i = 0; i < numOfGry; i++)
            {
                if(!gryros[i].activeInHierarchy)
                {
                    gryros[i].SetActive(true);
                    break;
                }
            }
            speed = 500;
            
        }
        
    }
    
    
}
