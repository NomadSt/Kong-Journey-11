using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class estadisticasScript : MonoBehaviour
{
    public bool IsCanvas;

    public Text intentos;

    public Text arroz;

    public Text goblins;

    //Reloj
    public Text texthora;
    public Text textmin;
    public Text textseg;

    public Text coins;

    public Text jump;

    public int ententos;
    public int rice;
    public int goblinses;
    public int hor;
    public int minut;
    public int sekunfos;
    public int monsedassas;
    public int saltos;

    // Start is called before the first frame update
    void Start()
    {
        if(IsCanvas == false)
        {
            //PlayerPrefs.DeleteAll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCanvas)
        {
            intentos.text = PlayerPrefs.GetInt("intent").ToString();
            arroz.text = PlayerPrefs.GetInt("arrzoi").ToString();
            goblins.text = PlayerPrefs.GetInt("gb").ToString();

            texthora.text = PlayerPrefs.GetInt("hr").ToString();
            textmin.text = PlayerPrefs.GetInt("min").ToString();
            textseg.text = PlayerPrefs.GetInt("seg").ToString();

            coins.text = PlayerPrefs.GetInt("cn").ToString();
            jump.text = PlayerPrefs.GetInt("jpo").ToString();
        }
        else
        {
            ententos = (PlayerPrefs.GetInt("intent"));
            rice = (PlayerPrefs.GetInt("arrzoi"));
            goblinses = (PlayerPrefs.GetInt("gb"));
            hor = (PlayerPrefs.GetInt("hr"));
            minut = (PlayerPrefs.GetInt("min"));
            sekunfos = (PlayerPrefs.GetInt("seg"));
            monsedassas = (PlayerPrefs.GetInt("cn"));
            saltos = (PlayerPrefs.GetInt("jpo"));
        }
    }
}
