using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBolt : MonoBehaviour
{
    public float speed = 5;
    GameObject player;
    public GameObject explosionPrefab;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("DestroyObject");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    IEnumerator DestroyObject()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JerBanta")
        {
            other.gameObject.GetComponent<ChaseAI>().enginesDisabled = true;
            other.gameObject.GetComponent<ChaseAI>().SmokeOn();
            player.GetComponent<ShipMovement>().enginesDisabled = true;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
