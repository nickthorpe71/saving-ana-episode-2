using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusters : MonoBehaviour
{
    public GameObject forwardThruster;
    public GameObject reverseThrusterLeft;
    public GameObject reverseThrusterRight;
    public GameObject trailLeft;
    public GameObject trailRight;

    public void TrailsOn()
    {
        trailLeft.GetComponent<TrailRenderer>().emitting = true;
        trailRight.GetComponent<TrailRenderer>().emitting = true;
    }

    public void TrailsOff()
    {
        trailLeft.GetComponent<TrailRenderer>().emitting = false;
        trailRight.GetComponent<TrailRenderer>().emitting = false;
    }

    public void ResetTrails()
    {
        StopAllCoroutines();
        StartCoroutine(ResetTralsDelay());
    }

    IEnumerator ResetTralsDelay()
    {
        TrailsOff();
        yield return new WaitForSeconds(0.15f);
        TrailsOn();
    }

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
