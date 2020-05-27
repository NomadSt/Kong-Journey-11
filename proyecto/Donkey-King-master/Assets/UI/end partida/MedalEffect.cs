using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalEffect : MonoBehaviour
{
    public bool StartEscale;

    //Escala
    public float MaxScale = 2.0f;
    public float MinScale = 1.0f;
    public float currentScale;
    public float deltaScale = 0.01f;

    //Transparencia
    public Image image;
    public float currentAlpha = 0;
    public float deltaAlpha = 0.01f;
    public float minAlpha = 0.20f;

    private void Start()
    {
        //gameObject.SetActive(false);
        image = GetComponent<Image>();
        transform.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
        currentScale = MaxScale;
        currentAlpha = minAlpha;

        var tempColor = image.color;
        tempColor.a = minAlpha;//Set alpha mínimo
        image.color = tempColor;
    }
    // Start is called before the first frame update
    public void StartScale()
    {

        StartEscale = true;


    }

    // Update is called once per frame
    void Update()
    {
        if(StartEscale == true)
        {
            //Transparencia
            var tempColor = image.color;
            tempColor.a = currentAlpha;
            image.color = tempColor;

            if (currentAlpha <= 1)
            {
                currentAlpha += deltaAlpha;
            }

            //Escala
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);

            if (currentScale >= MinScale)
            {
                currentScale -= deltaScale;
            }
        }
    }
}
