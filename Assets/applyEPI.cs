using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class applyEPI : MonoBehaviour
{
    // Start is called before the first frame update

    private string name;
    private Image toggleImg;
    private Transform parent;

    private GameObject son;

    public AudioSource audioSource;




    public void OnCollisionEnter(Collision collision){

        Debug.Log("WWWW"+collision.gameObject);
        
        if(collision.gameObject.tag=="EPI"){
            
            parent = collision.gameObject.transform.parent;
            son = collision.gameObject;
            name = collision.gameObject.name;
            
            while(son.gameObject.transform.parent!=null){

                Debug.Log(name+"<--");
                parent = son.gameObject.transform.parent;
                Debug.Log(parent.name);
                
                Debug.Log(name+"<--");
                Debug.Log(son.name);
                son = parent.gameObject;
                Debug.Log(son.name);
                name = son.gameObject.name;
                
            }
            
            Debug.Log(name+"<--F");
            toggleImg = GameObject.Find("EPI grabable/Canvas/Panel/"+name+"/Background/Checkmark").GetComponent<Image>();
            toggleSelect(toggleImg);
            audioSource.Play();

            if(son.tag != "Map"){
                Destroy(son);
            }
            

        }

    }

    public void toggleSelect(Image toggleImg){
        
        if(!toggleImg.enabled){
            toggleImg.enabled = true;
            Count_EPI.EPICheck +=1;
            
        }
        

        if(Count_EPI.EPICheck == Count_EPI.epiCount){
            Count_EPI.canMoveToNext = true;
        }
    }

}
