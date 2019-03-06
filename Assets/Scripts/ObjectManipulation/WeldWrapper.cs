using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldWrapper : MonoBehaviour
{
    public ModeSwitcher modeSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        modeSwitcher = GameObject.Find("MasterObject").GetComponent<ModeSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "RightHandCollider")
        {
            Debug.Log("Obj1");
            modeSwitcher.weldObject1 = transform.gameObject;
        }

        if (collider.gameObject.name == "LeftHandCollider")
        {
            Debug.Log("Obj2");
            modeSwitcher.weldObject2 = transform.gameObject;
        }
    }
}
