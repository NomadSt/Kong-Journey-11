using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    public bool IsCanvas;
    public bool esgegd;

    public Text intentos;

    public Text arroz;

    public Text goblins;

    //Reloj
    public Text texthora;
    public Text textmin;
    public Text textseg;

    public Text coins;

    public Text jump;

    // Start is called before the first frame update
    void Start()
    {
        //if(IsCanvas == false)
        {
            PlayerPrefs.SetInt("int", 0);
            PlayerPrefs.SetInt("arrz", 0);
            PlayerPrefs.SetInt("gb", 0);
            PlayerPrefs.SetInt("hr", 0);
            PlayerPrefs.SetInt("min", 0);
            PlayerPrefs.SetInt("seg", 0);
            PlayerPrefs.SetInt("cn", 0);
            PlayerPrefs.SetInt("jp", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //inten = PlayerPrefs.GetInt("int");

        //if (IsCanvas)
        {
            //intentos.text = inten.ToString();
            arroz.text = PlayerPrefs.GetInt("arrz").ToString();
            goblins.text = PlayerPrefs.GetInt("gb").ToString();

            texthora.text = PlayerPrefs.GetInt("hr").ToString();
            textmin.text = PlayerPrefs.GetInt("min").ToString();
            textseg.text = PlayerPrefs.GetInt("seg").ToString();

            coins.text = PlayerPrefs.GetInt("cn").ToString();
            jump.text = PlayerPrefs.GetInt("jp").ToString();
        }
    }
}
