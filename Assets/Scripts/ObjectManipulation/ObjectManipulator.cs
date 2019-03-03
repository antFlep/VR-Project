using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ObjectManipulator : MonoBehaviour
{
    Camera mainCamera;
    int range = 100;
    ModeSwitcher.Mode mode = ModeSwitcher.Mode.None;
    BaseObject selectedObject;
    public ModeSwitcher modeSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set Selection Mode
        if (Input.GetKeyDown(KeyCode.Alpha1))
            modeSwitcher.mode = ModeSwitcher.Mode.Scale;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            modeSwitcher.mode = ModeSwitcher.Mode.Stretch;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            modeSwitcher.mode = ModeSwitcher.Mode.Rotate;

        //TODO: Most likely delete keyinputs below
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //    mode = "stretch";
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //    mode = "compress";
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //    mode = "move";
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //    mode = "none";

        // Select something
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Current mode: " + mode);
            // Raycast Direction
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            // Raycast for hitdetection
            RaycastHit hit;
            Ray ray = new Ray(transform.position, forward);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 1f);

            LayerMask layer = LayerMask.GetMask("BasicObject");
            bool result = Physics.Raycast(ray, out hit, range, layer);

            // If something was hit
            if (result)
            {
                Debug.Log("Hit something");
                Vector3 laserEnd = hit.point;
                //Debug.Log(hit.transform.name);
                selectedObject = hit.transform.GetComponent<BaseObject>();
                if (!selectedObject)
                {
                    // get invisible cube from sphere
                    selectedObject = hit.transform.childCount > 0 ? hit.transform.GetChild(0).GetComponent<BaseObject>() : null; 
                    //selectedObject = hit.transform.GetChild(0).GetComponent<BaseObject>();
                }

                if (selectedObject)
                {
                    selectedObject.face = selectedObject.GetHitFace(hit);
                    Debug.Log(selectedObject.GetHitFace(hit));
                    selectedObject.isActive = true;
                    selectedObject.mode = mode;
                }
            }
        }

        // Disable object and selection mode
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            Debug.Log("Disable object selection");
            selectedObject.isActive = false;
            selectedObject.mode = ModeSwitcher.Mode.None;
            selectedObject = null;
        }

    }
}
