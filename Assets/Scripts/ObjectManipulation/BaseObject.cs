using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    float scaleFactor = 0.01f;
    float x;

    public string mode = "none";
    public MCFace face;
    public bool isActive = false;

    GameObject parent;


    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            //if (mode.Equals("none"))
            //    Debug.Log("noting to Do");
            if (mode.Equals("shrink"))
                Shrink();
            if (mode.Equals("expand"))
                Expand();
            if (mode.Equals("rotate"))
                Rotate();
            if (mode.Equals("stretch"))
                Stretch();

        }
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
        //Debug.Log("hit.normal before:" + hit.normal + " after: " + transform.TransformVector(hit.normal ));

        float x = incomingVec.x;
        float y = incomingVec.y;
        float z = incomingVec.z;

        float xScale = parent.transform.localScale.x;
        float yScale = parent.transform.localScale.y;
        float zScale = parent.transform.localScale.z;

        //incomingVec = new Vector3(x / xScale, y / yScale, z / zScale);

        Vector3 SOUTH = (new Vector3(0, -1 , -1));
        Vector3 NORTH = (new Vector3(0, -1 ,  1));
        Vector3 UP    = (new Vector3(0, 0, 0));
        Vector3 DOWN  = (new Vector3(0, -2 , 0));
        Vector3 WEST  = (new Vector3(-1, -1 , 0));
        Vector3 EAST  = (new Vector3( 1, -1 , 0));

        //SOUTH.y *= yScale;
        //NORTH.y *= yScale;
        //WEST.y *= yScale;
        //EAST.y *= yScale;
        //UP.y *= yScale;
        //DOWN.y *= yScale;


        Debug.Log("Incoming Vec: " + incomingVec +
            "\nS: " + SOUTH + " N: " + NORTH +
            "\nW: " + WEST + " E: " + EAST +
            "\nU: " + UP + " D: " + DOWN);

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
        if (Input.GetAxis("Mouse X") > 0)
        {
            Debug.Log("Stretching");

            float x = parent.transform.localScale.x;
            float y = parent.transform.localScale.y;
            float z = parent.transform.localScale.z;

            if (face == MCFace.East || face == MCFace.West)
                x += Time.deltaTime * 10;

            if (face == MCFace.South || face == MCFace.North)
                z += Time.deltaTime * 10;

            if (face == MCFace.Up || face == MCFace.Down)
                y += Time.deltaTime * 10;

            parent.transform.localScale = new Vector3(x, y, z);
        }
    }

    void Compress()
    {

    }
}
