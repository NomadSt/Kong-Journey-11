using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlChild : MonoBehaviour
{
    public bool grow = true;
    public bool safe;
    public float currentScale;
    public float maxScale;
    public float growScale;
    public float fadeMult;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (grow & safe == false)
        {
            gameObject.GetComponent<SfxManager>().Play("1");
            safe = true;
        }

        if (grow & currentScale < maxScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, currentScale, currentScale);
            currentScale += growScale;

        }

        if (grow == false & currentScale > 0)
        {
            safe = false;
            currentScale -= growScale;
            if (currentScale < 0)
                currentScale = 0;

            transform.localScale = new Vector3(transform.localScale.x, currentScale * fadeMult, currentScale * fadeMult);
        }
    }
}
