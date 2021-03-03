using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOverlay : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x * .5f, player.transform.position.y * .5f, 0);
    }
}
