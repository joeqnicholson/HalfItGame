using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableObject : MonoBehaviour
{
    MeshCollider initialMesh;


    //void Start()
    //{
    //    initialMesh = GetComponent<MeshCollider>();
    //    Destroy(initialMesh);
    //    MeshCollider newMesh = gameObject.AddComponent<MeshCollider>() as MeshCollider;
    //    newMesh.convex = true;
    //    newMesh.isTrigger = true;
    //}
    private void Update()
    {
        if(!MouseSlice.slicedAny)
        {
            transform.Translate(-3 * Time.deltaTime, 0, 0, Space.World);
        }
        if (MouseSlice.slicedAny)
        {
            initialMesh = GetComponent<MeshCollider>();
            Destroy(initialMesh);
            MeshCollider newMesh = gameObject.AddComponent<MeshCollider>() as MeshCollider;
            Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
            newMesh.convex = true;
        }
    }

}
