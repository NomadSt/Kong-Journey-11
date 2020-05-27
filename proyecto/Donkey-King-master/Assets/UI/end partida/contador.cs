using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contador : MonoBehaviour//Script encargado de contar los items y desplegar animaciones de los contadores graficos
{
    //Tiempo
    public int minutos;
    public int segundos;

    public float timer = 1.0f;
    public bool onGame;

    //Monedas
    public int monedas;

    //Arroz
    public int rice;

    //Jade
    public int jade;

    //Movimiento
    public int dash;
    public int jump;

    //Easter Egg
    public bool p1;
    public bool p2;
    public bool p3;
    public float timerEaster = 3;
    public GameObject EggBreacke;
    public Animator EggBreackeAnim;
    public GameObject EggSpeaker;
    public GameObject f1;
    public float tE1 = 1.5f;

    //TOTAL
    public int tCoin;
    public int tRice;
    public int tJade;

    //set tcoin
    public bool setManualCoin = false;
    public int manualCoin = 7;

    // Start is called before the first frame update
    void Start()
    {
        monedas = 0;
        rice = 0;
        jade = 0;
        minutos = 0;
        segundos = 0;
        StartCoroutine(Time());

        if (setManualCoin)
            tCoin = manualCoin;
    }
    public void Times()
    {
        StartCoroutine(Time());
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(timer);
        {
            if (onGame == false)
            {
                segundos++;
                if (segundos >= 60)
                {
                    segundos = 0;
                    minutos++;
                }

                StartCoroutine(Time());
            }
        }
    }
    public void corrutinaEasterEgg(Animator anim)
    {
        StartCoroutine(rialcorrutina(anim));
    }
    IEnumerator rialcorrutina(Animator anim)
    {
        yield return new WaitForSeconds(timerEaster);
        {
            anim.SetBool("expuesto", false);
        }
    }
    public void EggBreack()
    {
        EggBreacke.SetActive(true);
        EggBreackeAnim.SetTrigger("starto");
        StartCoroutine(stopAnim());
    }
    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(tE1);
        {
            EggBreacke.SetActive(false);
            EggSpeaker.SetActive(true);
            f1.SetActive(true);
        }
    }
}
