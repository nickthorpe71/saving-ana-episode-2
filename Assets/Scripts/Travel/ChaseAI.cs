using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    [SerializeField] float forwardSpeed, sidewaysSpeed, leftBoundary, rightBoundary, cushin;
    [SerializeField] List<GameObject> asteroids = new List<GameObject>();
    [SerializeField] List<float> waypoints = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SidewaysMovement();
        ForwardMovement();
    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * forwardSpeed);
    }

    void SidewaysMovement()
    {
        if (asteroids.Count > 0)
        {
            waypoints.Clear();
            foreach (GameObject asteroid in asteroids)
            {
                if (Mathf.Abs(asteroid.transform.position.x - transform.position.x) < cushin)
                {
                    // is it to the left or right?
                    if (asteroid.transform.position.x < transform.position.x)
                    {
                        //it is to the left
                        //set target x coordinate to the right
                        float x = transform.position.x + cushin;
                        //verify it is within the boundary
                        //if not change target x to inside boundary
                        if (Mathf.Abs(x) > rightBoundary)
                        {
                            x = asteroid.transform.position.x - cushin;
                            waypoints.Add(x);

                            transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed);

                        }
                        else
                        {
                            waypoints.Add(x);

                            transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed);

                        }
                    }
                    else
                    {
                        //it is to the right (we will assume right if dead center)
                        //set target to the left
                        float x = transform.position.x - cushin;
                        //verify it is within the boundary
                        //if not change target x to inside boundary
                        if (Mathf.Abs(x) < leftBoundary)
                        {
                            x = asteroid.transform.position.x + cushin;
                            waypoints.Add(x);

                            transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed);
                        }
                        else
                        {
                            waypoints.Add(x);

                            transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed);
                        }
                    }
                }
                else
                {
                    waypoints.Add(transform.position.x);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteriod")
        {
            asteroids.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Asteriod")
        {
            asteroids.Remove(other.gameObject);
            waypoints.Remove(waypoints[0]);
        }
    }
}
