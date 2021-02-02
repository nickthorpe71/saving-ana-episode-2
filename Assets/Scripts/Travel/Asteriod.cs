using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    private float scaleOffset = 0.7f;
    private float scaleIncrease = 1;
    private float rotationOffset = 50f;

    private Transform trans;
    private Vector3 randomRotation;

    void Awake()
    {
        trans = transform;
        rotationOffset = Random.Range(2f, 10f);
        scaleIncrease = Random.Range(3f, 20f);
    }

    void Start()
    {
        Vector3 scale = Vector3.one;

        scale.x = Random.Range(scaleIncrease - scaleOffset, scaleIncrease + scaleOffset);
        scale.y = Random.Range(scaleIncrease - scaleOffset, scaleIncrease + scaleOffset);
        scale.z = Random.Range(scaleIncrease - scaleOffset, scaleIncrease + scaleOffset);
        trans.localScale = scale;

        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);

        GetComponent<Rigidbody>().mass = scaleIncrease * 3;
        GetComponent<Rigidbody>().AddForce(Random.Range(-12 - scaleIncrease, 12 + scaleIncrease), Random.Range(0, 12 + scaleIncrease) * -1, 0, ForceMode.Impulse);

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
        }
    }

    void Update()
    {
        trans.Rotate(randomRotation * Time.deltaTime);
    }
}
