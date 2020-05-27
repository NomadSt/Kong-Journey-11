using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public int horas;
    public int minutos;
    public int segundos;

    public Text texthora;
    public Text textmin;
    public Text textseg;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Time());
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(timer);
        {
            segundos++;
            if (segundos >= 60)
            {
                segundos = 0;
                minutos++;
            }
            if (minutos >= 60)
            {
                minutos = 0;
                horas++;
            }

            StartCoroutine(Time());

        }
    }


    // Update is called once per frame
    void Update()
    {
        //PlayerPref
        PlayerPrefs.SetInt("hr", horas);
        PlayerPrefs.SetInt("min", minutos);
        PlayerPrefs.SetInt("seg", segundos);

        texthora.text = horas.ToString();
        textmin.text = minutos.ToString();
        textseg.text = segundos.ToString();
    }
}
