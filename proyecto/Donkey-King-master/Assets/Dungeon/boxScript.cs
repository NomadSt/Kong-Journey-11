using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public Vector3 dir;
    public GameObject cueb;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cueb, gameObject.transform.position, gameObject.transform.rotation);
    }
}
