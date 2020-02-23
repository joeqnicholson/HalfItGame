using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrapDoor : MonoBehaviour
{
    float z;
    void Update()
    {
        if (MouseSlice.slicedAny)
        {
            if (z < 70)
            {
                z += Time.deltaTime * 40;
                transform.rotation = Quaternion.Euler(0, 0, z);
            }
        }
    }
}


