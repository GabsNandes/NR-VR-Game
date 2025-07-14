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

    private TextMeshProUGUI infoCheck;

    string[] collectioncar;

    public Image targetImage;

    private Sprite loadedSprite;

    private Image toggleImg;

    private int doorCounter = 0;

    private int wheelCounter = 0;

    private int checks = 0;

    public void toggleSelect(Image toggleImg)
    {

        if (!toggleImg.enabled)
        {
            toggleImg.enabled = true;

        }

    }

    void check(string name)
    {

        Debug.Log(name + "<--F");
        toggleImg = GameObject.Find("check/Canvas/Panel/" + name + "/Background/Checkmark").GetComponent<Image>();
        toggleSelect(toggleImg);

        checks += 1;

        if (checks == 4)
        {
            infocar.text = "Todos os componentes foram analizados, hora de fazer o novo carro!";
            loadedSprite = Resources.Load<Sprite>("car");
            targetImage.sprite = loadedSprite;
        }


    
    }
    
    void Start()
    {

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
                wheelCounter += 1;
        

                infocar.text = collectioncar[2];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);
                infoCheck = GameObject.Find("check/Canvas/Panel/Wheel/Label").GetComponent<TextMeshProUGUI>();
                infoCheck.text = "Rodas " + wheelCounter + "/4";  

                if (wheelCounter == 4)
                {
                    check("Wheel");
                }

                break;

            case "Engine":

            
                loadedSprite = Resources.Load<Sprite>("engine");
        
                targetImage.sprite = loadedSprite;
                targetImage.enabled = true;

                infocar.text = collectioncar[1];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);

                
                check("Engine");
                

                break;

            case "Bonet":

                loadedSprite = Resources.Load<Sprite>("bonet");
        
                targetImage.sprite = loadedSprite;
                targetImage.enabled = true;

                infocar.text = collectioncar[0];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);

                check("Bonet");

                break;

            case "Door":

                loadedSprite = Resources.Load<Sprite>("door");
        
                targetImage.sprite = loadedSprite;
                targetImage.enabled = true;
                doorCounter += 1;

                infocar.text = collectioncar[0];
                Destroy(collider.gameObject);
                Debug.Log(collider.tag);
                infoCheck = GameObject.Find("check/Canvas/Panel/Door/Label").GetComponent<TextMeshProUGUI>();
                infoCheck.text = "Portas " + doorCounter + "/2"; 

                if (doorCounter == 2)
                {
                    check("Door");
                }

                

                break;

            



        }




    }
}
