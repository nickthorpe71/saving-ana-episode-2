using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    public float leftBound, rightBound, speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if (gameObject.transform.position.x > rightBound)
        {
            gameObject.transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
        ZLock();
    }

    void ZLock()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    }
}
