using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDardoAlfa : MonoBehaviour
{
    public bool grow;
    public float minSize;
    public float maxSize;
    public float currentSize;
    public float sizeDelta;
    public float sizePercent = 0.99f;
    public GameObject par;


    // Start is called before the first frame update
    void Start()
    {
        maxSize = transform.localScale.x;
        transform.localScale = new Vector3(0f,0f);
    }

    public void Grow()
    {
        currentSize = 0;
        grow = true;
    }
    public void SmallNow()
    {
        if (par.GetComponent<dardos>().AlwaysFire == false)
            transform.localScale = new Vector3(0, 0);
    }
    // Update is called once per frame
    void Update()
    {


        if (grow )
        {
            if (par.GetComponent<dardos>().AlwaysFire == false)
            {
                if (transform.localScale.x < maxSize)
                {
                    currentSize += sizeDelta;
                    transform.localScale = new Vector3(currentSize, currentSize);
                }
                else
                {
                    transform.localScale = new Vector3(maxSize, maxSize);
                    grow = false;
                }
            }
        }

        if (par.GetComponent<dardos>().AlwaysFire == true)
        {
            transform.localScale = new Vector3(maxSize, maxSize);
        }

    }
}
