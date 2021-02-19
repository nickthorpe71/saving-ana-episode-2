using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject[] followObjects;
    [SerializeField] GameObject followObject;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (followObjects.Length > 0)
        {
            followObject = followObjects[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(followObject.transform.position.x, followObject.transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchFollow();
        }
    }

    void SwitchFollow()
    {
        index++;
        if (index >= followObjects.Length)
            index = 0;

        followObject = followObjects[index];
    }
}
