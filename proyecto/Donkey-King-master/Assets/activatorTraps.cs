using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatorTraps : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Gmanager>().ActiveTrap();
    }
}
