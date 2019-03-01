using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ModeSwitcher : MonoBehaviour
{

    public bool stretchMode = false;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean testAction; // 3

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stretchMode = testAction.GetState(handType);
        //if (stretchMode)
        //    Debug.Log("Strecht Mode On");
    }

    public bool GetTest()
    {
        return testAction.GetState(handType);
    }
}
