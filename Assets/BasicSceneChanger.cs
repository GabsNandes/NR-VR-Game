using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicSceneChanger : MonoBehaviour
{

    public ChangeScene changeScene;
    public InputActionProperty showButton;

    public static int pos = 0;

    public static bool end = false;

    private string[] scenes = new string[] { "CarScene 1", "CarScene 2" };

    void Update() {

        if ((showButton.action.WasPressedThisFrame() || Input.GetKeyDown(KeyCode.K)))
        {
            if (pos < 2)
            {
                changeScene.basic_change(scenes[pos]);
            }
            else
            {
                changeScene.quit();
            }
            

        }

        
    }

    


}
