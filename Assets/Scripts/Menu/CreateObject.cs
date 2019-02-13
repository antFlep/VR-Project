using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CreateObject : MonoBehaviour
{
    public GameObject baseObject;
    public GameObject fps;

    // Start is called before the first frame update
    void Start()
    {
        fps = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void spawn()
    {
        Instantiate(baseObject, fps.transform.position + new Vector3(2, 2, 2), new Quaternion(0, 0, 0, 0));
    }
}
