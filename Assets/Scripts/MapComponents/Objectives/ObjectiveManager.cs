using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem particle;

    public Light light;

    public GameObject portal;

    private bool Checked = false;

    public ChangeScene changeScene;

    private void OnTriggerEnter(Collider player){


        if(player.name == "Head"){
            
            if(Count_EPI.canMoveToNext){

                MapLoader.Concluded = true;

                Debug.Log("Concluded");
            
                changeScene.scene_changer("Menu");

            }else{

                Debug.Log("Not yet");

            }

        }

    }

    void Start()
    {

        
        var col = particle.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.red, 1.0f)}, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 1.0f)} );

        col.color = grad;



        light.color = Color.red;

        var portalRenderer = portal.GetComponent<Renderer>();
        portalRenderer.material.SetColor("_Color", Color.red);


        
    }

    // Update is called once per frame
    void Update()
    {

        if(Count_EPI.canMoveToNext && !Checked){

            var col = particle.colorOverLifetime;
            col.enabled = true;

            Gradient grad = new Gradient();
            grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.green, 1.0f)}, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 1.0f)} );

            col.color = grad;



            light.color = Color.green;

            var portalRenderer = portal.GetComponent<Renderer>();
            portalRenderer.material.SetColor("_Color", Color.green);

            Checked = true;

        }
        
    }
}
