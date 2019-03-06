using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldWrapper : MonoBehaviour
{
    public ModeSwitcher modeSwitcher;
    public Material weldMaterial;

    Material origMaterial;
    MeshRenderer renderer;
    public bool highlight = false;

    // Start is called before the first frame update
    void Start()
    {
        modeSwitcher = GameObject.Find("MasterObject").GetComponent<ModeSwitcher>();
        if (GetComponent<MeshRenderer>())
        {
            renderer = GetComponent<MeshRenderer>();
            origMaterial = renderer.material;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (modeSwitcher.weldObject1.Equals(this.gameObject) || modeSwitcher.weldObject2.Equals(this.gameObject) || highlight)
        {
            if (renderer)
            {
                //origMaterial = renderer.material;
                renderer.material = weldMaterial;
                HighlightChildren();
            }
        } else
        {
            if(renderer)
            {
                renderer.material = origMaterial;
                UnHighlightChildren();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "RightHandCollider")
        {
            Debug.Log("Obj1");
            modeSwitcher.weldObject1 = transform.gameObject;
        }

        if (collider.gameObject.name == "LeftHandCollider")
        {
            Debug.Log("Obj2");
            modeSwitcher.weldObject2 = transform.gameObject;
        }
    }

    private void HighlightChildren()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                WeldWrapper childWeld = child.GetComponent<WeldWrapper>();
                if (childWeld)
                {
                    childWeld.highlight = true;
                }
            }
        }
    }

    private void UnHighlightChildren()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                WeldWrapper childWeld = child.GetComponent<WeldWrapper>();
                if (childWeld)
                {
                    childWeld.highlight = false;
                }
            }
        }
    }
}
