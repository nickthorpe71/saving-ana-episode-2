using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform jerBanta, exitPosition;
    [SerializeField] GameObject engageText;
    bool canFire;

    // Update is called once per frame
    void Update()
    {
        LaserTextActivate();
        if (canFire)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject laserBolt = GameObject.Instantiate(laserPrefab, exitPosition.position, Quaternion.identity);
                laserBolt.GetComponent<LaserBolt>().speed = gameObject.GetComponentInParent<ShipMovement>().movementSpeed + 30;
            }
        }
    }

    private void LaserTextActivate()
    {
        if (jerBanta.position.y - transform.position.y < 20)
        {
            canFire = true;
            engageText.SetActive(true);
        }
    }
}
