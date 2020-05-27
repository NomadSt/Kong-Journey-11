using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condPar : MonoBehaviour
{
    public bool touch;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            touch = false;
            Gmanager.Ppisada = 0;
            //condPar.touchaStatic = touch;
            //condPar Parent = GetComponentInParent<condPar>();
            //Parent.toucha = touch;
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            touch = true;
            Gmanager.Ppisada = 1;
            //condPar Parent = GetComponentInParent<condPar>();
            //Parent.toucha = touch;
        }
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
