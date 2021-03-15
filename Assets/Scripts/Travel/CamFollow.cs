using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Transform trans;
    public Transform target;
    [SerializeField] float chaseMod;
    [SerializeField] bool chaseScene;

    [SerializeField] float distanceDamp = 2f;
    void Start()
    {
        trans = transform;
    }

    void Update()
    {
        if(target != null)
        {
            if (!chaseScene)
            {
                Vector3 adjustment = new Vector3(trans.position.x, target.position.y + 6, trans.position.z);
                Vector3 curPos = Vector3.Lerp(trans.position, adjustment, distanceDamp * Time.deltaTime);
                trans.position = curPos;
            }
            else
            {
                Vector3 adjustment = new Vector3(trans.position.x, target.position.y + chaseMod, trans.position.z);
                Vector3 curPos = Vector3.Lerp(trans.position, adjustment, distanceDamp * Time.deltaTime);
                trans.position = curPos;
            }
        }
    }
}
