using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dardos : MonoBehaviour
{
    public Transform[] Exit;
    public Transform Aux;
    public Transform AuxRot;
    public Rigidbody rBull;
    public Vector3 obj;
    public float Bforce;

    public float timer0;//desfase antes de comenzar el ciclo
    public float timer1;
    public float timer2;
    public int puntero = 0;
    public float ArrayMag;

    public GameObject[] UIChild;
    public bool IsFire;
    public float timerUI;
    public int ChPiv;
    public float timerPercent;
    //public bool allBig;
    public float timerParpadear;
    public bool AlwaysFire;
    //Avoid 4 ever loop
    public bool take;

    // Start is called before the first frame update
    public void Start()
    {
        timerUI = timer2 * timerPercent / (UIChild.Length+1);
        Invoke("fire", timer0);
        ArrayMag = Exit.Length;
        Invoke("ActivateUI", timerUI);

        if (AlwaysFire)
        {
            foreach (GameObject UI in UIChild)
                UI.SetActive(true);
        }
    }

    public void Startar()
    {
        if (take == false)
        {
            take = true;
            timerUI = timer2 * timerPercent / (UIChild.Length + 1);
            Invoke("fire", timer0);
            ArrayMag = Exit.Length;
            Invoke("ActivateUI", timerUI);

            if (AlwaysFire)
            {
                foreach (GameObject UI in UIChild)
                    UI.SetActive(true);
            }
        }

    }

    public void ActivateUI()
    {

        if (IsFire == false)
        {
            if (ChPiv < UIChild.Length & AlwaysFire == false)
            {
                UIChild[ChPiv].GetComponent<UIDardoAlfa>().Grow();
                Invoke("ActivateUI", timerUI);
            }

            ChPiv += 1;

            if (ChPiv == UIChild.Length)
            {
                Invoke("Parpadear", timerUI);
            }
        }
    }
    public void Parpadear()
    {
       if( IsFire == false & AlwaysFire==false)
        {
            Invoke("Parpadear1", timerParpadear);
            foreach (GameObject UI in UIChild)
                UI.SetActive(false);

        }
    }
    public void Parpadear1()
    {
        if (IsFire == false& AlwaysFire==false)
        {
            Invoke("Parpadear", timerParpadear);
            foreach (GameObject UI in UIChild)
                UI.SetActive(true);

        }
    }
    public void fire()
    {
        if (gameObject.active)
        {

            foreach (GameObject UI in UIChild)
            UI.GetComponent<UIDardoAlfa>().SmallNow();

        IsFire = true;
        AuxRot.LookAt(Aux);
        Rigidbody rigmod;
        rigmod = Instantiate(rBull, Exit[puntero].position, AuxRot.rotation) as Rigidbody;
        obj = Aux.position - AuxRot.position;
        obj.Normalize();
        rigmod.AddForce(obj * Bforce);

        puntero += 1;

        if (puntero < ArrayMag)
        {
            Invoke("fire", timer1);
        }
        if (puntero == ArrayMag)
        {
            foreach (GameObject UI in UIChild)
                UI.SetActive(true);

            if (AlwaysFire == false)
                Invoke("fire", timer2);
            else
                Invoke("fire", 0);
            puntero = 0;
            IsFire = false;
            Invoke("ActivateUI", timerUI);
            ChPiv = 0;
            //allBig = false;
        }
        
    }
        }

}
