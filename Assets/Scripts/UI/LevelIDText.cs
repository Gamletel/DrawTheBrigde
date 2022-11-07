using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelIDText : MonoBehaviour
{
    private TextMeshProUGUI _idText;
    private void Awake()
    {
        _idText = GetComponent<TextMeshProUGUI>();
        _idText.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
