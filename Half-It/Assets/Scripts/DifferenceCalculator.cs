using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferenceCalculator : MonoBehaviour
{
    public GameObject leftScale;
    public GameObject rightScale;
    Vector3 nextPosRight;
    Vector3 nextPosLeft;
    int counter = 0;

    float left;
    float right;
    float initialPosition;

    void Start()
    {

        initialPosition = leftScale.transform.position.y;

    }
    private void Update()
    {

        left = leftScale.GetComponent<Scale>().weight;
        right = rightScale.GetComponent<Scale>().weight;


        float mult = 100 / (right + left);

        float multR = mult * right;
        float multL = mult * left;
        float diff = multR - multL;
        float diffMove = Mathf.Abs(diff) / 30;
        float total = 100 - Mathf.Abs(diff);

        string finalScore = total.ToString("0");
        print(finalScore);

        if (left > right)
        {
            nextPosRight = new Vector3(rightScale.transform.position.x, rightScale.transform.position.y + diffMove, rightScale.transform.position.z);
            nextPosLeft = new Vector3(leftScale.transform.position.x, leftScale.transform.position.y - diffMove, leftScale.transform.position.z);
        }

        if (right > left)
        {
            nextPosRight = new Vector3(rightScale.transform.position.x, rightScale.transform.position.y - diffMove, rightScale.transform.position.z);
            nextPosLeft = new Vector3(leftScale.transform.position.x, leftScale.transform.position.y + diffMove, leftScale.transform.position.z);
        }

        if (Scale.hit == true)
        {
            if (left > right || right > left)
            {
                if (left > right)
                {
                    print("okay");
                    print(diffMove);

                    if (leftScale.transform.position.y > (initialPosition - diffMove))
                    {
                        leftScale.transform.position = Vector3.Lerp(leftScale.transform.position, nextPosLeft, 1.0f * Time.deltaTime);
                        rightScale.transform.position = Vector3.Lerp(rightScale.transform.position, nextPosRight, 1.0f * Time.deltaTime);
                    }

                }
                if (right > left)
                {
                    if (rightScale.transform.position.y > (initialPosition - diffMove))
                    {
                        leftScale.transform.position = Vector3.Lerp(leftScale.transform.position, nextPosLeft, 1.0f * Time.deltaTime);
                        rightScale.transform.position = Vector3.Lerp(rightScale.transform.position, nextPosRight, 1.0f * Time.deltaTime);
                    }

                }

            }
        }
        

            

    }
}
