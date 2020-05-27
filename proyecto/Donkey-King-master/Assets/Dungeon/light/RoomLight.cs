using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    public bool touch;
    public GameObject container;
    // Start is called before the first frame update
    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            touch = true;
            container.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            touch = false;
            container.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
