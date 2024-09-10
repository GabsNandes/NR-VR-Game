using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public static ChangeScene instance;



    public void scene_changer(string scene_name){

        Count_EPI.EPICheck = 0;
        Count_EPI.epiCount = 0;
        Count_EPI.canMoveToNext = false;

        SceneManager.LoadScene(scene_name);  
      
    }

    public void LoadDefault(){
        scene_changer("SampleScene");
    }

    public void quit(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
