using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShipManager : MonoBehaviour
{
    [SerializeField] Transform backgroundObject;
    [SerializeField] GameObject[] backgroundShips;
    [SerializeField] int maxShipCount, minShipCount, shipCount;

    private void Start()
    {
        shipCount = Random.Range(minShipCount, maxShipCount);

        for (int i = 0; i < shipCount; i++)
        {
            GameObject ship = GameObject.Instantiate(
                backgroundShips[Random.Range(0, backgroundShips.Length)], backgroundObject);
        }
    }
}
