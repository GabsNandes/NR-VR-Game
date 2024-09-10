using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using JsonUtility = UnityEngine.JsonUtility;
using System.Linq;
using System;

public class ButtonManager : MonoBehaviour
{
    public ChangeScene changeScene;
    public TMP_InputField mapCode;

    string url = "http://10.101.0.39:8080/api/v1/session/code";



    public void OnClick(){

        Debug.Log(mapCode.text);
        
        url = url + "/" + mapCode.text;


        try{
            
            using HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string jsonString = response.Content.ReadAsStringAsync().Result;
            Debug.Log(jsonString);
            MapLoader.mapFile = jsonString;

        }catch (Exception ex){

            Debug.Log("Ocorreu um erro para finalizar mapa: " + ex.Message);
            
            Debug.Log ("Using Default Scene");
        }

        
        

        changeScene.scene_changer("SampleScene");

    }
}
