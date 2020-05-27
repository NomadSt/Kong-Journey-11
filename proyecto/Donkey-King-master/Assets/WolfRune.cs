using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfRune : MonoBehaviour
{
    public GameObject pej;

    public float fuerza = 1.0f;
    public Rigidbody rb;
    public Vector3 ForceVector;
    public Vector3 normalVector;
    public GameObject VectorAux;
    public float unlockTimer = 0.25f;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Animation1.inmortals == false)
            {
                pej = GameObject.FindGameObjectWithTag("Wukong");
                if (pej != null)
                {
                    pej.GetComponent<Animation1>().DmgReciv();
                    pej.GetComponent<Animation1>().Invoke("UnlockControls", unlockTimer);
                    pej.GetComponent<Player>().IsExternalForce = true;
                    rb = pej.GetComponent<Rigidbody>();
                    ForceVector = -(new Vector3(VectorAux.transform.position.x, pej.transform.position.y, VectorAux.transform.position.z)) + pej.transform.position;//Determina vector al que aplicar fuerza
                    normalVector = ForceVector.normalized;
                    rb.AddForce((normalVector) * fuerza);
                }

            }

        }
    }
}
