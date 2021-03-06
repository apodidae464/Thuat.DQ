using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GryroSpawnBox : MonoBehaviour
{
    
    public GameObject gryro;

    public int numOfGryPerFrame;
    public List<GameObject> gryros = new List<GameObject>();
    GameObject temp;
    float speed = 0;
    int limitGry = 20;
    int numOfGry = 1;
    int speedUp = 0;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        AudioMgr.instance.pauseBMG2();
        
        for (int i = 0; i < limitGry; i++)
        {
            temp = Instantiate(gryro);
            gryros.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(i == numOfGry)
        {
            i = 0;
        }
        speed -= Time.deltaTime;
        if(speed < 0 && numOfGry > 0)
        {
            for(int j = 0; j < numOfGry; j++)
            {
                if(!gryros[j].activeInHierarchy && j == i)
                {
                    gryros[j].SetActive(true);
                    i++;
                    break;
                }
            }
            if(numOfGry < limitGry)
            {
                numOfGry++;
            }
            speed = 5 - speedUp;
            if (speedUp < 4)
                speedUp++;
        }
        
        
    }
    
    
}
