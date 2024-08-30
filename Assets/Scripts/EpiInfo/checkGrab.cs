using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void Start()
    {
        epi = this.transform;
        ogPos = epi.position;
        ogRot = epi.rotation;

        
        name = epi.name;
    }


    // Update is called once per frame
    public void returnToOgPos(){


        if(ogPos != epi.position){

            epi.position = ogPos;
            epi.rotation = ogRot;
        }

    }
}
