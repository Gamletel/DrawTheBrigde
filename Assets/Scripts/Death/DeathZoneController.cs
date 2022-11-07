using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DeathHandler.OnPlayerDead(collision.gameObject);
            CoinSaver.ResetCoins();
        }
            
    }
}
