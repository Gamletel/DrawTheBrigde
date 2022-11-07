using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _btnPressedClip;
    [SerializeField] private AudioClip _engineStartedClip;

    private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        AudioListener._btnPressed += PlayBtnPressedSound;
        AudioListener._engineStarted += PlayEngStartedSound;

    }

    public void PlayBtnPressedSound()
    {
        _as.PlayOneShot(_btnPressedClip);
        Debug.Log("Кнопка нажата!");
    }

    public void PlayEngStartedSound()
    {
        _as.PlayOneShot(_engineStartedClip);
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("AMSpawned", 0);
    }
}
