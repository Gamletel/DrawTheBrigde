using UnityEngine;
using Eiko.YaSDK;

public class PausePanelController : MonoBehaviour
{

    private void Start()
    {
        YandexSDK.instance.onRewardedAdOpened += SetVisibilityPausePanel;
        YandexSDK.instance.onRewardedAdClosed += SetVisibilityPausePanel;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        YandexSDK.instance.onRewardedAdOpened -= SetVisibilityPausePanel;
        YandexSDK.instance.onRewardedAdClosed -= SetVisibilityPausePanel;
    }

    private void SetVisibilityPausePanel(int obj)
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    private void SetVisibilityPausePanel()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void UnpauseGame(int obj)
    {
        SetVisibilityPausePanel();
        AudioListener.pause = false;
        Time.timeScale = 1;
    }
}
