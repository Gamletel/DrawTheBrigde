using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _audioManager;
    private void Awake()
    {
        Instantiate(_audioManager, transform.position, Quaternion.identity);
    }

}
