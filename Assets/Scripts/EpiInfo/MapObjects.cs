using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

namespace MapObjects
{
    public interface MapProp
    {
        public float[] getPos();
        public string getType();
    }


    [Serializable]
    public class ObjectPrefab
    {
        // Used as a return type for GetObject
        public string name;
        public GameObject prefab;
        public float offsetX;
        public float offsetY;
        public int rotation;
        public bool isGrabbable;
    }

    

    [Serializable]
    public class EPI : MapProp
    {
        public float[] pos;
        public string type;

        public float[] getPos()
        {
            return pos;
        }

        public string getType()
        {
            return type;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.pos != null)
            {
                sb.Append("EPI: " + this.type + " " + this.pos[0] + " " + this.pos[1]);
            }
            else
            {
                sb.Append("EPI: " + this.type + " null");
            }
            return sb.ToString();
        }
    }

    
    [Serializable]
    public class Layers
    {

        public List<EPI> epi;

    }

    [Serializable]
    public class Map
    {
     
        public Layers layers;

        public Map(
            
            List<EPI> epi
        )
        {

            this.layers = new Layers
            {
                epi = epi
            };
        }

        public string mapRepresentationString()
        {

            StringBuilder sb = new StringBuilder();

            
            sb.Append("Epi: \n");
            foreach (EPI epi in this.layers.epi)
                sb.Append("\tEPI: " + epi.type + " " + epi.pos[0] + " " + epi.pos[1] + "\n");

            return sb.ToString();
        }

    }
}