using UnityEngine;
using Eiko.YaSDK;

public class DeathHandler : MonoBehaviour
{
    public delegate void PlayerDeath(GameObject player);
    public static event PlayerDeath playerDeath;

    public static void OnPlayerDead(GameObject player)
    {
        YandexSDK.instance.ShowInterstitial();
        playerDeath?.Invoke(player);
    }
}
