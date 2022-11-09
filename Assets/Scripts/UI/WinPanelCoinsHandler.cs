using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelCoinsHandler : MonoBehaviour
{
    [SerializeField] private Image[] _coinImages;
    [SerializeField] private Sprite _reachedCoinSprite;
    [SerializeField] private GameObject[] _reachedCoinParticle;
    [SerializeField] private ParticleSystem _allCoinsReachedParticle;
    [SerializeField] private AudioClip _winSound;
    private const int _maxCoinsInLevel = 3;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void EnablePanel()
    {
        gameObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(_winSound);
        StartCoroutine(EnableCoins());
        if (CoinSaver.coinsInLevelAmount == _maxCoinsInLevel)
            _allCoinsReachedParticle.Play();
    }

    private void AddCoin(int coinIndex)
    {
        _reachedCoinParticle[coinIndex].SetActive(true);
        _coinImages[coinIndex].sprite = _reachedCoinSprite;
    }

    private IEnumerator EnableCoins()
    {
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i <= CoinSaver.coinsInLevelAmount - 1; i++)
        {
            yield return new WaitForSeconds(.5f);
            AddCoin(i);
            Debug.Log(i);
        }
    }
}
