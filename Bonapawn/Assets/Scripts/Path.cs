using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path 
{
    private Vector3 _location;

    public Path(Vector3 location)
    {
        _location = location;
    }

    public Vector3 Location 
    { 
        get 
        { 
            return _location; 
        } 
    }
}
