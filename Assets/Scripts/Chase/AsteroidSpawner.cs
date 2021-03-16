using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    float waveSpawnDistance = 5, distanceTravelled = 0, lastYPosition = 0,
        movementSpeed, movementSpeedIncrement = .0025f, horizontalMovementSpeed,
        horizontalBoundary;
    int speedIncreaseTick = 0;
    [SerializeField] Transform waypointSpawn, leftAsteroidSpawn, rightAsteroidSpawn;
    [SerializeField] GameObject waypoint, asteroidHolder;
    [SerializeField] GameObject[] asteroids;
    [SerializeField] ShipMovement playerShipMovement;
    [SerializeField] ChaseAI chaseAI;
    float xPos, yPos, zPos;
    bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        playerShipMovement.chaseScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        CalculatedDistanceTravelled();
        MoveSpawner();
        if (playerShipMovement.enginesDisabled)
        {

        }
        else
        {
            playerShipMovement.movementSpeed = movementSpeed;
            chaseAI.forwardSpeed = movementSpeed * .99f;
        }
    }

    private void MoveSpawner()
    {
        if (movingRight)
        {
            xPos = transform.position.x + (horizontalMovementSpeed * Time.deltaTime);
            if (xPos > horizontalBoundary)
            {
                movingRight = false;
                xPos = transform.position.x - (horizontalMovementSpeed * Time.deltaTime);
            }
        }
        else if (!movingRight)
        {
            xPos = transform.position.x - (horizontalMovementSpeed * Time.deltaTime);
            if (xPos < -horizontalBoundary)
            {
                movingRight = true;
                xPos = transform.position.x + (horizontalMovementSpeed * Time.deltaTime);
            }
        }
        zPos = transform.position.z;
        yPos = transform.position.y + movementSpeed * Time.deltaTime;
        transform.position = new Vector3(xPos, yPos, zPos);
    }

    private void CalculatedDistanceTravelled()
    {
        distanceTravelled += transform.position.y - lastYPosition;
        lastYPosition = transform.position.y;
        if (distanceTravelled > waveSpawnDistance)
        {
            distanceTravelled = 0;
            SpawnWave();

            //increase speed
            if (speedIncreaseTick >= 10)
            {
                movementSpeed += movementSpeedIncrement;
                speedIncreaseTick = 0;
            }
            else
            {
                speedIncreaseTick++;
            }

        }
    }

    private void SpawnWave()
    {
        Vector3 left = leftAsteroidSpawn.transform.position;
        Vector3 right = rightAsteroidSpawn.transform.position;
        Vector3 waypointVec = waypointSpawn.transform.position;
        GameObject asteroid1 = GameObject.Instantiate(asteroids[Random.Range(0, asteroids.Length)], left, Quaternion.identity);
        GameObject asteroid2 = GameObject.Instantiate(asteroids[Random.Range(0, asteroids.Length)], right, Quaternion.identity);
        GameObject _waypoint = GameObject.Instantiate(waypoint, waypointVec, Quaternion.identity);
        asteroid1.transform.SetParent(asteroidHolder.transform);
        asteroid1.AddComponent<DestroyObject>();
        asteroid2.transform.SetParent(asteroidHolder.transform);
        asteroid2.AddComponent<DestroyObject>();
        _waypoint.AddComponent<DestroyObject>();
        chaseAI.currentWaypoint = _waypoint;
        chaseAI.UpdateMarkers();
    }
}
