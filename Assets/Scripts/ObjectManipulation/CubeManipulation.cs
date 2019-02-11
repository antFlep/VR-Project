using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManipulation : MonoBehaviour
{
    float scale = 1;
    float scaleFactor = 0.01f;
    public string mode = "none";
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
            if (mode.Equals("none"))
            {
                Debug.Log("noting to Do");
            }
            if (mode.Equals("shrink"))
            {
                scale -= scaleFactor;

                if (scale < 0)
                {
                    scale += scaleFactor;
                    mode = "none";
                    isActive = false;
                    Debug.Log("Cannot be Shrunk further");
                }
                ExpandAndShrink();
                Debug.Log("Shrinking");
            }
            if (mode.Equals("expand"))
            {
                scale += scaleFactor;
                ExpandAndShrink();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object was triggerd");
    }

    void ExpandAndShrink()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

}
