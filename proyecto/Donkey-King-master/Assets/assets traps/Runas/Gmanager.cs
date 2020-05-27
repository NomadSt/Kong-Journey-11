using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gmanager : MonoBehaviour
{
    public static int pisada;//monitorea condicionales para determinar son transitables o no
    public static int Ppisada;//monitorea safe step para anular el no se puede pasar
    public int pis;
    public int pus;

    public List<GameObject> traps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActiveTrap()
    {
        //print("hail trapitos");
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("dard"))
        {
            if (traps != null & fooObj.activeInHierarchy == true & fooObj.GetComponent<dardos>() != null)
            {
                //si falla es por comprobacion de estar activo
                traps.Add(fooObj);
            }

        }
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("round"))
        {
            if (traps != null & fooObj.activeInHierarchy == true & fooObj.GetComponent<roundBlade>() != null)
                traps.Add(fooObj);
        }
        foreach (GameObject grax in traps)
        {
            
            if (grax != null & grax.GetComponent<dardos>() != null)
                grax.GetComponent<dardos>().Startar();
            if (grax != null & grax.GetComponent<roundBlade>() != null)
                grax.GetComponent<roundBlade>().StartCorrutine();
        }

    }

    // Update is called once per frame
    void Update()
    {
        pis = pisada;
        pus = Ppisada;
    }
}
