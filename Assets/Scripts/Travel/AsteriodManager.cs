using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodManager : MonoBehaviour
{
    public Asteriod asteroidPrefab;
    private int gridSpacing = 25;
    private int numberPerRow = 2;
    private int numberPerCol = 30;

    private Transform trans;
    private float speed = 1.0f;

    void Start()
    {
        PlaceAsteroids();
        trans = transform;
    }

    // void Update()
    // {
    //     // trans.position += -trans.forward * (speed + Input.GetAxis("Vertical")) * Time.deltaTime;
    // }
    void PlaceAsteroids()
    {
        for (int x = 0; x < numberPerRow; x++)
        {
            for (int y = 0; y < numberPerCol; y++)
            {
                InstantiateAsteriod(x, y, 0);
            }
        }
    }

    void InstantiateAsteriod(int x, int y, int z)
    {
        Instantiate(asteroidPrefab,
         new Vector3(transform.position.x + (x * gridSpacing * 1.5f) + AsteroidOffset(),
                     transform.position.y + (y * gridSpacing) + AsteroidOffset(),
                     0),
                     Quaternion.identity, transform);
    }

    float AsteroidOffset()
    {
        return Random.Range(gridSpacing / 2f, -gridSpacing / 2f);
    }
}
