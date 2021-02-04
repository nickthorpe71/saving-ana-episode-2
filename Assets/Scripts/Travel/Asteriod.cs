using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    private float scaleOffset = 0.2f;
    private float scaleIncrease = 1;
    private float rotationOffset = 50f;

    private Transform trans;
    private Vector3 randomRotation;

    void Awake()
    {
        trans = transform;
        rotationOffset = Random.Range(2f, 10f);
    }

    void Start()
    {
        SetScale();

        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);

        GetComponent<Rigidbody>().mass = Mathf.Pow(scaleIncrease, 4);
        GetComponent<Rigidbody>().AddForce(Random.Range(-12 - scaleIncrease, 12 + scaleIncrease), Random.Range(0, 12 + scaleIncrease) * -1, 0, ForceMode.Impulse);

    }

    void SetScale()
    {
        int chance = Random.Range(1, 100);

        scaleIncrease = Random.Range(3f, 4.4f);

        if (chance > 10 && chance < 86)
            scaleIncrease += Random.Range(3f, 9.8f);

        else if (chance > 85)
            scaleIncrease *= scaleIncrease;
        
        Vector3 scale = Vector3.one;

        scale.x = Random.Range(scaleIncrease - scaleOffset, scaleIncrease + scaleOffset);
        scale.y = Random.Range(scaleIncrease - scaleOffset, scaleIncrease + scaleOffset);
        scale.z = Random.Range(scaleIncrease - scaleOffset, scaleIncrease + scaleOffset);
        trans.localScale = scale;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Asteroid")
        {
            Destroy(collider.gameObject);
        }
    }

    void Update()
    {
        trans.Rotate(randomRotation * Time.deltaTime);
    }
}
