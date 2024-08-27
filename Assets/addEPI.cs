using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using MapObjects;
using MapParser;
using System.Linq;


public class addEPI : MonoBehaviour
{

    [SerializeField] private TextAsset mapFile;
    [SerializeField] private EpiData epiObjectData;
    private GameObject epiParent;
    private string mapData;
    private string defaultMapPath;
    private TextAsset defaultMapFile;
  
    // Start is called before the first frame update


    private void InstanceProp(MapProp prop, EpiData epiData, GameObject parent = null, string tag = "")
    {
        string type = prop.getType();
        float[] pos = prop.getPos();
        ObjectPrefab propData = null;
        GameObject prefab = null;
        
        try
        {
            propData = epiData.GetObject(type);
            prefab = propData.prefab;
            
        }
        catch (System.Exception)
        {
            Debug.LogError("Prefab not found for type " + type + " in data file " + epiData);
            return;
        }


        string name = prefab.name;

        Debug.Log("Instantiating " + name);

        // Position
        float posX = pos[0]+ propData.offsetX;
        Debug.Log("posX: " + pos[0]);
        float posZ = -pos[1];
        Debug.Log("posX: " + posX + " posZ: " + posZ);
        Vector3 vecpos = new Vector3(posX, propData.offsetY, posZ);


        Quaternion rot = Quaternion.Euler(0, propData.rotation, 0);

        // Create the object
        GameObject obj = Instantiate(prefab, vecpos, rot);
        // Debug.LogWarning($"nome: {.name} quantidade: {obj.GetComponents<MeshCollider>().Count()}");
        // Debug.LogWarning($"nome: {obj.name} quantidade: {prefab.GetComponents<MeshCollider>().Count()}");

        obj.name = name;

        obj.transform.parent = parent.transform;
        obj.tag = tag;


    

        AddTagsToChildren(obj.transform, obj.tag);


        // Use this code to remove extra colliders in the prefab
        
        // var meshColliders = prefab.GetComponents<MeshCollider>();
        // if (meshColliders.Count() > 0)
        // {
        //     //Debug.Log("Deleting " + meshColliders.Count() + " colliders");
        //     for (int i = 0; i < meshColliders.Count(); i++)
        //     {
        //         DestroyImmediate(meshColliders[i], true);
        //     }
        // }
        
    }

    public void AddTagsToChildren(Transform parentTransform, string tag = "")
    {
        
        foreach (Transform child in parentTransform)
        {
           
            child.gameObject.tag = tag;
            AddTagsToChildren(child,tag);
        }
    }

    void BuildMap(Map map)
    {
        
        List<EPI> epi = map.layers.epi;
        
        foreach (EPI obj in epi)
            {
                 InstanceProp(obj, epiObjectData, epiParent, "EPI");
            }

       

        

        Transform mapTransform = GetComponent<Transform>();
        epiParent.transform.parent = mapTransform;

    }

    void Awake()
    {


    
        epiParent = GameObject.Find("EPI grabable");

        defaultMapPath = "Maps/test";

        Debug.Log("defaultMapPath : " + defaultMapPath);
        defaultMapFile = Resources.Load<TextAsset>(defaultMapPath);
        Debug.Log(defaultMapFile);

        mapData = defaultMapFile.text;



        if (mapFile == null)
        {
            Debug.LogError("No map file found");
            return;
        }

        IMapParser mapParser = null;



        
        mapParser = new MapParserJSON(mapData);


    
        Map map = mapParser.ParseMap();
        // Build the map
        BuildMap(map);

        
    

    }
}
