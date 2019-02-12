﻿using System.Collections;
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

        Vector3 incomingVec = hit.normal - transform.TransformVector(Vector3.up);

        //float x = incomingVec.x;
        //float y = incomingVec.y;
        //float z = incomingVec.z;

        //float xScale = transform.localScale.x;
        //float yScale = transform.localScale.y;
        //float zScale = transform.localScale.z;

        //incomingVec = new Vector3(x*xScale, y*yScale, z*zScale);

        Debug.Log("Incoming Vec: " + incomingVec + 
            "\nS: " + transform.TransformVector(new Vector3( 0, -1, -1)) + " N: " + transform.TransformVector(new Vector3(0, -1, 1)) +
            "\nW: " + transform.TransformVector(new Vector3(-1, -1,  0)) + " E: " + transform.TransformVector(new Vector3(1, -1, 0)) +
            "\nU: " + transform.TransformVector(new Vector3( 0,  0,  0)) + " D: " + transform.TransformVector(new Vector3(0, -2, 0))); 
            

        if (incomingVec == transform.TransformVector(new Vector3(0, -1, -1)))
        {
            Debug.Log("Hit South");
            return MCFace.South;
        }

        if (incomingVec == transform.TransformVector(new Vector3(0, -1, 1)))
        {
            Debug.Log("Hit North");
            return MCFace.North;
        }

        if (incomingVec == transform.TransformVector(new Vector3(0, 0, 0)))
        {
            Debug.Log("Hit Up");
            return MCFace.Up;
        }

        if (incomingVec == transform.TransformVector(new Vector3(0, -2, 0)))
        {
            Debug.Log("Hit Down");
            return MCFace.Down;
        }

        if (incomingVec == transform.TransformVector(new Vector3(-1, -1, 0)))
        {
            Debug.Log("Hit West");
            return MCFace.West;
        }

        if (incomingVec == transform.TransformVector(new Vector3(1, -1, 0)))
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