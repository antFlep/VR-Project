using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMapper : MonoBehaviour
{
    // Start is called before the first frame update

    public Material textureMaterial;

    void Start()
    {
        textureMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EmptyScript>())
        {
            Debug.Log(collision.gameObject.name);
            collision.gameObject.GetComponent<MeshRenderer>().material = textureMaterial;
        }
    }
}
