using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObjects;
using JsonUtility = UnityEngine.JsonUtility;

namespace MapParser
{
    public class MapParserJSON : IMapParser
    {
        public string jsonData;

        public MapParserJSON(string jsonData)
        {
            this.jsonData = jsonData;
        }

        //  Create a Map object from the JSON string
        private Session CreateFromJSON(string jsonString)
        {

            var data = JsonUtility.FromJson<Session>(jsonString);

            return data;
        }

        public Session ParseMap()
        {
            Debug.Log("Parsing map from JSON");
            return CreateFromJSON(jsonData);
        }
    }
}
