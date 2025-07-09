using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization; 
using UnityEngine.UI;     
using System.IO;
using UnityEngine.XR;
using TMPro;


public class infoGetter : MonoBehaviour
{
    public TextAsset file;
    private string text;

    private TextMeshProUGUI infocar;

    string[] collectioncar;

    public Image targetImage;

    private Sprite loadedSprite;
    
    void Start()
    {
        loadedSprite = Resources.Load<Sprite>("car");
        if (loadedSprite != null)
        {
            targetImage.sprite = loadedSprite;
            targetImage.enabled = true;
        }

        text = file.ToString();

        collectioncar = ClearString();

        infocar = GameObject.Find("cardisp/Canvas/Panel/DisplayCar").GetComponent<TextMeshProUGUI>();


    }

    private string[] ClearString()
    {

        text = file.ToString();

        string[] collection = text.Split('$', StringSplitOptions.RemoveEmptyEntries);

        return collection;

    }
    public void OnTriggerEnter(Collider collider)
    {

        switch (collider.tag)
        {

            case "Wheel":

                loadedSprite = Resources.Load<Sprite>("wheel");
        
                targetImage.sprite = loadedSprite;
                targetImage.enabled = true;
        

                infocar.text = collectioncar[2];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);

                break;

            case "Engine":

            
                loadedSprite = Resources.Load<Sprite>("engine");
        
                targetImage.sprite = loadedSprite;
                targetImage.enabled = true;

                infocar.text = collectioncar[1];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);

                break;

            case "Bonet":

                loadedSprite = Resources.Load<Sprite>("bonet");
        
                targetImage.sprite = loadedSprite;
                targetImage.enabled = true;

                infocar.text = collectioncar[0];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);

                break;

            case "Door":

                loadedSprite = Resources.Load<Sprite>("door");
        
                targetImage.sprite = loadedSprite;
                targetImage.enabled = true;

                infocar.text = collectioncar[0];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);

                break;

            



        }




    }
}
