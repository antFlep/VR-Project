using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class WeldObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Weld(GameObject object1)
    {
        GameObject newObject = new GameObject();
        object1.transform.SetParent(newObject.transform);
        Destroy(object1.GetComponent<Throwable>());
        Destroy(object1.GetComponent<VelocityEstimator>());
        Destroy(object1.GetComponent<Interactable>());
        Destroy(object1.GetComponent<Rigidbody>());
        object1.tag = "Untagged";
        //object2.tag = "default";

        //object2.transform.SetParent(newObject.transform);
        //Destroy(object2.GetComponent<Throwable>());
        //Destroy(object2.GetComponent<VelocityEstimator>());
        //Destroy(object2.GetComponent<Interactable>());
        //Destroy(object2.GetComponent<Rigidbody>());

        newObject.AddComponent<Rigidbody>();
        newObject.tag = "weldable";
        newObject.AddComponent<Throwable>();
    }

    public void destroyObject(GameObject originObject)
    {

        
        if (originObject.transform.Find("BaseCube") != null)
        {
            GameObject obj = originObject.transform.Find("BaseCube").gameObject;
            Destroy(obj);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        GameObject obj = collision.gameObject;
        obj = obj.transform.root.gameObject;
        Debug.Log(obj.name);
        if (obj.CompareTag("weldable"))
        {
            destroyObject(obj);
            Weld(obj);
        }        
    }

}
