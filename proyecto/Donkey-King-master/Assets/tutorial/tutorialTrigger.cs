using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTrigger : MonoBehaviour
{
    public GameObject cat;
    public GameObject cam;
    public BoxCollider boxTrigger;
    public bool inevitable;
    public GameObject pej;
    public MeshCollider oli;

    public bool Easter;
    // Start is called before the first frame update
    void Start()
    {
        pej = GameObject.FindGameObjectWithTag("Wukong");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(((pej.GetComponent<Player>().canJump == true | inevitable == true)) & Easter == false)
            {
                pej.GetComponent<Player>().notMove = true;
                pej.GetComponent<Player>().CanaMove();
                cat.SetActive(true);
                FindObjectOfType<BaseCam>().GetComponent<BaseCam>().esInteres = true;
                FindObjectOfType<BaseCam>().GetComponent<BaseCam>().interes = cat;
                cat.GetComponent<fortuneCat>().TriggerDialogue();
                if (boxTrigger != null)
                    boxTrigger.enabled = false;
                if (oli != null)
                    oli.enabled = false;
            }
        }

        if (other.tag == "Player")
        {
            if ((pej.GetComponent<Player>().canJump == true | inevitable == true) & Easter)
            {
                //pej.GetComponent<Player>().notMove = true;
                //pej.GetComponent<Player>().CanaMove();
                cat.SetActive(true);
                //FindObjectOfType<camera>().GetComponent<camera>().esInteres = true;
                //FindObjectOfType<camera>().GetComponent<camera>().interes = cat;
                cat.GetComponent<fortuneCat>().TriggerDialogueEgg();
                if (boxTrigger != null)
                    boxTrigger.enabled = false;
                if (oli != null)
                    oli.enabled = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
