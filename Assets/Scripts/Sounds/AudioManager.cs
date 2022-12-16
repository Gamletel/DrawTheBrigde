using UnityEngine;
using Eiko.YaSDK;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioSource _backgroundAS;
    [SerializeField] private AudioClip _btnPressedClip;
    [SerializeField] private AudioClip _engineStartedClip;
    private static float _curVolume;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        
        _curVolume = AudioListener.volume;
    }

    private void OnEnable()
    {
        AudioSounds._btnPressed += PlayBtnPressedSound;
        AudioSounds._engineStarted += PlayEngStartedSound;
    }

    private void OnDisable()
    {
        AudioSounds._btnPressed -= PlayBtnPressedSound;
        AudioSounds._engineStarted -= PlayEngStartedSound;
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
}
