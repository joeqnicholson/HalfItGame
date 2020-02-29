using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMover : MonoBehaviour
{
    public GameObject slicedObjects;



    void Update()
    {
        if (MouseSlice.slicedAny)
        {
            GameObject jimbo = slicedObjects.transform.GetChild(0).gameObject;
            GameObject danny = slicedObjects.transform.GetChild(0).gameObject;
        }
    }
}
