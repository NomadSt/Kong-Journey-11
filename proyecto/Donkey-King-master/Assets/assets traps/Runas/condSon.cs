using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condSon : MonoBehaviour
{
    public bool touch;
    public bool inhibitor;
    public bool atck;
    public GameObject pej;
    public GameObject Pisable;
    public GameObject noPisable;

    // Start is called before the first frame update
    void Start()
    {
        Pisable.SetActive(false);
        noPisable.SetActive(false);
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            inhibitor = false;
            //touch = false; O EMPUJARA A PERSONAJE AL VOLVER A CAER EN LA MISMA RUNA
            //condPar.touchaStatic = touch;
            //condPar Parent = GetComponentInParent<condPar>();
            //Parent.toucha = touch;
        }
    }
    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "Wukong")
        {
            inhibitor = true;
            touch = true;
            Gmanager.pisada = 1;
            //condPar Parent = GetComponentInParent<condPar>();
            //Parent.toucha = touch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.wolfTouch == true & inhibitor == false)
            touch = false;


        if (Gmanager.pisada == 0)
            touch = false;

        if (Gmanager.pisada == 1)
        {
            if (touch)
            {
                Pisable.SetActive(true);
                noPisable.SetActive(false);
                atck = false;
            }
            else
            {
                Pisable.SetActive(false);
                noPisable.SetActive(true);
                atck = true;
            }


        }
        
        if (Gmanager.pisada == 0 | Gmanager.Ppisada == 1)
        {
            Pisable.SetActive(true);
            noPisable.SetActive(false);
            atck = false;
        }
    }
}
