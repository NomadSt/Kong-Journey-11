using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainManager : MonoBehaviour
{
    public GameObject terrenoCompleto;
    public GameObject terrenoVacio;
    public GameObject terrenoPlano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            terrenoCompleto.SetActive(true);
            terrenoVacio.SetActive(false);
            terrenoPlano.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            terrenoCompleto.SetActive(false);
            terrenoVacio.SetActive(true);
            terrenoPlano.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            terrenoCompleto.SetActive(false);
            terrenoVacio.SetActive(false);
            terrenoPlano.SetActive(true);
        }
    }
}
