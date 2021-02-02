using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float movementSpeed = 20f;
    private float turnSpeed = 150f;

    private Transform trans;

    public Transform model;

    private Thrusters thrusters;

    void Awake()
    {
        trans = transform;
        thrusters = GetComponent<Thrusters>();
    }

    void Update()
    {
        Thrust();
        Turn();
        CheckThrusters();
    }

    void CheckThrusters()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            thrusters.Accelerate();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            thrusters.Reverse();
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            thrusters.Stop();
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            thrusters.Accelerate();
        }
    }

    void Turn()
    {
        float roll = turnSpeed * Time.deltaTime * Mathf.Abs(trans.position.x / 5) * Input.GetAxis("Horizontal");
        model.Rotate(0, 0, -roll);
        trans.position += trans.right * movementSpeed * 1.25f * Time.deltaTime * Input.GetAxis("Horizontal");
    }

    void Thrust()
    {
        trans.position += trans.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }
}
