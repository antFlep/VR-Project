using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CreateObject : MonoBehaviour
{
    public GameObject spawnObject;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.root.name == "Player")
            Instantiate(spawnObject, transform.position, new Quaternion(0, 0, 0, 0));
    }
}
