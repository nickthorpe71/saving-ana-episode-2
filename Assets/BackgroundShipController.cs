using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShipController : MonoBehaviour
{
    [SerializeField] float speedMin = 2, speedMax= 8, speed, xMin, xMax, yMin, yMax, yReverseOffset;
    [SerializeField] bool reversed;
    [SerializeField] List<GameObject> activeShips, inactiveShips;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);
        ReversalCheck();
        SetPosition();
    }

    // Update is called once per frameq
    void Update()
    {
        MoveShip();
    }

    private void SetPosition()
    {
        if (reversed)
            transform.position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax) + yReverseOffset, 19);
        else
            transform.position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 19);
    }

    private void ReversalCheck()
    {
        if (Random.Range(0, 10) > 7)
        {
            reversed = true;
            transform.rotation = new Quaternion(-transform.rotation.x, transform.rotation.y,
                -transform.rotation.z, transform.rotation.w);
        }
    }
    private void MoveShip()
    {
        if (!reversed)
            transform.position = new Vector3(transform.position.x, transform.position.y
                + (speed * Time.deltaTime), transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y
                - (speed * Time.deltaTime), transform.position.z);
    }
}
