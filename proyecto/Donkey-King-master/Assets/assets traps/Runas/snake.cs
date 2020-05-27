using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    public GameObject lighto;
    public GameObject dark;
    public bool touch;
    public GameObject ToxicFog;
    public void Start()
    {
        ToxicFog = GameObject.FindGameObjectWithTag("toxFog");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & touch == false)
        {
            dark.SetActive(true);
            lighto.SetActive(false);
            touch = true;
            ToxicFog.GetComponent<toxic>().Next();
        }
    }
}
