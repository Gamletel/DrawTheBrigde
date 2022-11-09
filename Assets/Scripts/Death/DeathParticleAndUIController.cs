using System.Threading.Tasks;
using UnityEngine;

public class DeathParticleAndUIController : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private ParticleSystem _deathParticle;

    private void OnEnable()
    {
        DeathHandler.playerDeath += PlayerDead;
    }

    private void OnDisable()
    {
        DeathHandler.playerDeath -= PlayerDead;
    }

    private void PlayerDead(GameObject player)
    {
        _losePanel.SetActive(true);
        Instantiate(_deathParticle, player.transform.position, Quaternion.identity);
        player.GetComponent<Collider2D>().enabled = false;
        Destroy(player);
    }
}
