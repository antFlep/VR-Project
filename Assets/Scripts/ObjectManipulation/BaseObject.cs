using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    float scale = 1;
    float scaleFactor = 0.01f;
    float x;

    public string mode = "none";
    public MCFace face;
    public bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
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
        scale -= scaleFactor;

        if (scale < 0)
        {
            scale += scaleFactor;
            mode = "none";
            isActive = false;
        }

        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Expand()
    {
        scale += scaleFactor;
        Debug.Log("Cannot be Shrunk further");
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Rotate()
    {
        Debug.Log("Rotating");
        float x = transform.rotation.eulerAngles.x;
        float y = transform.rotation.eulerAngles.y;
        float z = transform.rotation.eulerAngles.z;

        if (Input.GetAxis("Mouse X") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved left");
            y += Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(x, y, z);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved right");
            y -= Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(x, y, z);
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved left");
            x += Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(x, y, z);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved right");
            x -= Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(x, y, z);
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

        Vector3 incomingVec = hit.normal - transform.TransformVector(new Vector3(0, 1 / transform.localScale.y, 0));

        //float x = incomingVec.x;
        //float y = incomingVec.y;
        //float z = incomingVec.z;

        float xScale = transform.localScale.x;
        float yScale = transform.localScale.y;
        float zScale = transform.localScale.z;

        //incomingVec = new Vector3(x / xScale, y / yScale, z * zScale);


        Vector3 SOUTH = transform.TransformVector(new Vector3(0, -1/yScale, -1/zScale));
        Vector3 NORTH = transform.TransformVector(new Vector3(0, -1/yScale, 1/zScale));
        Vector3 UP = transform.TransformVector(new Vector3(0, 0, 0));
        Vector3 DOWN = transform.TransformVector(new Vector3(0, -2/yScale, 0));
        Vector3 WEST = transform.TransformVector(new Vector3(-1/xScale, -1/yScale, 0));
        Vector3 EAST = transform.TransformVector(new Vector3(1/xScale, -1/yScale, 0));


        Debug.Log("Incoming Vec: " + incomingVec + 
            "\nS: " + SOUTH + " N: " + NORTH +
            "\nW: " + WEST + " E: " + EAST +
            "\nU: " + UP + " D: " + DOWN); 
            

        if (incomingVec == SOUTH)
        {
            Debug.Log("Hit South");
            return MCFace.South;
        }

        if (incomingVec == NORTH)
        {
            Debug.Log("Hit North");
            return MCFace.North;
        }

        if (incomingVec == UP)
        {
            Debug.Log("Hit Up");
            return MCFace.Up;
        }

        if (incomingVec == DOWN)
        {
            Debug.Log("Hit Down");
            return MCFace.Down;
        }

        if (incomingVec == WEST)
        {
            Debug.Log("Hit West");
            return MCFace.West;
        }

        if (incomingVec == EAST)
        {
            Debug.Log("Hit East");
            return MCFace.East;
        }

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
            if (face == MCFace.East || face == MCFace.West)
            {
                Debug.Log("I'm in");
                float x = transform.localScale.x;
                float y = transform.localScale.y;
                float z = transform.localScale.z;
                x += Time.deltaTime * 10;
                transform.localScale = new Vector3 (x, y, z);
            }

            if (face == MCFace.South || face == MCFace.North)
            {
                Debug.Log("I'm in");
                float x = transform.localScale.x;
                float y = transform.localScale.y;
                float z = transform.localScale.z;
                z += Time.deltaTime * 10;
                transform.localScale = new Vector3(x, y, z);
            }
        }
    }
}
