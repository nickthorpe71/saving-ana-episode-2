using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusters : MonoBehaviour
{
    public GameObject forwardThruster;
    public GameObject reverseThrusterLeft;
    public GameObject reverseThrusterRight;


    public void Accelerate()
    {
        forwardThruster.SetActive(true);
    }

    public void Reverse()
    {
        reverseThrusterLeft.SetActive(true);
        reverseThrusterRight.SetActive(true);
    }

    public void Stop()
    {
        forwardThruster.SetActive(false);
        reverseThrusterLeft.SetActive(false);
        reverseThrusterRight.SetActive(false);
    }
}
