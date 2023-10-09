using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatPlatfrom : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] wayPoints;
    private int currentPointIndex = 0;
    [SerializeField] private float speed = 1f;
    

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[currentPointIndex].transform.position) < .1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= wayPoints.Length)
            {
                currentPointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentPointIndex].transform.position, speed * Time.deltaTime);
    }
}
