using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float weight;
    public static bool hit;
    private void Start()
    {
        hit = false;
    }
    private void Update()
    {
        print(hit);
    }
    private void OnTriggerEnter(Collider halfed)
    {
        weight = halfed.GetComponent<SlicableObject>().volume;
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        hit = true;
    }
}
