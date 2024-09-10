using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canvasLoader : MonoBehaviour
{
    public TextMeshProUGUI textComponent1;
    public TextMeshProUGUI textComponent2;


    public void ActivateTexts()
    {
        
        if(MapLoader.Concluded)
        {
            textComponent1.gameObject.SetActive(true);

        }

        if(MapLoader.Warn){
            MapLoader.Warn = false;
            textComponent2.gameObject.SetActive(false);

        }
        
    }

    // Optional: You can call ActivateTexts when a specific event occurs
    private void Start()
    {
        // For example, activate texts when the game starts
        ActivateTexts();
    }
}
