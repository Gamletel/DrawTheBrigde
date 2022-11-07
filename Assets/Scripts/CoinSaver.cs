using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinSaver : MonoBehaviour
{
    public static int coinsInLevelAmount { get; private set; }
    private static string[] _coinNames = new string[3];

    private void Awake()
    {
        Debug.Log("Звезд подобрано:" + PlayerPrefs.GetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coinsAmount"));
        if (PlayerPrefs.GetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coinsAmount") == 0)
            ResetCoins();
        else
            coinsInLevelAmount = PlayerPrefs.GetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coinsAmount");
    }

    public static void ResetCoins()
    {
        coinsInLevelAmount = 0;
    }

    public static void AddCoin(string coinName)
    {
        if (coinsInLevelAmount < _coinNames.Length)
        {
            _coinNames[coinsInLevelAmount] = coinName;
            coinsInLevelAmount++;
        }

    }

    public static void SaveCoins()
    {
        PlayerPrefs.SetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coinsAmount", coinsInLevelAmount);
        CoinBank.AddCoin(coinsInLevelAmount);
        Debug.Log($"Звезда сохранена! Общее количество: {PlayerPrefs.GetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coinsAmount")}");

        foreach (var coinName in _coinNames)
        {
            PlayerPrefs.SetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coin{coinName}", 1);//Сохраняем в PlayerPrefs то, что она уже подобрана
            Debug.LogWarning($"Звезда {coinName} сохранена!");
        }
    }
}
