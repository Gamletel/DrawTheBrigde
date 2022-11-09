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
        
        _curVolume = _as.volume;
    }

    private void OnEnable()
    {
        AudioListener._btnPressed += PlayBtnPressedSound;
        AudioListener._engineStarted += PlayEngStartedSound;
        YandexSDK.instance.onRewardedAdOpened += Mute;
        YandexSDK.instance.onRewardedAdReward += Unmute;
        YandexSDK.instance.onRewardedAdClosed += Unmute;
    }

    private void OnDisable()
    {
        AudioListener._btnPressed -= PlayBtnPressedSound;
        AudioListener._engineStarted -= PlayEngStartedSound;
        YandexSDK.instance.onRewardedAdOpened -= Mute;
        YandexSDK.instance.onRewardedAdReward -= Unmute;
        YandexSDK.instance.onRewardedAdClosed -= Unmute;
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

    private void Mute(int a)
    {
        _as.volume = 0;
        _backgroundAS.volume = 0;
        Debug.LogWarning("Mute");
    }

    private void Unmute(int a)
    {
        _as.volume = _curVolume;
        _backgroundAS.volume = _curVolume;
        Debug.LogWarning("UnMute");
    }
    private void Unmute(string a)
    {
        _as.volume = _curVolume;
        _backgroundAS.volume = _curVolume;
        Debug.LogWarning("UnMute");
    }
}
