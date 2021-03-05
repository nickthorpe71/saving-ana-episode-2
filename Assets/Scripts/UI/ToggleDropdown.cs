using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDropdown : MonoBehaviour
{
    public GameObject body;

    public void Toggle()
    {
        if (body.activeSelf)
        {
            body.SetActive(false);
        }
        else
        {
            body.SetActive(true);
        }
    }
}
