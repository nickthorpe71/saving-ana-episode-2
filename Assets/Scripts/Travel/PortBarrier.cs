﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortBarrier : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<ShipMovement>().Explode();
        }
    }
}
