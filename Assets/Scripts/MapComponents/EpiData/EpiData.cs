using System;
using System.Collections.Generic;
using UnityEngine;
using MapObjects;
using System.Linq;

[CreateAssetMenu(fileName = "EpiData", menuName = "ScriptableObjects/EpiData", order = 1)]

public class EpiData : ScriptableObject
{

    [SerializeField]
    public Dictionary<string, GameObject> objectMap = new Dictionary<string, GameObject>();

    [SerializeField]
    public List<ObjectEntry> Objects = new List<ObjectEntry>();


    [Serializable]
    public class ObjectVariation
    {   
        public GameObject prefab;
        public string id;
        public float offsetX;
        public float offsetY;
        public float offsetZ;
        public int rotation;
        public bool isGrabbable;
    
    }

    [Serializable]
    public class ObjectEntry
    {


        public string name;
        
        
        public List<ObjectVariation> variations = new List<ObjectVariation>();


    }

    public ObjectPrefab GetObject(string id)
    {
        for (int i = 0; i < Objects.Count; i++)
        {
        
            if (Objects[i].variations.Exists(x => x.id == id))
            {
                ObjectVariation variation = Objects[i].variations.Find(x => x.id == id);
                
                return new ObjectPrefab
                {

                    name = Objects[i].name,
                    
                    prefab = variation.prefab,
                    rotation = variation.rotation,
                    offsetX = variation.offsetX,
                    offsetY = variation.offsetY,
                    offsetZ = variation.offsetZ,
                    isGrabbable = variation.isGrabbable
                    
                    
                };
            }
            
        }
        throw new System.Exception("Object " + id + " not found");
    }

    private bool TryGetObjectEntry(string name, out ObjectEntry objectEntry)
    {
        
            
        objectEntry = Objects.FirstOrDefault(x => x.name == name);
        return objectEntry != null;
        
        
    } 

}
