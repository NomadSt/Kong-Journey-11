using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintNum : MonoBehaviour
{
    public Text textChange;
    public GameObject IntFont;
    int transpaso;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transpaso = IntFont.GetComponent<portalCircular>().acces;
        textChange.text = transpaso.ToString();
    }
}
