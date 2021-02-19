using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    [SerializeField] float forwardSpeed, sidewaysSpeed, leftBoundary, rightBoundary, 
        cushin, maxRoll = 90f, rotationSpeed = 25f, cushinMod;
    [SerializeField] List<GameObject> asteroids = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        SidewaysMovement();
        ForwardMovement();

        ZLock();

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * forwardSpeed);
    }

    void SidewaysMovement()
    {
        //if (nearestAsteroid != null)
        if (asteroids.Count > 0)
        {
            cushin = (asteroids[0].transform.position.x / 2);
            if (cushin > 0)
            {
                cushin += cushinMod;
            }
            else if (cushin < 0)
            {
                cushin -= cushinMod;
            }
            if (Mathf.Abs(asteroids[0].transform.position.x - transform.position.x) < Mathf.Abs(cushin))
            {
                // is it to the left or right?
                if (asteroids[0].transform.position.x < transform.position.x)
                {
                    //it is to the left
                    //set target x coordinate to the right
                    float x = transform.position.x + cushin;

                    //verify it is within the boundary
                    //if not change target x to inside boundary
                    if (Mathf.Abs(x) > rightBoundary)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed, Space.World);
                        RollLeft();
                    }
                    else
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed, Space.World);
                        RollRight();
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
                        transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed, Space.World);
                        RollRight();
                    }
                    else
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed, Space.World);
                        RollLeft();
                    }
                }
            }
            else
                RollBack();
        }
        else 
        {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteriod")
        {
            asteroids.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (asteroids.Contains(other.gameObject))
        {
            asteroids.Remove(other.gameObject);
        }
    }
}
