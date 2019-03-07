using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ModeSwitcher : MonoBehaviour
{
    public bool stretchMode = false;
    public bool weldMode = false;
    bool flag = true;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Action_Boolean testAction; // 3
    public SteamVR_Action_Boolean weldAction;
    public SteamVR_Action_Boolean menuAction;
    public GameObject objectToCreate;
    public GameObject objectToCreate2;
    public Mode mode = Mode.None;
    public GameObject weldObject1 = null;
    public GameObject weldObject2 = null;

    public Hand rHand = null;
    public Hand lHand = null;

    public bool vrEnabled = false;

    public enum Mode
    {
        None,
        Scale,
        Stretch,
        Compress,
        Rotate,
        Weld,
    }


    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        mode = Mode.None;

        stretchMode = testAction.GetState(rightHand);
        weldMode = weldAction.GetState(rightHand);

        if (testAction.GetState(rightHand))
        {
            mode = Mode.Stretch;
        }

        if (weldAction.GetState(rightHand))
        {
            mode = Mode.Weld;
        }

        if (menuAction.GetState(rightHand))
        {
            if (weldObject1 == null)
                return;

            //GameObject clone;
            if (flag)
            {
               //clone = PrefabUtility.SaveAsPrefabAsset(weldObject1, "Assets/Prefabs/FakePrefabs/tast.prefab");
               //GameObject.Instantiate(clone, new Vector3(0, 0.5f, 0), new Quaternion(0, 0, 0, 0), null);
               Instantiate(weldObject1, new Vector3(0, 0.5f, 0), new Quaternion(0, 0, 0, 0), null);
            }
            flag = false;
        }
        else
        {
            flag = true;
        }

        if (weldObject1 && weldObject2 && rHand && lHand && mode == Mode.Weld)
        {
            if (weldObject1 == weldObject2)
                return;



            if (weldObject1.tag == "weldable" && weldObject2.tag == "weldable")
            Debug.Log("pieourghpwerouhg");
            WeldObject.Weld(weldObject1, weldObject2, rHand, lHand);

            weldObject1 = null;
            weldObject2 = null;
            mode = Mode.None;
        }

        
    }

    public bool GetStrech()
    {
        // TODO: Rename Action (stretchAction)
        return testAction.GetState(rightHand);
    }

    public  bool GetWeld()
    {
        // TODO: Create new Action (weldAction)
        return weldAction.GetState(rightHand);
    }
}
