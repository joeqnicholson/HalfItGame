using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject pill;
    Vector3 scaleSpot;
    float journeyLength;
    // Movement speed in units per second.
    public float speed = 0.1F;

    // Time when the movement started.
    private float startTime;

    private void Start()
    {
        scaleSpot = new Vector3(0.0f, -13.15f, -15.82f);
        journeyLength = Vector3.Distance(transform.position, scaleSpot);
    }
    void Update()
    {
        
        if (MouseSlice.slicedAny)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(transform.position, scaleSpot, fractionOfJourney * Time.deltaTime * 2);
        }
        
    }
}
