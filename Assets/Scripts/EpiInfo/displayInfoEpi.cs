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

public class displayInfoEpi : MonoBehaviour
{
    public TextAsset file;
    private string text;

    private TextMeshProUGUI infoEPI;

    public GameObject epi;

    private string name;

    string[] collectionEPI;

    void Start(){

        text = file.ToString();

        collectionEPI = ClearString();

        infoEPI = GameObject.Find("EPI/Canvas/Panel/DisplayEPI").GetComponent<TextMeshProUGUI>();

        name = epi.name;

    }
    
    private string[] ClearString(){

            text = file.ToString();

            string[] collection = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return collection;

        }

    public void returnInformation(){

        switch(name){

            case "Capacete":
                infoEPI.text = collectionEPI[0];
            break;

            case "Oculos":
                infoEPI.text = collectionEPI[1];
            break;

            case "Botas":
                infoEPI.text = collectionEPI[2];
            break;

            case "Veste":
                infoEPI.text = collectionEPI[3];
            break;

            case "Protetores de ouvido":
                infoEPI.text = collectionEPI[4];
            break;

        }

    }
}
