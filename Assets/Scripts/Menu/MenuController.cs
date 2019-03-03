using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject fps;
    public FirstPersonController fpsController;
    public bool vrEnabled = false;

    GameObject menu;
    GameObject pnlMain;
    GameObject pnlObjects;
    GameObject pnlTextures;

    // Start is called before the first frame update
    void Start()
    {
        if (vrEnabled)
        {
            Debug.Log("Vr is enabled");
        }
        else
        {
            menu        = menuCanvas.transform.Find("MainMenu").gameObject;
            pnlMain     = menu.transform.Find("pnlMain").gameObject;
            pnlObjects  = menu.transform.Find("pnlObjects").gameObject;
            pnlTextures = menu.transform.Find("pnlTextures").gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !vrEnabled)
        {
            if (fpsController.isActiveAndEnabled)
            {
                fpsController.enabled = false;
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                fpsController.enabled = true;
                menu.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !vrEnabled)
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
}
