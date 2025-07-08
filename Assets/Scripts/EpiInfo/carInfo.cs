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


public class carInfo : MonoBehaviour
{
    public TextAsset file;
    private string text;

    private TextMeshProUGUI infocar;


    string[] collectioncar;

    void Start()
    {

        text = file.ToString();

        collectioncar = ClearString();

        infocar = GameObject.Find("cardisp/Canvas/Panel/DisplayCar").GetComponent<TextMeshProUGUI>();


    }

    private string[] ClearString()
    {

        text = file.ToString();

        string[] collection = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        return collection;

    }

    public void returnInformation()
    {

        infocar.text = collectioncar[0];

    }


}
