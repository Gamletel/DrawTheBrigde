using UnityEngine;
using Eiko.YaSDK;
using UnityEngine.UI;

public class SelectCar : MonoBehaviour
{
    [SerializeField] private GameObject _adImg;
    [SerializeField] private int _id;
    private Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        if (_id == 0)
        {
            PlayerPrefs.SetInt($"car{_id}Rewarded", 1);
        }
    }

    public void Select()
    {
        ShopHandler.OnCarSelected();
        if (PlayerPrefs.GetInt($"car{_id}Rewarded") == 0)
        {
            YandexSDK.instance.ShowRewarded("1");
            YandexSDK.instance.onRewardedAdReward += Instance_onRewardedAdReward;
        }
        if (PlayerPrefs.GetInt($"car{_id}Rewarded") == 1)
            PlayerPrefs.SetInt("carID", _id);
        ShopHandler.OnCarSelected();
    }

    private void OnEnable()
    {
        ShopHandler.carSelected += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        ShopHandler.carSelected -= UpdateText;
        YandexSDK.instance.onRewardedAdReward -= Instance_onRewardedAdReward;
    }

    private void Instance_onRewardedAdReward(string obj)
    {
        PlayerPrefs.SetInt($"car{_id}Rewarded", 1);
        PlayerPrefs.SetInt("carID", _id);
        ShopHandler.OnCarSelected();
    }

    private void UpdateText()
    {
        switch (PlayerPrefs.GetInt($"car{_id}Rewarded"))
        {
            case 0:
                _text.text = "Buy";
                break;
            case 1:
                _text.text = "Select";
                _adImg.SetActive(false);
                break;
        }
        switch (PlayerPrefs.GetInt("carID") == _id)
        {
            case true:
                _text.text = "Used";
                break;
        }
    }
}
