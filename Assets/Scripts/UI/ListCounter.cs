using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListCounter : MonoBehaviour
{
    private int max;
    private int current;
    public TMP_Text text;

    void Start()
    {
        max = 3;
        current = 0;
        UpdateText();
    }

    public void SetMax(int _max)
    {
        max = _max;
    }

    public void SetCurrent(int _current)
    {
        current = _current;
    }

    public void UpdateCount(int newValue)
    {
        SetCurrent(newValue);
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = current.ToString() + "/" + max.ToString();
    }
}
