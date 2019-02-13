using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    Camera mainCamera;
    int range = 100;
    string mode = "none";
    BaseObject selectedObject;

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
            mode = "expand";
        if (Input.GetKeyDown(KeyCode.Alpha2))
            mode = "shrink";
        if (Input.GetKeyDown(KeyCode.Alpha3))
            mode = "rotate";
        if (Input.GetKeyDown(KeyCode.Alpha4))
            mode = "stretch";
        if (Input.GetKeyDown(KeyCode.Alpha5))
            mode = "compress";
        if (Input.GetKeyDown(KeyCode.Alpha5))
            mode = "move";
        if (Input.GetKeyDown(KeyCode.Alpha0))
            mode = "none";
        
        // Select something
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Current mode: " + mode);
            // Raycast Direction
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

            // Raycast for hitdetection
            RaycastHit hit;
            Ray ray = new Ray(transform.position, forward);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 1f);
            bool result = Physics.Raycast(ray, out hit, range);

            // If something was hit
            if (result)
            {
                Vector3 laserEnd = hit.point;
                //Debug.Log(hit.transform.name);
                selectedObject = hit.transform.GetComponent<BaseObject>();
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
            selectedObject.mode = "none";
            selectedObject = null;
        }

    }
}
