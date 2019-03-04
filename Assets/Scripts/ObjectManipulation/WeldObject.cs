using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static void Weld(GameObject object1, GameObject object2)
    {
        GameObject newObject = new GameObject();

        
        if (object1.GetComponentInChildren<BaseObject>() != null)
            Destroy(object1.get)
    }
}
