using UnityEngine;
using UnityEngine.UI;

public class ReachedCoinsHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private Sprite _reachedStar;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt($"Lvl{gameObject.name}coinsAmount") == 0)
            return;
        switch (PlayerPrefs.GetInt($"Lvl{gameObject.name}coinsAmount"))
        {
            case 1:
                _stars[0].GetComponent<Image>().sprite = _reachedStar;
                break;
            case 2:
                _stars[0].GetComponent<Image>().sprite = _reachedStar;
                _stars[1].GetComponent<Image>().sprite = _reachedStar;
                break;
            case 3:
                foreach (var star in _stars)
                {
                    star.GetComponent<Image>().sprite = _reachedStar;
                }
                break;
        }
    }
}
