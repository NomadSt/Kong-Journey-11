using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRespawn : MonoBehaviour
{
    public GameObject pej;
    public float timer1 = 0.5f;

    public Animator LoseChange;
    public static bool safe;
    public bool cancel;
    public bool touch;

    void Start()
    {
        LoseChange = GameObject.FindGameObjectWithTag("LosChange").GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        //print("oli");
        pej = GameObject.FindGameObjectWithTag("Wukong");
        if (other.tag == "Player" & safe == false)
        {
            FindObjectOfType<BaseCam>().GetComponent<BaseCam>().enabled = false;
            FindObjectOfType<Player>().GetComponent<Player>().notMove = true;
            FindObjectOfType<Player>().GetComponent<CapsuleCollider>().enabled = false;
            LoseChange.Play("FastiHide");
            LoseChange.SetBool("fast", true);
            LoseChange.SetBool("show", true);
            safe = true;

            Animation1.vidas -= 1;
            //if (Animation1.intentos >= 0)
                StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(timer1);
        {
            FindObjectOfType<Player>().GetComponent<CapsuleCollider>().enabled = true;
            FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().trapecista = false;//Quita desafío de trapecista

            //print("hi");

            safe = false;
            pej.GetComponent<Animation1>().Respauwn();

            cancel = false;

            if ((Animation1.intentos == 0 & Animation1.vidas < 1) | Animation1.intentos < 0)
                cancel = true;

            if (cancel == false)
            {
                pej.GetComponent<Player>().CanaMove();
                LoseChange.SetBool("show", false);
                LoseChange.SetBool("fast", false);
                FindObjectOfType<BaseCam>().GetComponent<BaseCam>().enabled = true;
                FindObjectOfType<Player>().GetComponent<Player>().notMove = false;
                pej.GetComponent<Player>().notMove = true;
            }

        }
    }

}

