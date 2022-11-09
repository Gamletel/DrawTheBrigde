using UnityEngine;
using Eiko.YaSDK;

public class SelectCar : MonoBehaviour
{
    [SerializeField] private int _carID;
    public void Select()
    {
        if (PlayerPrefs.GetInt($"car{_carID}IsRewarded") == 0)
        {
            YandexSDK.instance.OnRewardedOpen(1);
            YandexSDK.instance.ShowRewarded("1");
            YandexSDK.instance.onRewardedAdReward += Instance_onRewardedAdReward;
        }
        if (PlayerPrefs.GetInt($"car{_carID}IsRewarded") == 1)
            PlayerPrefs.SetInt("carID", _carID);
    }

    private void OnDisable()
    {
        YandexSDK.instance.onRewardedAdReward -= Instance_onRewardedAdReward;
    }

    private void Instance_onRewardedAdReward(string obj)
    {
        PlayerPrefs.SetInt($"car{_carID}IsRewarded", 1);
        PlayerPrefs.SetInt("carID", _carID);
    }
}
