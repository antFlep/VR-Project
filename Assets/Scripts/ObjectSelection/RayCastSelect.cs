using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSelect : MonoBehaviour
{
    Camera mainCamera;
    int range = 100;
    string mode = "none";

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

        // Select something
        if (Input.GetMouseButtonDown(0))
        {
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
                Debug.Log(hit.transform.name);
                CubeManipulation cube = hit.transform.GetComponent<CubeManipulation>();
                if (cube)
                {
                    cube.isActive = true;
                    cube.mode = mode;
                }
            }
        }

        // Disable object and selection mode
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Disable object selection");
        }
    }
}
