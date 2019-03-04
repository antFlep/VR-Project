using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BaseObject : MonoBehaviour
{
    
    //public ModeSwitcher.Mode mode = ModeSwitcher.Mode.None;
    public ModeSwitcher modeSwitcher;
    public MCFace face;
    public bool isActive = false;
    //bool stretchMode = false;

    GameObject parent;
    GameObject hand = null;

    float scaleFactor = 0.01f;
    


    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        modeSwitcher = GameObject.Find("MasterObject").GetComponent<ModeSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isActive)
        //{
        //    //if (mode.Equals("none"))
        //    //    Debug.Log("noting to Do");
        //    if (mode.Equals("shrink"))
        //        Shrink();
        //    if (mode.Equals("expand"))
        //        Expand();
        //    if (mode.Equals("rotate"))
        //        Rotate();
        //    if (stretchMode)
        //        Stretch();
        //}

        //Debug.Log("Position" + transform.InverseTransformVector(transform.position));
        if (hand)
        {
            //Debug.Log("Current Mode: " + modeSwitcher.mode);

            switch (modeSwitcher.mode)
            {
                case ModeSwitcher.Mode.Scale:
                    Expand();
                    break;
                case ModeSwitcher.Mode.Stretch:
                    Stretch();
                    break;
                default:
                    //Debug.Log("Current Mode: " + mode);
                    break;
            }
        }
        //if (hand)
        //{
        //    if (hand.GetComponent<ModeSwitcher>().stretchMode)
        //        Stretch();
        //}
    }

    void Shrink()
    {
        Debug.Log("Shrinking");
        // check if too small toDo.
        parent.transform.localScale = new Vector3(parent.transform.localScale.x - scaleFactor, parent.transform.localScale.y - scaleFactor, parent.transform.localScale.z - scaleFactor);
    }

    void Expand()
    {
        Debug.Log("Expanding");
        parent.transform.localScale = new Vector3(parent.transform.localScale.x + scaleFactor, parent.transform.localScale.y + scaleFactor, parent.transform.localScale.z + scaleFactor);
    }

    void Rotate()
    {
        Debug.Log("Rotating");
        float x = parent.transform.rotation.eulerAngles.x;
        float y = parent.transform.rotation.eulerAngles.y;
        float z = parent.transform.rotation.eulerAngles.z;

        if (Input.GetAxis("Mouse X") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved left");
            y += Time.deltaTime * 10;
            parent.transform.rotation = Quaternion.Euler(x, y, z);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved right");
            y -= Time.deltaTime * 10;
            parent.transform.rotation = Quaternion.Euler(x, y, z);
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved left");
            x += Time.deltaTime * 10;
            parent.transform.rotation = Quaternion.Euler(x, y, z);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved right");
            x -= Time.deltaTime * 10;
            parent.transform.rotation = Quaternion.Euler(x, y, z);
        }
    }

    public enum MCFace
    {
        None,
        Up,
        Down,
        East,
        West,
        North,
        South
    }


    public MCFace GetHitFace(RaycastHit hit)
    {
        Vector3 incomingVec = transform.InverseTransformVector(hit.normal).normalized - (new Vector3(0, 1, 0));

        float x = incomingVec.x;
        float y = incomingVec.y;
        float z = incomingVec.z;

        float xScale = parent.transform.localScale.x;
        float yScale = parent.transform.localScale.y;
        float zScale = parent.transform.localScale.z;

        Vector3 SOUTH = (new Vector3(0, -1, -1));
        Vector3 NORTH = (new Vector3(0, -1,  1));
        Vector3 UP    = (new Vector3(0,  0,  0));
        Vector3 DOWN  = (new Vector3(0, -2,  0));
        Vector3 WEST  = (new Vector3(-1,-1,  0));
        Vector3 EAST  = (new Vector3( 1,-1,  0));

        Debug.Log("Incoming Vec: "   + incomingVec +
            "\nS: " + SOUTH + " N: " + NORTH +
            "\nW: " + WEST  + " E: " + EAST +
            "\nU: " + UP    + " D: " + DOWN);

        if (incomingVec == SOUTH)
            return MCFace.South;

        if (incomingVec == NORTH)
            return MCFace.North;

        if (incomingVec == UP)
            return MCFace.Up;

        if (incomingVec == DOWN)
            return MCFace.Down;

        if (incomingVec == WEST)
            return MCFace.West;

        if (incomingVec == EAST)
            return MCFace.East;

        return MCFace.None;
    }

    //public MCFace GetHitFace(RaycastHit hit)
    //{
    //    Vector3 incomingVec = hit.normal - Vector3.up;

    //    if (incomingVec == new Vector3(0, -1, -1))
    //        return MCFace.South;

    //    if (incomingVec == new Vector3(0, -1, 1))
    //        return MCFace.North;

    //    if (incomingVec == new Vector3(0, 0, 0))
    //        return MCFace.Up;

    //    if (incomingVec == new Vector3(1, 1, 1))
    //        return MCFace.Down;

    //    if (incomingVec == new Vector3(-1, -1, 0))
    //        return MCFace.West;

    //    if (incomingVec == new Vector3(1, -1, 0))
    //        return MCFace.East;

    //    return MCFace.None;
    //}

    void Stretch()
    {
        Debug.Log("Stretching");

        float x = parent.transform.localScale.x;
        float y = parent.transform.localScale.y;
        float z = parent.transform.localScale.z;

        if (face == MCFace.East || face == MCFace.West)
            x += Time.deltaTime * 2;

        if (face == MCFace.South || face == MCFace.North)
            z += Time.deltaTime * 2;

        if (face == MCFace.Up || face == MCFace.Down)
            y += Time.deltaTime * 2;

        parent.transform.localScale = new Vector3(x, y, z);
    }

    void Compress()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "handCollider") { 
            Vector3 rayOrigin = other.gameObject.transform.position;
            Vector3 rayDirection = new Vector3(-rayOrigin.x, -rayOrigin.y, -rayOrigin.z);
            rayDirection += transform.position;

            RaycastHit rayHitPoint;
            Ray ray = new Ray(rayOrigin, rayDirection);
            LayerMask layer = LayerMask.GetMask("BasicObject");

            bool result = Physics.Raycast(ray, out rayHitPoint, 100, layer);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1f);

            // If something was hit
            if (result)
            {
                Vector3 laserEnd = rayHitPoint.point;
                face = GetHitFace(rayHitPoint);
                Debug.Log("Hit " + face + " face");
            }

            Debug.Log("Trigger Enterd, strech mode on?" + modeSwitcher.mode);
            hand = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        hand = null;
    }

}
