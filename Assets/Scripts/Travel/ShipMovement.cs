using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float movementSpeed = 25f;
    private float turnSpeed = 150f;

    private Transform trans;

    public Transform model;

    void Awake()
    {
        trans = transform;
    }

    void Update()
    {
        Thrust();
        Turn();
    }

    void Turn()
    {
        float roll = turnSpeed * Time.deltaTime * Mathf.Abs(trans.position.x / 2) * Input.GetAxis("Horizontal");
        model.Rotate(0, 0, -roll);
        trans.position += trans.right * movementSpeed * 1.25f * Time.deltaTime * Input.GetAxis("Horizontal");
    }

    void Thrust()
    {
        trans.position += trans.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }
}
