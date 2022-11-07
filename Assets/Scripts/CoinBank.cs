using UnityEngine;

public class CoinBank : MonoBehaviour
{

    /// <summary>
    /// Добавляем звезды в общий банк
    /// </summary>
    /// <param name="coinsInLevelAmount">Количество подобранных монет</param>
    public static void AddCoin(int coinsInLevelAmount)
    {
        PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") + coinsInLevelAmount);
        Debug.Log("Звезд в банке:" + PlayerPrefs.GetInt("CoinsAmount"));
    }
}
