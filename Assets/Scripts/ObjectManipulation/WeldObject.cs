using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
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

    public static void Weld(GameObject object1, GameObject object2, Hand rightHand, Hand leftHand)
    {
        //GameObject newObject = new GameObject();
        //Instantiate(null);

        rightHand.DetachObject(rightHand.currentAttachedObject);
        leftHand.DetachObject(leftHand.currentAttachedObject);

        Destroy(object1.GetComponent<Throwable>());
        Destroy(object1.GetComponent<VelocityEstimator>());
        Destroy(object1.GetComponent<Interactable>());
        Destroy(object1.GetComponent<Rigidbody>());
        Destroy(object1.GetComponent<WeldWrapper>());
        object1.tag = "Untagged";
       

       
        Destroy(object2.GetComponent<Throwable>());
        Destroy(object2.GetComponent<VelocityEstimator>());
        Destroy(object2.GetComponent<Interactable>());
        Destroy(object2.GetComponent<Rigidbody>());
        Destroy(object2.GetComponent<WeldWrapper>());
        object2.tag = "Untagged";

        //newObject.tag = "weldable";
        //newObject.AddComponent<WeldWrapper>();
        //newObject.AddComponent<Rigidbody>();
        //newObject.AddComponent<Interactable>();
        //newObject.AddComponent<VelocityEstimator>();
        //newObject.AddComponent<Throwable>();

        GameObject newObject = Instantiate((GameObject)Resources.Load("EmptyWeld", typeof(GameObject)));

        //GameObject newObject = Instantiate(weldTemplate); ;

        object1.transform.SetParent(newObject.transform);
        object2.transform.SetParent(newObject.transform);

        destroyObject(object1);
        destroyObject(object2);
        //rightHand.AttachObject(newObject, GrabTypes.Trigger);

        //UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(newObject, UnityEngine.SceneManagement.SceneManager.GetActiveScene());
    }

    public static void destroyObject(GameObject originObject)
    {
        if (originObject.transform.Find("BaseCube") != null)
        {
            GameObject obj = originObject.transform.Find("BaseCube").gameObject;
            Destroy(obj);
        }
    }

    //private void OnTriggerEnter(Collider collision)
    //{
        
    //    GameObject obj = collision.gameObject;
    //    obj = obj.transform.root.gameObject;
    //    Debug.Log(obj.name);
    //    if (obj.CompareTag("weldable"))
    //    {
    //        destroyObject(obj);
    //        Weld(obj);
    //    }        
    //}

}
