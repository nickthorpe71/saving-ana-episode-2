using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    [HideInInspector] public Rigidbody rb;

    const float G = 0.00006674f;

    public static List<Attractor> Attractors;

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();
        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        // Newton's central equation of universal gravitation
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
