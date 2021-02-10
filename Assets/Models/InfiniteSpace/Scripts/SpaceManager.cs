using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollDirection { LeftToRight, RightToLeft, DownToUp, UpToDown };

public class SpaceManager : MonoBehaviour
{
    //Set the direction that the screen or the camera is moving
    public ScrollDirection scrollDirection = ScrollDirection.LeftToRight;
    ScrollDirection direction;

    public static SpaceManager instance = null;

    public GameObject jerBanta;
    public GameObject endPort;

    void Start()
    {
        direction = scrollDirection;
        instance = this;

        if(Context.Instance != null)
            if(Context.Instance.isChase)
            {
                endPort.SetActive(false);
                jerBanta.SetActive(true);
            }
    }

    void Update()
    {
        //Prevent that the variable could be changed in execution mode (removing this could cause bugs)
        if (direction != scrollDirection)
        {
            scrollDirection = direction;
        }
    }
}
