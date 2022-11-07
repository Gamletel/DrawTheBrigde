using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinHandler : MonoBehaviour
{
    [SerializeField] private GameObject _coinPoofParticle;
    [SerializeField] private Sprite _reachedCoinSprite;

    private void Start()
    {
        if (PlayerPrefs.GetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coin{gameObject.name}") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = _reachedCoinSprite;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && PlayerPrefs.GetInt($"Lvl{SceneManager.GetActiveScene().buildIndex}coin{gameObject.name}") == 0)//Если игрок раньше не подбирал звезду
            AddCoinToSaver();
    }

    private void AddCoinToSaver()
    {
        CoinSaver.AddCoin(gameObject.name);//Добавляем в метод, который добавляет звезды
        Instantiate(_coinPoofParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);//Спавним партикл подобранной звезды
        Destroy(gameObject);
    }


}
