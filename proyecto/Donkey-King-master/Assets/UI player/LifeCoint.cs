using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCoint : MonoBehaviour
{
    public GameObject[] Rice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            for (int i = 0; i < 5; i++)
            {
                Rice[i].SetActive(false);
            }

        for (int i = 0; i < Animation1.vidas; i++)
        {
            Rice[i].SetActive(true);
        }
    }
}
