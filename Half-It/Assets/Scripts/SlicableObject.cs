using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableObject : MonoBehaviour
{
    MeshCollider initialMesh;
    public float volume;
    bool oneTimeBool= false;
    public static bool hitScale = false;


    void Start()
    {
        hitScale = false;
        initialMesh = GetComponent<MeshCollider>();
        Destroy(initialMesh);
        MeshCollider newMesh = gameObject.AddComponent<MeshCollider>() as MeshCollider;
        newMesh.convex = true;
        //newMesh.isTrigger = true;
    }
    private void Update()
    {
        if (MouseSlice.slicedAny && !oneTimeBool)
        {
            float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
            {
                float v321 = p3.x * p2.y * p1.z;
                float v231 = p2.x * p3.y * p1.z;
                float v312 = p3.x * p1.y * p2.z;
                float v132 = p1.x * p3.y * p2.z;
                float v213 = p2.x * p1.y * p3.z;
                float v123 = p1.x * p2.y * p3.z;
                return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
            }
            float VolumeOfMesh(Mesh mesh)
            {
                float volume = 0;
                Vector3[] vertices = mesh.vertices;
                int[] triangles = mesh.triangles;
                for (int i = 0; i < mesh.triangles.Length; i += 3)
                {
                    Vector3 p1 = vertices[triangles[i + 0]];
                    Vector3 p2 = vertices[triangles[i + 1]];
                    Vector3 p3 = vertices[triangles[i + 2]];
                    volume += SignedVolumeOfTriangle(p1, p2, p3);
                }
                return Mathf.Abs(volume);
            }
            Mesh jimbo = GetComponent<MeshFilter>().sharedMesh;
            Debug.Log(VolumeOfMesh(jimbo));
            volume = (VolumeOfMesh(jimbo));
            oneTimeBool = true;
        }



        if (!MouseSlice.slicedAny)
        {
            transform.Translate(-3 * Time.deltaTime, 0, 0, Space.World);
        }
        if (MouseSlice.slicedAny && oneTimeBool)
        {
            initialMesh = GetComponent<MeshCollider>();
            Destroy(initialMesh);
            MeshCollider newMesh = gameObject.AddComponent<MeshCollider>() as MeshCollider;
            Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
            newMesh.convex = true;
            rb.drag = 2;

        }
        //if((MouseSlice.slicedAny) && (transform.position.x < -2.3f || transform.position.x > 2.3f))
        //{
        //    print("yowererightjoe");
        //    Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        //    rb.constraints = RigidbodyConstraints.FreezePositionX;
        //    rb.constraints = RigidbodyConstraints.FreezePositionZ;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        hitScale = true;
    }

}
