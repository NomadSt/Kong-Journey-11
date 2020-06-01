using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashDetector : MonoBehaviour
{
    public GameObject pej;
    public bool choque;
    public bool done;

    public int numerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "floor" | other.tag == "TheWall" | other.tag == "Gate")
            choque = false;
    }

    public void OnTriggerStay(Collider other)//Stay, ya que por cada exit se destacha el bool y no vuelve a tacharse
    {

        if (other.tag == "floor" | other.tag == "TheWall" | other.tag == "Gate")
        {
            choque = true;
            if (pej.GetComponent<Player>().IsDash)
            {
                pej.GetComponent<Player>().EndDash();
            }
        }
    }

    public void Update()
    {
        numerator -= 1;
        if (numerator < 1)
            spawn();
    }
    // Update is called once per frame
    public void spawn()
    {
        if (done == true)
        {
            done = false;
            print("done");
            pej.GetComponent<Player>().spawnDash();
        }
        


    }
}
