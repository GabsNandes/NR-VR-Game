using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public static string mapFile = "default";

    public static string sessionCode;

    public static string sessionId;

    public static readonly Dictionary<string, int> _apiIDdict= new Dictionary<string, int>();
    public static Dictionary<string, int> apiIddict => _apiIDdict;


    public static bool Warn;
    public static bool Concluded;

}
