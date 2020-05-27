using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public GameObject Pisable;
    public GameObject noPisable;
    public bool touch;
    public bool inhibitor;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            touch = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            touch = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.wolfTouch == true & inhibitor == false)
            touch = false;

        if (Gmanager.pisada == 0)
        {
            if (touch == false)
            {
                Pisable.SetActive(false);
                noPisable.SetActive(true);
            }

            if (touch)
            {
                Pisable.SetActive(true);
                noPisable.SetActive(false);
            }
        }

        if (Gmanager.pisada == 1)
        {
            Pisable.SetActive(true);
            noPisable.SetActive(false);
        }
    }
}
