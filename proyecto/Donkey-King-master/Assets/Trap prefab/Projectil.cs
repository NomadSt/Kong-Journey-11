using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public float timer1;
    public GameObject pej;
    public bool deathByFloor;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("death", timer1);
        gameObject.GetComponent<SfxManager>().Play("1");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TheWall")
        {
            death();
        }
        if (other.tag == "floor" & deathByFloor)
        {
            death();
        }
    }
    
    // Update is called once per frame
    void death()
    {
        Destroy(gameObject);
    }
}
