using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public float forwardSpeed, sidewaysSpeed;
    public GameObject currentWaypoint;
    [SerializeField]
    float leftBoundary, rightBoundary,
        cushin, maxRoll = 90f, rotationSpeed = 25f, cushinMod;
    [SerializeField] List<GameObject> asteroids = new List<GameObject>();
    Transform startMarker, endMarker;
    float startTime, journeyLength;

    // Update is called once per frame
    void Update()
    {
        ForwardMovement();
        SidewaysMovement();
        ZLock();
    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * forwardSpeed);
    }
    void SidewaysMovement()
    {
        if (currentWaypoint != null)
        {
            float distanceCovered = (Time.time - startTime) * sidewaysSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
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
        startMarker = transform;
        endMarker = currentWaypoint.transform;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        startTime = Time.time;
    }
}
