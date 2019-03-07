using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CreateObject : MonoBehaviour
{
    public GameObject spawnObject;
    bool alreadyHasObject = false;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!alreadyHasObject && (collider.gameObject.name == "LeftHandCollider" || collider.gameObject.name == "RightHandCollider"))
        {
            alreadyHasObject = true;
            Instantiate(spawnObject, transform.position, new Quaternion(0, 0, 0, 0));
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.childCount > 0)
        {
            Debug.Log("Triggered Exit");
            if (other.transform.GetChild(0).gameObject.name == "BaseCube") ;
        }
        alreadyHasObject = false;
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.transform.childCount > 0)
    //    { 
    //        if (other.transform.GetChild(0).gameObject.name == "BaseCube")
    //        alreadyHasObject = true;
    //    }
    //    else
    //    alreadyHasObject = false;
    //}


}
