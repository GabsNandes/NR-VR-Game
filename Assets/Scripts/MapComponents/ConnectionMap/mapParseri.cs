using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObjects;

namespace MapParser
{
    public interface IMapParser
    {
        Session ParseMap();
    }
}