using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkGrab : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform epi;
    private Vector3 ogPos;
    private Quaternion ogRot;

    private string name;

    private bool grabbed = false;

    private Image toggleImg;

    void Start()
    {

        ogPos = epi.position;
        ogRot = epi.rotation;

        name = this.gameObject.name;

        toggleImg = GameObject.Find("EPI grabable/Canvas/Panel/"+name+"/Background/Checkmark").GetComponent<Image>();

        Debug.Log(toggleImg);

        
    }

    // Update is called once per frame
    public void returnToOgPos(){


        if(ogPos != epi.position){

            epi.position = ogPos;
            epi.rotation = ogRot;
        }

    }

    public void toggleSelect(){
        toggleImg.enabled = true;
        if(!grabbed){
            Count_EPI.EPICheck +=1;
            grabbed = true;
        }
        

        if(Count_EPI.EPICheck == 5){
            Count_EPI.canMoveToNext = true;
        }
    }
}
