using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCountUI : MonoBehaviour
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
        transpaso = Animation1.jumpKey;
        textChange.text = transpaso.ToString();

        if (Animation1.jumpKey > 0)
            anime.SetBool("show", true);
        else
            anime.SetBool("show", false);
    }
}
