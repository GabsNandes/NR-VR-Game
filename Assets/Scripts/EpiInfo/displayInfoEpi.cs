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

    public TextMeshProUGUI infoEPI;

    public GameObject epi;

    private string name;

    string[] collectionEPI;

    void Start(){

        text = file.ToString();

        collectionEPI = ClearString();

        name = epi.name;

    }
    
    private string[] ClearString(){

            text = file.ToString();

            string[] collection = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return collection;

        }

    public void returnInformation(){

        switch(name){

            case "HardHat":
                infoEPI.text = collectionEPI[0];
            break;

            case "Glasses":
                infoEPI.text = collectionEPI[1];
            break;

            case "Boots":
                infoEPI.text = collectionEPI[2];
            break;

            case "Vest":
                infoEPI.text = collectionEPI[3];
            break;

            case "EarMuffs":
                infoEPI.text = collectionEPI[4];
            break;

        }

    }
}