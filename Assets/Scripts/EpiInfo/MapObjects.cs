using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

namespace MapObjects
{
    [Serializable]
    public class Session {
        public string id;
        public string code;
        public Training training;
    }

    [Serializable]
    public class Training {
        public string name;
        public string description;
        public List<UnityObject> unityObjects;
    }


    // public interface MapProp
    // {
    //     public float[] getPos();
    //     public string getType();
    // }


    [Serializable]
    public class ObjectPrefab
    {
        // Used as a return type for GetObject
        public string name;
        public GameObject prefab;
        public float offsetX;
        public float offsetY;

        public float offsetZ;
        public int rotation;
        public bool isGrabbable;
    }

    

    [Serializable]
    public class UnityObject 
    {
        public float[] pos;
        public string type;

    }
    

    

    [Serializable]
    public class Map
    {
     
        public List<UnityObject> unityObjects;

        public string mapRepresentationString()
        {

            StringBuilder sb = new StringBuilder();

            
            sb.Append("Epi: \n");
            foreach (UnityObject unityObjects in this.unityObjects)
                sb.Append("\tEPI: " + unityObjects.type + " " + unityObjects.pos[0] + " " + unityObjects.pos[1] +" " + unityObjects.pos[1] + "\n");

            return sb.ToString();
        }

    }
}