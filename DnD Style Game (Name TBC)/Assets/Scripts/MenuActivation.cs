using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivation : MonoBehaviour
{
    [SerializeField] private KeyCode triggerKey;

    [SerializeField] private GameObject menu;

    //[SerializeField] MouseLook cameraScript;


    void Update()
    {
        
        if (Input.GetKeyDown(triggerKey))
        {
            if(menu.activeSelf)
            {
                Time.timeScale = 1.0f;
                menu.SetActive(false);
                //cameraScript.enabled = true;
            }
            else
            {
                Time.timeScale = 0.0f;
                menu.SetActive(true);
                //cameraScript.enabled = false;
            }
            
        }
    }

    //change timescale - has to be done in fixed + should probably find a more efficient way of doing this - maybe a method checking activeself
    private void FixedUpdate()
    {
        if (menu.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

}
