using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jud : MonoBehaviour
{
    public float timerStart;
    public Animator anime;
    public bool starter;//si apenas parte se debe gatillar el trigger
    public int animationTipe;

    private void Start()
    {
        if (starter & animationTipe == 0)
            StartCoroutine(Starta());
        if (animationTipe == 1)
            anime.Play("Equilibrio");
        if (animationTipe == 2)
            anime.Play("Elongacion");

    }
    public void StartTrigger()
    {
        StartCoroutine(Starta());
    }
    IEnumerator Starta()
    {
        yield return new WaitForSeconds(timerStart);
        {
            anime.SetTrigger("starto");
        }
    }

}
