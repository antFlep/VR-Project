using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuController : MonoBehaviour
{
    GameObject pnlMain;
    GameObject pnlObjects;
    GameObject pnlTextures;
    GameObject fps;

    public GameObject baseObject;

    // Start is called before the first frame update
    void Start()
    {
        fps = GameObject.Find("FPSController");
        pnlMain = GameObject.Find("pnlMain");
        pnlObjects = GameObject.Find("pnlObjects");
        pnlTextures = GameObject.Find("pnlTextures");
        BackToMain();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToMain();
    }

    // Switch to objects submenu
    public void ClickObjects()
    {
        pnlObjects.SetActive(true);
        pnlMain.SetActive(false);
    }

    // Switch to textures submenu
    public void ClickTextures()
    {
        pnlTextures.SetActive(true);
        pnlMain.SetActive(false);
    }

    // Switch back to main menu
    public void BackToMain()
    {
        pnlMain.SetActive(true);
        pnlObjects.SetActive(false);
        pnlTextures.SetActive(false);
    }

    // Creae Object
    public void SpawnObject()
    {
        Instantiate(baseObject, fps.transform.position + new Vector3(2, 2, 2), new Quaternion(0, 0, 0, 0));
    }
}
