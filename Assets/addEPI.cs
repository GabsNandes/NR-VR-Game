using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using MapObjects;
using MapParser;
using System.Linq;
using UnityEngine.UI;


public class addEPI : MonoBehaviour
{

    [SerializeField] private TextAsset mapFile;
    [SerializeField] private EpiData epiObjectData;
    private GameObject epiParent;
    private string mapData;
    private string defaultMapPath;
    private TextAsset defaultMapFile;

    private float position = 0.4f;

    private GameObject panel;
    private Image toggleImg;

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

        name = propData.name;
        Count_EPI.epiArray.Append(name);

        Create_entry(name);

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


        panel = GameObject.Find("EPI grabable/Canvas/Panel");
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
