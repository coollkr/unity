/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this a floatPlatfrom.
 *
 * this script will give you a platfrom that is movable between two points.
 *
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatPlatfrom : MonoBehaviour
{
    

    [SerializeField] private GameObject[] wayPoints;
    private int currentPointIndex = 0;
    [SerializeField] private float speed = 1f;
    

    
    void Update()
    {
        //store two points in an array. 
        if (Vector3.Distance(transform.position, wayPoints[currentPointIndex].transform.position) < .1f)
        {
            currentPointIndex++;
            //here maxIndex is always 1 because there is only two points.
            if (currentPointIndex >= wayPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
        //movement for the platform.
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentPointIndex].transform.position, speed * Time.deltaTime);
    }
}
