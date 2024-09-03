using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System;
using System.IO.Compression;
using Newtonsoft.Json;

public class checkGrab : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform epi;
    private Vector3 ogPos;
    private Quaternion ogRot;

    private string name;

    private bool grabbed = false;

    private Image toggleImg;
    private bool check = true;

    private string url = "http://10.101.2.89:8080/api/v1/activities";

    public void Start()
    {
        epi = this.transform;
        ogPos = epi.position;
        ogRot = epi.rotation;

        
        name = epi.name;
    }
    [Serializable]
    public class Activity{

        public string name;
        public int sessionId;
        public int unityObjectId;

        public float posX;

        public float posY;

        public float posZ;


    }

    public void grabApi(){

        Activity activity = new Activity();

        activity.name = this.gameObject.name;
        activity.sessionId = 1;
        activity.unityObjectId = 2;

        activity.posX = this.transform.position.x;
        activity.posY = this.transform.position.y;
        activity.posZ = this.transform.position.z;

        string str = JsonUtility.ToJson(activity);
        dynamic json = JsonConvert.DeserializeObject(str);


        try{
            using HttpClient httpClient = new HttpClient();
            var response = httpClient.PostAsync(url,json);


        }catch(Exception ex){
            Debug.Log(ex.Message);
        }


    }


    // Update is called once per frame
    public void returnToOgPos(){


        if(ogPos != epi.position){

            epi.position = ogPos;
            epi.rotation = ogRot;
        }

    }
}
