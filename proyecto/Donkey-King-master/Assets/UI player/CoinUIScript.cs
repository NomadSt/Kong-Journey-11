using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUIScript : MonoBehaviour
{
    public Text textChange;

    int transpaso;
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transpaso = FindObjectOfType<Animation1>().key;
        textChange.text = transpaso.ToString();

        if(FindObjectOfType<Animation1>().key > 0)
            anime.SetBool("show", true);
        else
            anime.SetBool("show", false);
    }
}
