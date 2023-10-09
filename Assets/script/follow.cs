using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform targetObject;

    public Vector3 camerOffset;

    private void Awake()
    {
        targetObject = GameObject.Find("Lerpz").transform;
    }

    void Start()
    {
        camerOffset = transform.position - targetObject.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targetObject != null)
        {
            Vector3 newPosition = targetObject.transform.position + camerOffset;
            transform.position = newPosition;
        }
        
    }
}
