using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipoYCantidadTracker : MonoBehaviour
{
    public GameObject[] Sons;
    public string nombrecion;
    public string toScript;
    public Text textChange;
    public string compare;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in Sons)
        {
            i.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        compare = FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().mouseOver;
        if (nombrecion == compare)
        {
            foreach (GameObject i in Sons)
            {
                i.SetActive(true);
            }
            //comparar tipo
            if (nombrecion == "Monedas")
                textChange.text = toScript + FindObjectOfType<contador>().GetComponent<contador>().tCoin.ToString();
            if (nombrecion == "Arroz")
                textChange.text = toScript + FindObjectOfType<contador>().GetComponent<contador>().tRice.ToString();
            if (nombrecion == "Jade")
                textChange.text = toScript + FindObjectOfType<contador>().GetComponent<contador>().tJade.ToString();
            if (nombrecion == "Tiempo")
                textChange.text = toScript + FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().TimeCountGold.ToString() + ":00";
            if (nombrecion == "Saltos")
                textChange.text = toScript + FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().JumpCountGold.ToString();
            if (nombrecion == "Dash")
                textChange.text = toScript + FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().DashCountGold.ToString();
        }
        else
        {
            foreach (GameObject i in Sons)
            {
                i.SetActive(false);
            }
        }
    }
}
