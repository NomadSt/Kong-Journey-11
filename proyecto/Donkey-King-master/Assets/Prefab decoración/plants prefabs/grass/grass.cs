using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour
{
    public float timer1;
    public float timer2 = 0.1f;
    public float rang;
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        timer1 = Random.Range(1,rang);
        StartCoroutine(Starta());
    }
    IEnumerator Starta()
    {
        yield return new WaitForSeconds(timer1);
        {
            anime.SetBool("Start", true);
        }
    }
    IEnumerator falseTouch()
    {
        yield return new WaitForSeconds(timer2);
        {
            anime.SetBool("touch", false);
            //print("efe");
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            anime.SetBool("touch", true);
            StartCoroutine(falseTouch());
            anime.SetBool("Start", true);
        }
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            anime.SetBool("touch", true);
            StartCoroutine(falseTouch());
        }
    }
}
