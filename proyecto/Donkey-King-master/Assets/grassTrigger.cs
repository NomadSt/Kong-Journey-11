using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassTrigger : MonoBehaviour
{
    public List<GameObject> grasses;

    public void activeGrass()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("deco"))
        {
            if (grasses != null & fooObj.GetComponent<grass>() != null)
                grasses.Add(fooObj);
        }
        foreach (GameObject grax in grasses)
        {
            if (grax != null)
                grax.GetComponent<grass>().anime.SetTrigger("Start");
        }
    }
}
