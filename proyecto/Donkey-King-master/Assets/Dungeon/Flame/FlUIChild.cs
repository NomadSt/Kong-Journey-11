using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlUIChild : MonoBehaviour
{
    public bool grow = true;
    public float currentScale1;
    public float currentScale2;

    public float maxScale1;
    public float maxScale2;
    public float growScale;
    public float growMult;

    // Start is called before the first frame update
    void Start()
    {
        maxScale1 = transform.localScale.x;
        maxScale2 = transform.localScale.y;
    }
    public void Grow()
    {
        grow = true;
    }
    public void Small()
    {
        grow = false;

    }
    // Update is called once per frame
    void Update()
    {

        if (grow & currentScale2 < maxScale2)
        {
            currentScale1 = maxScale1;
            transform.localScale = new Vector3(maxScale1, currentScale2);
            currentScale2 += growScale;
        }

        if (grow == false & currentScale1 > 0)
        {

            currentScale1 -= growMult;
            if (currentScale1 < 0)
            {

                currentScale1 = 0;
                currentScale2 = 0;
            }
            transform.localScale = new Vector3(currentScale1, currentScale2);
        }
    }
}
