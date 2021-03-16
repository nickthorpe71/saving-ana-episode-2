using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseManager : MonoBehaviour
{
    [SerializeField] GameObject jerFighter;
    [SerializeField] GameObject waypoint;
    [SerializeField] GameObject[] asteroids;
    [SerializeField] float xBound, yBound;
    [SerializeField] float distanceToAsteroid;
    Context context;
    void Awake()
    {
        context = Context.Instance;
        if (context.isChase)
            jerFighter.SetActive(true);
        else
            jerFighter.SetActive(false);
    }
}
