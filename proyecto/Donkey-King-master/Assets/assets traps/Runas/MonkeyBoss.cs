using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBoss : MonoBehaviour
{
    public GameObject[] monos;
    public int currentMonky;
    public int Legacy;
    public Component[] MonkySons;

    public int key;
    public GameObject Portal;
    public int required;


    // Start is called before the first frame update
    public void Start()
    {
        required = Portal.GetComponent<portalCircular>().acces;
        MonkySons = GetComponentsInChildren<RunaMono>();

        foreach (RunaMono mono in MonkySons)
            mono.UnActivate();
        Dice();
    }
    public void Dice()
    {
        MonkySons = GetComponentsInChildren<RunaMono>();

        foreach (RunaMono mono in MonkySons)
            mono.UnActivate();

        currentMonky = Random.Range(0, monos.Length);
        if (currentMonky != Legacy)
        {
            monos[currentMonky].GetComponent<RunaMono>().Activate();
            Legacy = currentMonky;
        }
        else
            Dice();
    }

    // Update is called once per frame
    public void Ky()
    {
        key++;
        Animation1.jumpKey++;
        if (key >= required)
        {
            Animation1.jumpKey -= required ;
            MonkySons = GetComponentsInChildren<RunaMono>();

            foreach (RunaMono mono in MonkySons)
                mono.UnActivate();

            Portal.GetComponent<portalCircular>().OpenRemote();

        }

    }
}
