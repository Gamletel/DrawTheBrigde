using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public const float RESOLUTION = .01f;
    public static bool canDraw = true;
    public static bool isDrawing = false;
    [SerializeField] private Line _linePrefab;
    private Camera _cam;
    private Line _curLine;

    private void Start()
    {
        _cam = Camera.main;
        canDraw = true;
    }

    private void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && canDraw)
        {
            _curLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
            isDrawing = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canDraw = true;
            isDrawing = false;
        }
        if (Input.GetMouseButton(0) && canDraw && isDrawing)
            _curLine.SetPosition(mousePos);
    }

    public void DisableDrawManager()
    {
        GetComponent<DrawManager>().enabled = false;
    }
}