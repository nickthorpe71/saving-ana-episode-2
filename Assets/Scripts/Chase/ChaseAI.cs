using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public float forwardSpeed, sidewaysSpeed;
    public GameObject currentWaypoint;
    public GameObject smokeEffect;
    public bool enginesDisabled;
    [SerializeField]
    float leftBoundary, rightBoundary,
        cushin, maxRoll = 90f, rotationSpeed = 25f, cushinMod;
    Transform endMarker;
    // Update is called once per frame
    void Update()
    {
        ForwardMovement();
        SidewaysMovement();
        ZLock();
    }

    void ForwardMovement()
    {
        if (enginesDisabled)
        {
            forwardSpeed -= 20 * Time.deltaTime;
            if (forwardSpeed <= 0)
            {
                forwardSpeed = 0;
            }
        }
        transform.Translate(Vector3.up * Time.deltaTime * forwardSpeed);
    }
    void SidewaysMovement()
    {
        if (currentWaypoint != null)
        {
            if (enginesDisabled)
            {
                sidewaysSpeed = 0;
            }
            if (endMarker.position.x > transform.position.x)
            {
                transform.Translate(Vector3.right * sidewaysSpeed * Time.deltaTime, Space.World);
                RollRight();
            }
            else if (endMarker.position.x < transform.position.x)
            {
                transform.Translate(Vector3.left * sidewaysSpeed * Time.deltaTime, Space.World);
                RollLeft();
            }
            else
                RollBack();
        }
    }

    void ZLock()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    }
    void RollRight()
    {
        var step = rotationSpeed * Time.deltaTime;
        Quaternion roll = Quaternion.Euler(0, -maxRoll, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, roll, step);
    }

    void RollLeft()
    {
        var step = rotationSpeed * Time.deltaTime;
        Quaternion roll = Quaternion.Euler(0, maxRoll, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, roll, step);
    }

    void RollBack()
    {
        var step = rotationSpeed * Time.deltaTime;
        Quaternion roll = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, roll, step);
    }

    public void UpdateMarkers()
    {
        endMarker = currentWaypoint.transform;
    }

    public void SmokeOn()
    {
        smokeEffect.SetActive(true);
    }
}
