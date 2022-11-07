using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLine : MonoBehaviour
{
    [SerializeField] private int _id;

    public void SetLine()
    {
        PlayerPrefs.SetInt("Line", _id);
    }
}
