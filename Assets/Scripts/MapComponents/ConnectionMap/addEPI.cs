using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using MapObjects;
using MapParser;
using System.Linq;
using UnityEngine.UI;
using TMPro;


public class addEPI : MonoBehaviour
{


    [SerializeField] private EpiData epiObjectData;
    private GameObject epiParent;
    private string mapData;
    private string defaultMapPath;
    private string defaultMapFile;

    private float position = 0.4f;

    private GameObject panel;
    private Image toggleImg;
    public TextMeshProUGUI description;

    private Toggle toggle;
    [SerializeField] public List<Toggle> toggles = new List<Toggle>();
  
    // Start is called before the first frame update

    private void Create_entry(string name){


        GameObject toggleObject = new GameObject("Toggle");

        toggleObject.name = name;

        panel = GameObject.Find("EPI grabable/Canvas/Panel");

        toggleObject.transform.SetParent(panel.transform);

        toggle = toggleObject.AddComponent<Toggle>();
        toggles.Add(toggle);

        GameObject background = new GameObject("Background");
        background.transform.SetParent(toggle.transform);

        GameObject checkmark = new GameObject("Checkmark");
        checkmark.transform.SetParent(background.transform);

        
        Image backgroundImage = background.AddComponent<Image>();
        Image checkmarkImage = checkmark.AddComponent<Image>();

        backgroundImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Background");

        checkmarkImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Checkmark");

        GameObject label = new GameObject("Label");
        label.transform.SetParent(toggleObject.transform);
        Text labelText = label.AddComponent<Text>();
        labelText.text = name;
        labelText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        labelText.fontSize = 25;
        


        RectTransform toggleRect = toggleObject.GetComponent<RectTransform>();
        toggleRect.sizeDelta = new Vector2(160, 30); 

        RectTransform backgroundRect = background.GetComponent<RectTransform>();
        backgroundRect.sizeDelta = new Vector2(20, 20);

        RectTransform checkmarkRect = checkmark.GetComponent<RectTransform>();
        checkmarkRect.sizeDelta = new Vector2(16, 16);

        toggleImg = checkmarkImage.GetComponent<Image>();
        toggleImg.enabled = false;

        RectTransform labelRect = label.GetComponent<RectTransform>();
        labelRect.sizeDelta = new Vector2(140, 30);
        labelRect.anchoredPosition = new Vector2(0, 0);

        

        // toggle is on canvas, should change rect transform position to (0,0) of canvas
        RectTransform toggleRectPos = toggleObject.GetComponent<RectTransform>();
        
        //toggleRectPos.anchoredPosition = new Vector2(0, 0);

        // correct z position
        toggleRectPos.localPosition = new Vector3(0, position, 0);
        backgroundRect.localPosition = new Vector3(-100, 0, 0);

        position = position - 0.2f;


        toggleRectPos.transform.rotation = Quaternion.Euler(0, 55, 0);
        toggle.transform.localScale = new Vector3(0.008f, 0.008f, 0.008f);

        Count_EPI.epiCount += 1;


    }


    private void InstanceProp(UnityObject prop, EpiData epiData, string tag = "")
    {   
        string epitype;
        string type = prop.type;
        float[] pos = prop.pos;
        ObjectPrefab propData = null;
        GameObject prefab = null;
        GameObject parent = null;
        
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

        
        name = propData.name;
        epitype = propData.epiType;

        Debug.Log("isGrabbable: " + propData.isGrabbable);

        if(propData.isGrabbable)
        {
            Count_EPI.epiArray.Append(name);

            Create_entry(name);
            
            parent = GameObject.Find("EPI grabable");
        }
        else
        {

            parent = GameObject.Find("EPI");

        }
        

        Debug.Log("Instantiating " + name);

        // Position
        float posX = pos[0]+ propData.offsetX;
        
        float posY = pos[1]+ propData.offsetY;
        
        float posZ = pos[2]+ propData.offsetZ;
        
        Debug.Log("posX: " + posX + " posY: " + posY + " posZ: " + posZ);
        Vector3 vecpos = new Vector3(posX, posY, posZ);


        Quaternion rot = Quaternion.Euler(0, propData.rotation, 0);

        // Create the object
        GameObject obj = Instantiate(prefab, vecpos, rot);
        // Debug.LogWarning($"nome: {.name} quantidade: {obj.GetComponents<MeshCollider>().Count()}");
        // Debug.LogWarning($"nome: {obj.name} quantidade: {prefab.GetComponents<MeshCollider>().Count()}");

        obj.name = name;
        int LayerEpi = LayerMask.NameToLayer("EPI");

        obj.layer = LayerEpi;
        obj.transform.parent = parent.transform;
        obj.tag = tag;
        epitype = obj.tag+epitype;
        Debug.Log("!!!!!!!"+epitype);
    

        AddTagsToChildren(obj.transform, epitype);
        AddLayersToChildren(obj.transform, LayerEpi);


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

    void BuildMap(Session map)
    {
        
        List<UnityObject> unityObjects = map.training.unityObjects;
        
        foreach (UnityObject obj in unityObjects)
            {
                
                InstanceProp(obj, epiObjectData, "EPI");
            }


        Debug.Log(map.training.description);
        
        description.text = map.training.description;

        

       

        

        
        

    }

    void Awake()
    {


        panel = GameObject.Find("EPI grabable/Canvas/Panel");

        defaultMapPath = "Maps/test";

        Debug.Log("defaultMapPath : " + defaultMapPath);
        defaultMapFile = MapLoader.mapFile;
        
        Debug.Log(defaultMapFile);

        if(defaultMapFile == "default"){
            defaultMapFile = Resources.Load<TextAsset>(defaultMapPath).text;
        }

        mapData = defaultMapFile;

        Debug.Log(defaultMapFile);


        IMapParser mapParser = null;



        
        mapParser = new MapParserJSON(mapData);


    
        Session map = mapParser.ParseMap();

        
        // Build the map
        BuildMap(map);

        
    

    }

    public void AddLayersToChildren(Transform parentTransform, int layer)
    {
        
        foreach (Transform child in parentTransform)
        {
           
            child.gameObject.layer = layer;
            AddLayersToChildren(child,layer);
        }
    }
}
