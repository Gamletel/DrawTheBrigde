using UnityEngine;
using Eiko.YaSDK;

public class ShowPrikol : MonoBehaviour
{
    public void ShowInterstitial()
    {
        YandexSDK.instance.ShowInterstitial();
    }

    public void ShowRewarded()
    {
        YandexSDK.instance.ShowRewarded("1");
    }
}
