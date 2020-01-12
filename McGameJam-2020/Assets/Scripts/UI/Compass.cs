﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera minimapCamera;
    public GameObject terrain;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currdir = Vector3.Project(minimapCamera.transform.forward, Vector3.up);
        float angle = Vector3.Angle(terrain.transform.forward, minimapCamera.transform.up);
        Vector3 cross = Vector3.Cross(terrain.transform.forward, minimapCamera.transform.up);
        if (cross.y < 0f) angle = -angle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}