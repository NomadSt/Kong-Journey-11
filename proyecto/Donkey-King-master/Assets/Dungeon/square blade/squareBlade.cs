using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareBlade : MonoBehaviour
{
    public float speed;
    public float timer1;
    public Vector3 direc;
    public bool atc = true;
    public Animator anime;
    //Audio
    public string song1 = "1";
    public string song2 = "2";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "box")
        {
            //print("HAIL CAT LOLIS");
            if (other.gameObject.GetComponent<boxScript>().dir != direc)
            {
                atc = false;
                StartCoroutine(ReAtck());
                direc = other.gameObject.GetComponent<boxScript>().dir;
                gameObject.GetComponent<SfxManager>().Play(song1);
            }
        }
    }
    IEnumerator ReAtck()
    {
        yield return new WaitForSeconds(timer1);
        {
            gameObject.GetComponent<SfxManager>().Play(song2);
            atc = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (atc)
        {
            anime.SetBool("atck", true);// Modifica el bool
            transform.Translate(direc * Time.deltaTime * speed);
        }
        else
            anime.SetBool("atck", false);
    }
}
