using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyIt());
    }

    // Update is called once per frame
    IEnumerator DestroyIt()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
