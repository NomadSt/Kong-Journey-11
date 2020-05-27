using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaMono : MonoBehaviour
{
    public GameObject boss;
    public GameObject pisable;
    public GameObject noPisable;
    public bool interactable;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (interactable)
        {
            PlayerPrefs.SetInt("jpo", PlayerPrefs.GetInt("jpo") + 1);
            UnActivate();
            boss.GetComponent<MonkeyBoss>().Dice();
            boss.GetComponent<MonkeyBoss>().Ky();
            GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("mono");
        }
    }
    public void Activate()
    {
        interactable = true;
        pisable.SetActive(true);
        noPisable.SetActive(false);
    }
    public void UnActivate()
    {
        interactable = false;
        pisable.SetActive(false);
        noPisable.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
