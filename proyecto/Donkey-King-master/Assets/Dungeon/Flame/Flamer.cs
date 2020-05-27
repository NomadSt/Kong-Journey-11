using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamer : MonoBehaviour
{
    public Animator anime;
    public int Status;
    public Component[] flparticles;
    public GameObject[] flUI;
    public float timer1;
    public float timer1a;
    public float timer2;
    public float timer3;
    public float timer4;

    public GameObject lighte;
    public GameObject Halllight;

    public GameObject Damage1;
    public GameObject Damage2;

    public GameObject UI1;

    public float MaxScale1;
    public float MaxScale2;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(Up1());
        Damage1.SetActive(false);
        Damage2.SetActive(false);

    }
    IEnumerator Up1()
    {
        yield return new WaitForSeconds(timer4);
        {
            Status = 1;
            anime.SetInteger("Atck", Status);
            StartCoroutine(Up2());

            for (int i = 0; i < flUI.Length; i++)
            {
                flUI[i].GetComponent<FlUIChild>().Grow();
            }
        }
    }
    IEnumerator Up2()
    {
        yield return new WaitForSeconds(timer1);
        {
            Status = 2;
            anime.SetInteger("Atck", Status);
            StartCoroutine(StayUp());
        }
    }
    IEnumerator StayUp()
    {
        yield return new WaitForSeconds(timer1a);
        {
            Status = 3;
            anime.SetInteger("Atck", Status);
            StartCoroutine(StayUp2());
            Damage1.SetActive(true);
            Damage2.SetActive(true);

            if (Halllight.GetComponent<RoomLight>().touch)
                lighte.SetActive(true);

            flparticles = GetComponentsInChildren<FlChild>();

            foreach (FlChild flame in flparticles)
                flame.Grow();
        }
    }
    IEnumerator StayUp2()
    {
        yield return new WaitForSeconds(timer2);
        {
            Status = 3;
            anime.SetInteger("Atck", Status);
            StartCoroutine(StayDown());

            lighte.SetActive(false);

            Damage1.SetActive(false);
            Damage2.SetActive(false);

            flparticles = GetComponentsInChildren<FlChild>();

            foreach (FlChild flame in flparticles)
                flame.Small();

            for (int i = 0; i < flUI.Length; i++)
            {
                flUI[i].GetComponent<FlUIChild>().Small();
            }
        }
    }
    IEnumerator StayDown()
    {
        yield return new WaitForSeconds(timer3);
        {
            Status = 4;
            anime.SetInteger("Atck", Status);
            StartCoroutine(Up1());




        }
    }
    // Update is called once per frame
    void Update()
    {
        //UI1.transform.localScale = new Vector3(MaxScale1, MaxScale2);
    }
}
