using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject pej;

    public float fuerza = 1.0f;
    public Rigidbody rb;
    public Vector3 ForceVector;
    public Vector3 normalVector;
    //Add Force
    public bool ApplyForce;
    //Floor pinchos
    public bool IsFloorPinchos;
    public GameObject VectorAux;
    public bool activarHard;
    public int damage = 1;
    public Animator LoseChange;
    public float timer1 = 0.5f;
    public bool cancel;

    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.FindGameObjectWithTag("LosChange") != null)
            LoseChange = GameObject.FindGameObjectWithTag("LosChange").GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            if (Animation1.inmortals == false)
            {
                Animation1.vidas -= damage;
                pej = GameObject.FindGameObjectWithTag("Wukong");
                if (pej != null)
                {
                    FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().inmortal = false;//Quita desafío de inmortalidad
                    pej.GetComponent<Animation1>().Inmortal();

                    if (ApplyForce & Animation1.vidas >= 1)
                    {
                        pej.GetComponent<Player>().IsExternalForce = true;
                        //print("Habilitar para pc y android");
                        rb = pej.GetComponent<Rigidbody>();
                        ForceVector = -(new Vector3(VectorAux.transform.position.x, pej.transform.position.y, VectorAux.transform.position.z)) + pej.transform.position;//Determina vector al que aplicar fuerza
                    }

                    if (IsFloorPinchos)//segund si esta encima o no de los pinchos varia el calculo de este vector
                    {
                        ForceVector = -VectorAux.transform.position + pej.transform.position;
                    }

                    if (ApplyForce & Animation1.vidas >= 1)
                    {
                        normalVector = ForceVector.normalized;
                        rb.AddForce((normalVector) * fuerza);
                    }
                    if (Animation1.vidas < 1)
                    {
                        
                        FindObjectOfType<Player>().GetComponent<Player>().notMove = true;
                        LoseChange.Play("FastiHide");
                        LoseChange.SetBool("fast", true);
                        LoseChange.SetBool("show", true);
                        //print("auch");
                        pej.GetComponent<Animation1>().TpCorrutineTrigger();
                        //print("auch1");
                    }
                }
                else
                    print("null player");
                    
            }

        }
    }
    // Update is called once per frame
    
}
