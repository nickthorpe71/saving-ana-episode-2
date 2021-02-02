﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Transform trans;
    public Transform target;

    private float distanceDamp = 20f;
    void Start()
    {
        trans = transform;
    }

    void Update()
    {
        Vector3 adjsutment = new Vector3(trans.position.x, target.position.y, trans.position.z);
        Vector3 curPos = Vector3.Lerp(trans.position, adjsutment, distanceDamp * Time.deltaTime);
        trans.position = curPos;
    }
}
