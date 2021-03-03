using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    [SerializeField] private float scaleOffset = 0.2f;
    [SerializeField] private float scaleIncrease = 1;
    [SerializeField] private float rotationOffset = 50f;
    [SerializeField] float scaleIncreaseMin = 3f, scaleIncreaseMax = 4.4f, 
        scaleIncreaseBoostMin = 3f, scaleIncreaseBoostMax = 9.8f;
    [SerializeField] Material[] materials;
    [SerializeField] bool usesMaterials;

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

        if (!gameObject.TryGetComponent(out Rigidbody rb))
           rb = gameObject.GetComponentInChildren<Rigidbody>();
        rb.mass = Mathf.Pow(scaleIncrease, 4);
        rb.AddForce(Random.Range(-12 - scaleIncrease, 12 + scaleIncrease), 
            Random.Range(0, 12 + scaleIncrease) * -1, 0, ForceMode.Impulse);
        if (usesMaterials)
        {
            gameObject.GetComponent<MeshRenderer>().material = 
                materials[Random.Range(0, materials.Length)];
        }
    }

    void SetScale()
    {
        int chance = Random.Range(1, 100);

        scaleIncrease = Random.Range(scaleIncreaseMin, scaleIncreaseMax);

        if (chance > 10 && chance < 86)
            scaleIncrease += Random.Range(scaleIncreaseBoostMin, scaleIncreaseBoostMax);

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
            collider.gameObject.GetComponent<ShipMovement>().Explode();
        }
    }

    void Update()
    {
        trans.Rotate(randomRotation * Time.deltaTime);
    }
}
