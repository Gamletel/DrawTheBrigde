using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    public delegate void PlayerDeath(GameObject player);
    public static event PlayerDeath playerDeath;

    public static void OnPlayerDead(GameObject player)
    {
        playerDeath?.Invoke(player);
    }
}
