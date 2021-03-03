using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShipManager : MonoBehaviour
{
    [SerializeField] List<GameObject> activeShips, inactiveShips;
    [SerializeField] GameObject[] backgroundShips;
    [SerializeField] int maxShipCount, minShipCount, shipCount;

    private void Start()
    {
        shipCount = Random.Range(minShipCount, maxShipCount);

        for (int i = 0; i < shipCount; i++)
        {
            activeShips.Add(GameObject.Instantiate(backgroundShips[Random.Range(0, backgroundShips.Length)]));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
