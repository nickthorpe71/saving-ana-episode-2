using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodManager : MonoBehaviour
{
    public Asteriod[] asteroidPrefab;
    [SerializeField] private int gridSpacing = 25;
    [SerializeField] private int numberPerRow = 2;
    [SerializeField] private int numberPerCol = 30;

    [SerializeField] bool chaseScene;

    private Transform trans;
    [SerializeField] private float speed = 2.5f;
    IEnumerator moverCoroutine;

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
        Asteriod asteriod = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)],
         new Vector3(transform.position.x + (x * gridSpacing * 1.5f) + AsteroidOffset(),
                     transform.position.y + (y * gridSpacing) + AsteroidOffset(),
                     0),
                     Quaternion.identity, transform);
        if (chaseScene)
        {
            moverCoroutine = AddMoverScript(asteriod);
            StartCoroutine(moverCoroutine);
        }
    }

    private IEnumerator AddMoverScript(Asteriod asteriod)
    {
        yield return new WaitForSeconds(1f);
        AsteroidMover asteroidMover = asteriod.gameObject.AddComponent<AsteroidMover>();
        asteriod.transform.position = new Vector3(asteriod.transform.position.x, asteriod.transform.position.y, 0);
        asteroidMover.leftBound = -(gridSpacing - 3) * numberPerRow;
        asteroidMover.rightBound = (gridSpacing - 3) * numberPerRow;
        asteroidMover.speed = speed;
    }

    float AsteroidOffset()
    {
        return Random.Range(gridSpacing / 2f, -gridSpacing / 2f);
    }
}
