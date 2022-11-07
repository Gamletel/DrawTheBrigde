using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _cars;
    private void Awake()
    {
        foreach (var car in _cars)
        {
            car.SetActive(false);
        }
        Spawn();
    }

    private void Spawn()
    {
        if (PlayerPrefs.GetInt("carID") == 0)
        {
            _cars[0].SetActive(true);
            return;
        }
        _cars[PlayerPrefs.GetInt("carID")].SetActive(true);
    }
}
