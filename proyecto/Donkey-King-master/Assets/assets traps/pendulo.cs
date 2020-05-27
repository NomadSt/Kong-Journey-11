using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulo : MonoBehaviour
{
    public float timer1 = 2.5f;
    public float timer2 = 0.625f;
    void Start()
    {
        StartCoroutine(Starta());
    }

    IEnumerator Starta()
    {
        yield return new WaitForSeconds(timer2);
        {
            int ran = Random.Range(1, 3);
            gameObject.GetComponent<SfxManager>().Play(ran.ToString());
            StartCoroutine(Starta1());
        }
    }

    IEnumerator Starta1()
    {
        yield return new WaitForSeconds(timer1);
        {
            int ran = Random.Range(1, 3);
            gameObject.GetComponent<SfxManager>().Play(ran.ToString());
            StartCoroutine(Starta1());
        }
    }

}
