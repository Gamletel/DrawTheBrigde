using UnityEngine;
using Eiko.YaSDK;

public class TipController : MonoBehaviour
{
    [SerializeField] private GameObject _tipLine;
    public void EnableTipLine()
    {
        YandexSDK.instance.ShowRewarded("3");
        YandexSDK.instance.onRewardedAdReward += Instance_onRewardedAdReward;

    }

    private void OnDisable()
    {
        YandexSDK.instance.onRewardedAdReward -= Instance_onRewardedAdReward;
    }

    private void Instance_onRewardedAdReward(string obj)
    {
        if (obj == "3")
        {
            gameObject.SetActive(false);
            _tipLine.SetActive(true);
        }
    }
}
