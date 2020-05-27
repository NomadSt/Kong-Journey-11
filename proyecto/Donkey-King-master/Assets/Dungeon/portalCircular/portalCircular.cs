using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCircular : MonoBehaviour
{
    public int acces;
    public GameObject pej;
    public Animator anim;
    public bool metodoCoin;
    public GameObject golden;
    public GameObject lighta;
    public bool Open;
    public BoxCollider locki;
    public SphereCollider trigger;
    public GameObject theWall;
    private void Start()
    {
        if (Open == false)
        {
            if (metodoCoin)
            {
                golden.SetActive(true);
                lighta.SetActive(false);
            }
            if (metodoCoin == false)
            {
                golden.SetActive(false);
                lighta.SetActive(true);
            }
        }
        else
            theWall.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {

        if (FindObjectOfType<Animation1>().key >= acces)
        {
            locki.enabled = false;
            trigger.enabled = false;
            pej = GameObject.FindGameObjectWithTag("Wukong");
            anim.SetBool("Open", true);
            FindObjectOfType<Animation1>().key -= acces;
            Open = true;
            gameObject.GetComponent<SfxManager>().Play("open portal");
            theWall.SetActive(false);
        }
    }

    public void OpenRemote()
    {
        locki.enabled = false;
        trigger.enabled = false;
        anim.SetBool("Open", true);
        Open = true;
        gameObject.GetComponent<SfxManager>().Play("open portal");
        theWall.SetActive(false);
    }


}
