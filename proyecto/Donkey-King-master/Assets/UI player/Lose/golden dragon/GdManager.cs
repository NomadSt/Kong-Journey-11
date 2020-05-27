using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GdManager : MonoBehaviour
{
    public GameObject[] Gd;
    public float tryes;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("gd") != null)
        {
            Gd = GameObject.FindGameObjectsWithTag("gd");
            tryes = Random.Range(0, 3);
            //print("tryes ="+tryes);
            foreach (GameObject i in Gd)
            {
                i.SetActive(false);
            }
            if (tryes > 0)
                Spawn();
        }



    }
    public void Spawn()
    {
        if (GameObject.FindGameObjectsWithTag("gd") != null)
        {
            tryes--;

            Gd[Random.Range(0, Gd.Length)].SetActive(true);

            if (tryes > 0)
                Spawn();
        }

    }
}
