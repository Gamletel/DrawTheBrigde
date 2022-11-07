using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private GameObject[] _cursors;
    private GameObject _cursorParticle;

    private void Awake()
    {
        _cursorParticle = _cursors[PlayerPrefs.GetInt("Line")];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(_cursorParticle, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,5f), Quaternion.identity);
    }
}
