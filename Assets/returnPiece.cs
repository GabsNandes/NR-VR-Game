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

public class returnPiece : MonoBehaviour
{

    private TextMeshProUGUI infocar;

    private Sprite loadedSprite;

    private Image toggleImg;

    public Image targetImage;
    
    private TextMeshProUGUI infoCheck;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        infocar = GameObject.Find("cardisp/Canvas/Panel/DisplayCar").GetComponent<TextMeshProUGUI>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }


    
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

        values.checks += 1;

        if (values.checks == 4)
        {
            infocar.text = "Todos os componentes foram colocados, parabéns!";
            loadedSprite = Resources.Load<Sprite>("car");
            targetImage.sprite = loadedSprite;
        }


    
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.name == gameObject.name)
        {

            switch (collider.tag)
            {

                case "Wheel":


                    values.wheelCounter += 1;

                    infoCheck = GameObject.Find("check/Canvas/Panel/Wheel/Label").GetComponent<TextMeshProUGUI>();
                    infoCheck.text = "Rodas " + values.wheelCounter + "/4";

                    if (values.wheelCounter == 4)
                    {
                        check("Wheel");
                    }

                    break;

                case "Door":

                    values.doorCounter += 1;


                    infoCheck = GameObject.Find("check/Canvas/Panel/Door/Label").GetComponent<TextMeshProUGUI>();
                    infoCheck.text = "Portas " + values.doorCounter + "/2";

                    if (values.doorCounter == 2)
                    {
                        check("Door");
                    }

                    break;

                default:

                    infoCheck = GameObject.Find("check/Canvas/Panel/" + collider.tag + "/Label").GetComponent<TextMeshProUGUI>();
                    check(collider.tag);

                    break;


            }
            Destroy(collider.gameObject);
            meshRenderer.enabled = true;

        
                


        }
    }    
}
