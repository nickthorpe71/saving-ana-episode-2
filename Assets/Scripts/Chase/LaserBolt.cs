using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBolt : MonoBehaviour
{
    public float speed = 5;
    GameObject player;
    // Start is called before the first frame update
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
            player.GetComponent<ShipMovement>().enginesDisabled = true;
            
        }
    }
}
