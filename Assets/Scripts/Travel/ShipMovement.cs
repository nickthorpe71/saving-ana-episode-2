using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    public float movementSpeed = 15f;
    public bool chaseScene = false, enginesDisabled;
    private float turnSpeed = 150f;

    private Transform trans;

    public Transform model;

    private Thrusters thrusters;

    public GameObject explosionPrefab;

    public EndPort endPort;

    [SerializeField] bool edgeLock;
    [SerializeField] float edge = 24.2f;
    [SerializeField] GameObject jerBanta;


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
        if (!edgeLock)
        {
            if (trans.position.x < -edge)
            {
                trans.position = new Vector3(edge, trans.position.y, trans.position.z);
                thrusters.ResetTrails();
            }
            else if (trans.position.x > edge)
            {
                trans.position = new Vector3(-edge, trans.position.y, trans.position.z);
                thrusters.ResetTrails();
            }
        }
        else
        {
            if (trans.position.x < -edge)
            {
                trans.position = new Vector3(-edge, trans.position.y, trans.position.z);
                //thrusters.ResetTrails();
            }
            else if (trans.position.x > edge)
            {
                trans.position = new Vector3(edge, trans.position.y, trans.position.z);
                //thrusters.ResetTrails();
            }
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
        if (!chaseScene)
        {
            trans.position += trans.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }
        else if (chaseScene)
        {
            if (enginesDisabled)
            {
                movementSpeed = jerBanta.GetComponent<ChaseAI>().forwardSpeed;
                if (movementSpeed == 0)
                {
                    endPort.LoadNewLevel("Story");
                }
            }
            trans.position += trans.forward * movementSpeed * Time.deltaTime;
        }
    }

    public void Explode()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        endPort.LoadNewLevel(sceneName);
    }
}
