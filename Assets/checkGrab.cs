using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGrab : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform epi;
    private Vector3 ogPos;
    private Quaternion ogRot;
    void Start()
    {

        ogPos = epi.position;
        ogRot = epi.rotation;
        
    }

    // Update is called once per frame
    public void returnToOgPos(){


        if(ogPos != epi.position){

            epi.position = ogPos;
            epi.rotation = ogRot;
        }

    }
}
