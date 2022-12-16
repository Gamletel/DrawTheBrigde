using UnityEngine;
using UnityEngine.SceneManagement;
using Eiko.YaSDK;

public class SceneHandler : MonoBehaviour
{
    public void RestartLevel()
    {
        YandexSDK.instance.ShowInterstitial();
        FinishCounter.ResetFinishes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void LoadNextLevel()
    {
        YandexSDK.instance.ShowInterstitial();
        FinishCounter.ResetFinishes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadStartScene()
    {
        YandexSDK.instance.ShowInterstitial();
        SceneManager.LoadScene(0);
    }

    public void SkipLevel()
    {
        YandexSDK.instance.ShowRewarded("2");
        YandexSDK.instance.onRewardedAdReward += Instance_onRewardedAdReward;
    }

    private void OnDisable()
    {
        YandexSDK.instance.onRewardedAdReward -= Instance_onRewardedAdReward;
    }

    private void Instance_onRewardedAdReward(string obj)
    {
        if (obj == "2")
        {
            FinishCounter.ResetFinishes();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
