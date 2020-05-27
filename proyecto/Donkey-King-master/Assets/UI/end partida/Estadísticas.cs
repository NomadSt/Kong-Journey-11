using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Estadísticas : MonoBehaviour, IPointerEnterHandler
{
    public Image image;
    public Image iHome;
    public Image iNext;

    public float alpha = 0;
    //Encargado de contar todos los eventos
    public GameObject contadora;
    //función aparecer
    public bool isAppearing;
    public float AppearTasa;
    //función contar tiempo
    public float timerTimer;
    public float timerTimerSpeed;
    public int TimePivoteSeg;
    public int TimePivoteMin;

    public GameObject TiempoSegg;
    public GameObject TiempoMinn;
    public GameObject twoPoints ;

    public int tasaDeAumento = 2;

    public GameObject TimeGold;
    public GameObject TimeSilver;
    public GameObject TimeBronce;

    public int TimeCountGold;
    public int TimeCountSilver;
    public int TimeCountBronce;

    public int JumpCountGold;
    public int JumpCountSilver;
    public int JumpCountBronce;

    public int DashCountGold;
    public int DashCountSilver;
    public int DashCountBronce;

    //función monedas
    public float timercoin;
    public int coinContPivote;
    public GameObject coinCont;
    public float timercoinContSpeed;

    //función Arroz
    public float timerRice;
    public int riceContPivote;
    public GameObject riceCont;
    public float timerRiceContSpeed;

    //función Jade
    public float timerJade;
    public int jadeContPivote;
    public GameObject jadeCont;
    public float timerJadeContSpeed;

    //función Saltos
    public float timerSalto;
    public int SaltoContPivote;
    public GameObject SaltoCont;
    public GameObject SaltoContX;
    public GameObject JumpGold;
    public GameObject JumpSilver;
    public GameObject JumpBronce;
    public float timerSaltoContSpeed;



    //función Dash
    public float timerDash;
    public int DashContPivote;
    public GameObject DashCont;
    public GameObject DashContX;
    public GameObject DashGold;
    public GameObject DashSilver;
    public GameObject DashBronce;
    public float timerDashContSpeed;



    //Desafíos
    public bool inmortal = true;
    public bool trapecista = true;

    public GameObject inmortale;
    public GameObject trapeciste;

    //Porcentaje
    public GameObject percent;
    public GameObject completado;

    public float percentPivote;
    public float totalPercent = 100;

    public float timerpercent;

    public float relevancia = 0.15f;

    //Estrellas
    public GameObject LeftStar;
    public GameObject RightStar;
    public GameObject MidStar;

    //mouse over object
    public string mouseOver;
    public GameObject descript;
    public GameObject[] touchables;

    //Overwrite data
    public int nScene;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        descript.SetActive(false);


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (isAppearing)
            {
                //Debug.Log("Mouse Over: " + eventData.pointerCurrentRaycast.gameObject.name);
                mouseOver = eventData.pointerCurrentRaycast.gameObject.name;
                //descript.SetActive(true);
            }
        }
        //if (eventData.pointerCurrentRaycast.gameObject == null)
            //descript.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isAppearing & alpha <= 1)
        {
            alpha += AppearTasa;
        }

        var tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;

        var tempColor1 = iHome.color;
        tempColor1.a = alpha;
        iHome.color = tempColor1;

        var tempColor2 = iNext.color;
        tempColor2.a = alpha;
        iNext.color = tempColor2;
    }

    public void Appear()
    {
        FindObjectOfType<Menu>().GetComponent<Menu>().UIactivo = true;
        FindObjectOfType<Menu>().GetComponent<Menu>().Stadistics = true;
 
        isAppearing = true;
        StartCoroutine(timerCount());//Un momento después de aparecer antes de comenzar a contar
        descript.SetActive(true);
        foreach (GameObject i in touchables)
        {
            i.SetActive(true);
        }

    }

    IEnumerator timerCount()
    {
        yield return new WaitForSeconds(timerTimer);
        {
            //Tiempo.text = alpha.ToString();
            StartCoroutine(timerCountSpeed());//Inicia contador rápido de reloj
        }
    }
    IEnumerator timerCountSpeed()
    {
        yield return new WaitForSeconds(timerTimerSpeed);
        {
            //Activar los numeros visibles que cuentan el tiempo
            TiempoSegg.SetActive(true);
            TiempoMinn.SetActive(true);
            twoPoints.SetActive(true);
            //Aumenta un segundo contado por frame
            TimePivoteSeg+= tasaDeAumento;


            if (TimePivoteSeg >= 10)//Pivote visible se iguala al pivote numérico
                TiempoSegg.GetComponent<Text>().text = TimePivoteSeg.ToString();
            else
                TiempoSegg.GetComponent<Text>().text = "0" + TimePivoteSeg.ToString();//Antepone un 0 al ser un número menor a 10
            //TiempoSeg.text = TimePivoteSeg.ToString();


            if (TimePivoteSeg >= 60)//Al completarse el minuto restetea segundos y añade 1 al minutero pivote
            {
                TimePivoteSeg = 0;
                TimePivoteMin++;
            }
            TiempoMinn.GetComponent<Text>().text = TimePivoteMin.ToString();//pivote visible se iguala al digital
            if(TimePivoteMin >= contadora.GetComponent<contador>().minutos & TimePivoteSeg >= contadora.GetComponent<contador>().segundos)
            {
                TiempoMinn.GetComponent<Text>().text = TimePivoteMin.ToString();

                if (contadora.GetComponent<contador>().segundos >= 10)//Pivote visible se iguala al pivote numérico
                    TiempoSegg.GetComponent<Text>().text = contadora.GetComponent<contador>().segundos.ToString();
                else
                    TiempoSegg.GetComponent<Text>().text = "0" + contadora.GetComponent<contador>().segundos.ToString();//Antepone un 0 al ser un número menor a 10

                StartCoroutine(AppearTimeMedal());

            }
            else
            {
                StartCoroutine(timerCountSpeed());
            }
        }
    }

    IEnumerator AppearTimeMedal()
    {
        yield return new WaitForSeconds(timerTimer);
        {

            if (contadora.GetComponent<contador>().minutos <= TimeCountGold)
            {
                TimeGold.SetActive(true);
                TimeGold.GetComponent<MedalEffect>().StartScale();
            }
            if (contadora.GetComponent<contador>().minutos > TimeCountGold & contadora.GetComponent<contador>().minutos <= TimeCountSilver)
            {
                TimeSilver.SetActive(true);
                TimeSilver.GetComponent<MedalEffect>().StartScale();
            }
            if (contadora.GetComponent<contador>().minutos > TimeCountSilver & contadora.GetComponent<contador>().minutos <= TimeCountBronce)
            {
                TimeBronce.SetActive(true);
                TimeBronce.GetComponent<MedalEffect>().StartScale();
            }
            StartCoroutine(coinCount());
        }
    }

    IEnumerator coinCount()
    {
        yield return new WaitForSeconds(timercoin);
        {
            //Tiempo.text = alpha.ToString();
            StartCoroutine(coinCountSpeed());//Inicia contador rápido de reloj
            coinCont.SetActive(true);
        }
    }
    IEnumerator coinCountSpeed()
    {
        yield return new WaitForSeconds(timercoinContSpeed);
        {

            coinCont.GetComponent<Text>().text = coinContPivote.ToString();
            coinContPivote++;
            if (coinContPivote > contadora.GetComponent<contador>().monedas)
            {
                StartCoroutine(RiceCount());
            }
            else
                StartCoroutine(coinCountSpeed());
        }
    }

    IEnumerator RiceCount()
    {
        yield return new WaitForSeconds(timerRice);
        {
            StartCoroutine(RiceCountSpeed());//Inicia contador rápido de reloj
            riceCont.SetActive(true);
        }
    }
    IEnumerator RiceCountSpeed()
    {
        yield return new WaitForSeconds(timerRiceContSpeed);
        {

            riceCont.GetComponent<Text>().text = riceContPivote.ToString();
            riceContPivote++;
            if (riceContPivote > contadora.GetComponent<contador>().rice)
            {
                StartCoroutine(JadeCount());
            }
            else
                StartCoroutine(RiceCountSpeed());
        }
    }

    IEnumerator JadeCount()
    {
        yield return new WaitForSeconds(timerJade);
        {
            StartCoroutine(JadeCountSpeed());//Inicia contador rápido de reloj
            jadeCont.SetActive(true);
        }
    }
    IEnumerator JadeCountSpeed()
    {
        yield return new WaitForSeconds(timerJadeContSpeed);
        {

            jadeCont.GetComponent<Text>().text = jadeContPivote.ToString();
            jadeContPivote++;
            if (jadeContPivote > contadora.GetComponent<contador>().jade)
            {
                StartCoroutine(SaltoCount());
            }
            else
                StartCoroutine(JadeCountSpeed());
        }
    }

    IEnumerator SaltoCount()
    {
        yield return new WaitForSeconds(timerSalto);
        {
            StartCoroutine(SaltoCountSpeed());//Inicia contador rápido de reloj
            SaltoCont.SetActive(true);
            SaltoContX.SetActive(true);
        }
    }
    IEnumerator SaltoCountSpeed()
    {
        yield return new WaitForSeconds(timerSaltoContSpeed);
        {

            SaltoCont.GetComponent<Text>().text = SaltoContPivote.ToString();
            SaltoContPivote++;
            if (SaltoContPivote > contadora.GetComponent<contador>().jump)
            {
                StartCoroutine(AppearJumpMedal());
            }
            else
                StartCoroutine(SaltoCountSpeed());
        }
    }
    IEnumerator AppearJumpMedal()
    {
        yield return new WaitForSeconds(timerSalto);
        {

            if (contadora.GetComponent<contador>().jump >= JumpCountGold)
            {
                JumpGold.SetActive(true);
                JumpGold.GetComponent<MedalEffect>().StartScale();
            }
            if (contadora.GetComponent<contador>().jump < JumpCountGold & contadora.GetComponent<contador>().jump >= JumpCountSilver)
            {
                JumpSilver.SetActive(true);
                JumpSilver.GetComponent<MedalEffect>().StartScale();
            }
            if (contadora.GetComponent<contador>().jump < JumpCountSilver & contadora.GetComponent<contador>().jump >= JumpCountBronce)
            {
                JumpBronce.SetActive(true);
                JumpBronce.GetComponent<MedalEffect>().StartScale();
            }

            StartCoroutine(DashCount());

        }
    }
    IEnumerator DashCount()
    {
        yield return new WaitForSeconds(timerTimer);
        {
            StartCoroutine(DashCountSpeed());//Inicia contador rápido de reloj
            DashCont.SetActive(true);
            DashContX.SetActive(true);
        }
    }
    IEnumerator DashCountSpeed()
    {
        yield return new WaitForSeconds(timerDashContSpeed);
        {

            DashCont.GetComponent<Text>().text = DashContPivote.ToString();
            DashContPivote++;
            if (DashContPivote > contadora.GetComponent<contador>().dash)
            {
                StartCoroutine(AppearDashMedal());
            }
            else
                StartCoroutine(DashCountSpeed());
        }
    }
    IEnumerator AppearDashMedal()
    {
        yield return new WaitForSeconds(timerDash);
        {

            if (contadora.GetComponent<contador>().dash >= DashCountGold)
            {
                DashGold.SetActive(true);
                DashGold.GetComponent<MedalEffect>().StartScale();
            }
            if (contadora.GetComponent<contador>().dash < DashCountGold & contadora.GetComponent<contador>().dash >= DashCountSilver)
            {
                DashSilver.SetActive(true);
                DashSilver.GetComponent<MedalEffect>().StartScale();
            }
            if (contadora.GetComponent<contador>().dash < DashCountSilver & contadora.GetComponent<contador>().dash >= DashCountBronce)
            {
                DashBronce.SetActive(true);
                DashBronce.GetComponent<MedalEffect>().StartScale();
            }

            StartCoroutine(InmortalChallenge());
        }
    }
    IEnumerator InmortalChallenge()
    {
        yield return new WaitForSeconds(timerTimer);
        {
            StartCoroutine(trapecistaChallenge());//Inicia contador rápido de reloj
            if (inmortal)
            {
                inmortale.SetActive(true);
                inmortale.GetComponent<MedalEffect>().StartScale();
            }
        }
    }
    IEnumerator trapecistaChallenge()
    {
        yield return new WaitForSeconds(timerTimer);
        {
            StartCoroutine(percentCount());//Inicia contador rápido de completado %
            if (trapecista)
            {
                trapeciste.SetActive(true);
                trapeciste.GetComponent<MedalEffect>().StartScale();
            }
        }
    }
    IEnumerator percentCount()
    {
        yield return new WaitForSeconds(timerpercent);
        {
            //Tiempo.text = alpha.ToString();
            StartCoroutine(percentCountSpeed());//Inicia contador rápido de reloj
            percent.SetActive(true);
            completado.SetActive(true);

            //Calculos de %

            //TIEMPO
            if (contadora.GetComponent<contador>().minutos <= TimeCountGold)
                totalPercent += 25;
            if (contadora.GetComponent<contador>().minutos > TimeCountGold & contadora.GetComponent<contador>().minutos <= TimeCountSilver)
                totalPercent += 17;
            if (contadora.GetComponent<contador>().minutos > TimeCountSilver & contadora.GetComponent<contador>().minutos <= TimeCountBronce)
                totalPercent += 8;
            print(totalPercent);
            //MONEDAS
            totalPercent += relevancia * contadora.GetComponent<contador>().monedas / contadora.GetComponent<contador>().tCoin;
            print(totalPercent);
            //RICE
            totalPercent += relevancia * contadora.GetComponent<contador>().rice / contadora.GetComponent<contador>().tRice;
            print(totalPercent);
            //Jade
            totalPercent += relevancia * contadora.GetComponent<contador>().jade / contadora.GetComponent<contador>().tJade;
            print(totalPercent);

            //Jump
            if (contadora.GetComponent<contador>().jump >= JumpCountGold)
                totalPercent += 9;
            if (contadora.GetComponent<contador>().jump < JumpCountGold & contadora.GetComponent<contador>().jump >= JumpCountSilver)
                totalPercent += 6;
            if (contadora.GetComponent<contador>().jump < JumpCountSilver & contadora.GetComponent<contador>().jump >= JumpCountBronce)
                totalPercent += 3;
            print(totalPercent);
            //Dash
            if (contadora.GetComponent<contador>().dash >= DashCountGold)
                totalPercent += 9;
            if (contadora.GetComponent<contador>().dash < DashCountGold & contadora.GetComponent<contador>().dash >= DashCountSilver)
                totalPercent += 6;
            if (contadora.GetComponent<contador>().dash < DashCountSilver & contadora.GetComponent<contador>().dash >= DashCountBronce)
                totalPercent += 3;
            print(totalPercent);
            //DESAFIOS
            if(inmortal)
                totalPercent += 6;
            if (trapecista)
                totalPercent += 6;
        }
    }
    IEnumerator percentCountSpeed()
    {
        yield return new WaitForSeconds(timercoinContSpeed);
        {

            percent.GetComponent<Text>().text = percentPivote.ToString();
            percentPivote++;
            if (percentPivote > totalPercent)
            {
                StartCoroutine(LeftStaar());
                //OVERWRITE DATA
                nScene = SceneManager.GetActiveScene().buildIndex;

                if (nScene == 2 & totalPercent > PlayerPrefs.GetInt("Percent2"))
                    PlayerPrefs.SetFloat("Percent2", totalPercent);//Aqui player prefs
                if (nScene == 3 & totalPercent > PlayerPrefs.GetInt("Percent3"))
                    PlayerPrefs.SetFloat("Percent3", totalPercent);//Aqui player prefs
                if (nScene == 4 & totalPercent > PlayerPrefs.GetInt("Percent4"))
                    PlayerPrefs.SetFloat("Percent4", totalPercent);//Aqui player prefs
                if (nScene == 5 & totalPercent > PlayerPrefs.GetInt("Percent5"))
                    PlayerPrefs.SetFloat("Percent5", totalPercent);//Aqui player prefs
                if (nScene == 6 & totalPercent > PlayerPrefs.GetInt("Percent6"))
                    PlayerPrefs.SetFloat("Percent6", totalPercent);//Aqui player prefs
            }
            else
                StartCoroutine(percentCountSpeed());
        }
    }
    IEnumerator LeftStaar()
    {
        yield return new WaitForSeconds(timerTimer);
        {
            if(totalPercent >= 30)
            {
                LeftStar.SetActive(true);
                LeftStar.GetComponent<MedalEffect>().StartScale();
                StartCoroutine(RightStaar());
            }
        }
    }
    IEnumerator RightStaar()
    {
        yield return new WaitForSeconds(timerTimer);
        {
            if (totalPercent >= 60)
            {
                RightStar.SetActive(true);
                RightStar.GetComponent<MedalEffect>().StartScale();
                StartCoroutine(MidStaar());
            }
        }
    }
    IEnumerator MidStaar()
    {
        yield return new WaitForSeconds(timerTimer);
        {
            if (totalPercent >= 82)
            {
                MidStar.SetActive(true);
                MidStar.GetComponent<MedalEffect>().StartScale();
            }
        }
    }
}
