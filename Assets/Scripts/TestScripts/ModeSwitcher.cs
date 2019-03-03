using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ModeSwitcher : MonoBehaviour
{
    public bool stretchMode = false;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Action_Boolean testAction; // 3

    public bool vrEnabled = false;

    public enum Mode
    {
        None,
        Scale,
        Stretch,
        Rotate
    }

    public Mode mode = Mode.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stretchMode = testAction.GetState(rightHand);
        if (testAction.GetState(rightHand)) mode = Mode.Stretch;
        if (stretchMode) Debug.Log("Stretch Mode On");
    }

    public bool GetTest()
    {
        return testAction.GetState(rightHand);
    }
}
