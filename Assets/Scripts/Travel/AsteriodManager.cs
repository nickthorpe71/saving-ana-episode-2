using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodManager : MonoBehaviour
{
    public Asteriod asteroidPrefab;
    [SerializeField] private int gridSpacing = 25;
    [SerializeField] private int numberPerRow = 2;
    [SerializeField] private int numberPerCol = 30;

    private Transform trans;
    private float speed = 1.0f;

    void Start()
    {
        PlaceAsteroids();
        trans = transform;
    }

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
