using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [HideInInspector] public float movementSpeed = 15f;
    private float turnSpeed = 150f;

    private Transform trans;

    public Transform model;

    private Thrusters thrusters;

    public GameObject explosionPrefab;

    public EndPort endPort;



    void Awake()
    {
        trans = transform;
        thrusters = GetComponent<Thrusters>();
    }

    void Update()
    {
        Thrust();
        Turn();
        CheckThrusters();
        ScreenConstraints();
        
    }

    void ScreenConstraints()
    {
        if(trans.position.x < -24.5f){
            trans.position = new Vector3(24.2f, trans.position.y, trans.position.z);
            thrusters.ResetTrails();
        }
        else if(trans.position.x > 24.5f){
            trans.position = new Vector3(-24.2f, trans.position.y, trans.position.z);
            thrusters.ResetTrails();
        }
    }

    void CheckThrusters()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            thrusters.Accelerate();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            thrusters.Reverse();
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            thrusters.Stop();
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            thrusters.Accelerate();
        }
    }

    void Turn()
    {
        float roll = turnSpeed * Time.deltaTime * Mathf.Abs(trans.position.x / 5) * Input.GetAxis("Horizontal");
        model.Rotate(0, 0, -roll);
        trans.position += trans.right * movementSpeed * 1.5f * Time.deltaTime * Input.GetAxis("Horizontal");
    }

    void Thrust()
    {
        trans.position += trans.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }

    public void Explode()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        endPort.LoadNewLevel(sceneName);
    }
}
