using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderMang : MonoBehaviour
{
    public GameObject pej;
    public bool localMonitor;

    public GameObject relieve;
    public GameObject basic;

    // Start is called before the first frame update
    void Start()
    {
        pej = GameObject.FindGameObjectWithTag("Wukong");
    }

    // Update is called once per frame
    void Update()
    {
        if (pej != null)
        {
            localMonitor = pej.GetComponent<Player>().canJump;

            if (Input.GetKeyDown(KeyCode.Space))
                localMonitor = false;

            if (localMonitor == true)
            {
                relieve.SetActive(false);
                basic.SetActive(true);
            }
            if (localMonitor == false)
            {
                relieve.SetActive(true);
                basic.SetActive(false);
            }
        }
    }
}
