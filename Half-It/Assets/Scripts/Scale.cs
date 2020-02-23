using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float weight;

    private void OnTriggerEnter(Collider halfed)
    {
        weight = halfed.GetComponent<SlicableObject>().volume;
    }
}
