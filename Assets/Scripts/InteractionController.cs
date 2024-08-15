using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using System;

public class InteractionController : MonoBehaviour
{
    public float walkDistance = 1.5f;
    
    float stepPeriod = 0.25f;
    float nextStepTime = -1f;
    public GameObject cam;
    public CharacterController controller;

    Vector3 moveVector;


    public Vector3 getMoveVector()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        var control = new Vector3(y, x, 0);

        Vector3 right = cam.transform.right;
        Vector3 forward = cam.transform.forward;
        Vector3 moveVector = forward * control.y + right * control.x;
        moveVector.y = 0;

        return moveVector.normalized * walkDistance * stepPeriod;
    }

    private void MovePlayer() {

        moveVector = getMoveVector();

        controller.Move(moveVector);
    }

    void Update(){

        MovePlayer();
        
    }


    

    
}


