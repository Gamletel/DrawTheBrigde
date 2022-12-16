using UnityEngine;
using Eiko.YaSDK;
using UnityEngine.UI;

public class SelectLine : MonoBehaviour
{
    [SerializeField] private GameObject _adImg;
    [SerializeField] private int _id;
    private Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        if (_id == 0)
        {
            PlayerPrefs.SetInt($"Line{_id}Rewarded", 1);
        }
    }

    public void SetLine()
    {
        ShopHandler.OnLineSelected();
        if (PlayerPrefs.GetInt($"Line{_id}Rewarded") == 0)
        {
            YandexSDK.instance.ShowRewarded("1");
            YandexSDK.instance.onRewardedAdReward += Instance_onRewardedAdReward;
        }
        if (PlayerPrefs.GetInt($"Line{_id}Rewarded") == 1)
            PlayerPrefs.SetInt("Line", _id);

        ShopHandler.OnLineSelected();
    }

    private void OnEnable()
    {
        ShopHandler.lineSelected += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        YandexSDK.instance.onRewardedAdReward -= Instance_onRewardedAdReward;
        ShopHandler.lineSelected -= UpdateText;
    }

    private void Instance_onRewardedAdReward(string obj)
    {
        PlayerPrefs.SetInt($"Line{_id}Rewarded", 1);
        PlayerPrefs.SetInt("Line", _id);
        ShopHandler.OnLineSelected();
    }

    private void UpdateText()
    {
        switch (PlayerPrefs.GetInt($"Line{_id}Rewarded"))
        {
            case 0:
                _text.text = "Buy";
                break;
            case 1:
                _text.text = "Select";
                _adImg.SetActive(false);
                break;
        }
        switch (PlayerPrefs.GetInt("Line") == _id)
        {
            case true:
                _text.text = "Used";
                break;
        }
    }
}
