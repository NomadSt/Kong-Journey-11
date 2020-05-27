using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIdardo : MonoBehaviour
{
    public bool grow;
    public float minSize;
    public float maxSize;
    public float currentSize;
    public float sizeDelta;

    // Start is called before the first frame update
    void Start()
    {
        maxSize = transform.localScale.x;
    }

    public void Grow()
    {
        currentSize = 0;
        grow = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (grow)
        {
            currentSize += sizeDelta;
            transform.localScale = new Vector3(currentSize, currentSize);
        }
    }
}
