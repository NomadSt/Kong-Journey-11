using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadisticasSeleccion : MonoBehaviour
{
    public Text Percent;

    public GameObject StarLeft;
    public GameObject StarMid;
    public GameObject StarRight;

    public float test;

    public int sceneN;//número de escena en la build
    public float pivote;

    //2 = montaña del primer paso
    //3 = montaña del entrenamiento
    //4 = montaña de la agilidad
    //5 = montaña contrarreloj
    //6 = montaña de la humildad

    // Start is called before the first frame update
    void Start()
    {
        if (sceneN == 2)
            pivote = PlayerPrefs.GetFloat("Percent2");
        if (sceneN == 3)
            pivote = PlayerPrefs.GetFloat("Percent3");
        if (sceneN == 4)
            pivote = PlayerPrefs.GetFloat("Percent4");
        if (sceneN == 5)
            pivote = PlayerPrefs.GetFloat("Percent5");
        if (sceneN == 6)
            pivote = PlayerPrefs.GetFloat("Percent6");

        test = Mathf.Round(pivote);
        Percent.text = test.ToString() + "%";

        if (pivote > 30)
            StarLeft.SetActive(true);
        else
            StarLeft.SetActive(false);
        if (pivote > 60)
            StarRight.SetActive(true);
        else
            StarRight.SetActive(false);
        if (pivote > 82)
            StarMid.SetActive(true);
        else
            StarMid.SetActive(false);
    }
}
