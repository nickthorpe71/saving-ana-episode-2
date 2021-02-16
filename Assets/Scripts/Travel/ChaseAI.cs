using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    [SerializeField] float forwardSpeed, leftBoundary, rightBoundary;
    [SerializeField] List<GameObject> asteroids;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ForwardMovement();
        SidewaysMovement();
    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * forwardSpeed);
    }

    void SidewaysMovement()
    {
        if (asteroids.Count > 0)
        {
            List<bool> avoid = new List<bool>();
            foreach (GameObject asteroid in asteroids)
            {
                if (Mathf.Abs(asteroid.transform.position.x - transform.position.x) < 1.5f)
                {
                    avoid.Add(true);
                }
                else
                {
                    avoid.Add(false);
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
        }
    }


}
