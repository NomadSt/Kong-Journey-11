using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundBlade : MonoBehaviour
{
    public Animator anime;
    public float timer0 = 1;
    public float timer1 = 1;
    public float timer2 = 1;
    public float timer3 = 1;
    public float timer4 = 1;
    public float timer5 = 1;
    public float timerS = 0.9f;
    public GameObject donut;
    // Start is called before the first frame update
    void Start()
    {
        anime.SetInteger("status", 4);
        StartCorrutine();
    }
    public void StartCorrutine()
    {
        if(gameObject.activeInHierarchy == true)
        StartCoroutine(Starta());
    }
    IEnumerator Starta()
    {
        yield return new WaitForSeconds(timer0);
        {
            anime.SetInteger("status", 1);
            StartCoroutine(second());
        }
    }
    IEnumerator second()
    {
        yield return new WaitForSeconds(timer1);
        {
            anime.SetInteger("status", 2);
            StartCoroutine(fire());
        }
    }
    IEnumerator fire()
    {
        yield return new WaitForSeconds(timer3);
        {
            anime.SetInteger("status", 3);
            StartCoroutine(stayUp());
            StartCoroutine(stop());
            donut.SetActive(true);
        }
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(timerS);
        {
            donut.SetActive(false);
        }
    }
    IEnumerator stayUp()
    {
        yield return new WaitForSeconds(timer4);
        {
            anime.SetInteger("status", 4);
            StartCoroutine(back());
        }
    }
    IEnumerator back()
    {
        yield return new WaitForSeconds(timer5);
        {
            anime.SetInteger("status", 5);
            StartCoroutine(Starta());
        }
    }
}
