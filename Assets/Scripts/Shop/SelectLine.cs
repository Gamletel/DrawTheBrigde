using UnityEngine;
using Eiko.YaSDK;

public class SelectLine : MonoBehaviour
{
    [SerializeField] private int _id;

    public void SetLine()
    {
        if (PlayerPrefs.GetInt($"line{_id}Rewarded") == 0)
        {
            YandexSDK.instance.OnRewardedOpen(1);
            YandexSDK.instance.ShowRewarded("1");
            YandexSDK.instance.onRewardedAdReward += Instance_onRewardedAdReward;
        }
        if (PlayerPrefs.GetInt($"line{_id}Rewarded") == 1)
            PlayerPrefs.SetInt("line", _id);
    }

    private void OnDisable()
    {
        YandexSDK.instance.onRewardedAdReward -= Instance_onRewardedAdReward;
    }

    private void Instance_onRewardedAdReward(string obj)
    {
        PlayerPrefs.SetInt($"line{_id}Rewarded", 1);
        PlayerPrefs.SetInt("line", _id);
    }
}
