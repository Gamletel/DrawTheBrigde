using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _audioManager;
    private void Start()
    {
        if(PlayerPrefs.GetInt("AMSpawned") == 0)
        {
            Instantiate(_audioManager, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("AMSpawned", 1);
        }
    }

}
