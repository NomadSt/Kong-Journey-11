using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public GameObject pej;
    public bool localMonitor;

    public MeshCollider fullRoce;
    public MeshCollider noRoce;

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
                //noRoce.GetComponent<MeshCollider>().enabled = false;
                noRoce.enabled = false;
                fullRoce.enabled = true;
            }
            if (localMonitor == false)
            {
                noRoce.enabled = true;
                fullRoce.enabled = false;
            }
        }
    }
}
