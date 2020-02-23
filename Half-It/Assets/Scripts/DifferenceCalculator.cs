using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferenceCalculator : MonoBehaviour
{
    public GameObject leftScale;
    public GameObject rightScale;

    float left;
    float right;

    void Start()
    {
        
    }
    private void Update()
    {
        left = leftScale.GetComponent<Scale>().weight;
        right = rightScale.GetComponent<Scale>().weight;

        float mult = 100 / (right + left);

        float multR = mult * right;
        float multL = mult * left;
        float diff = multR - multL;
        float total = 100 - Mathf.Abs(diff);
        string finalScore = total.ToString("0");
        print(finalScore);
    }
}
