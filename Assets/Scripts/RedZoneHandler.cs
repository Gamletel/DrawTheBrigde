using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RedZoneHandler : MonoBehaviour
{
    private void OnMouseEnter()
    {
        DrawManager.canDraw = false;
        DrawManager.isDrawing = false;
    }
    private void OnMouseDown()
    {
        DrawManager.canDraw = false;
        DrawManager.isDrawing = false;
    }
    private void OnMouseDrag()
    {
        DrawManager.canDraw = false;

    }
    private void OnMouseExit()
    {
        if (!DrawManager.isDrawing)
        {
            DrawManager.canDraw = true;
            DrawManager.isDrawing = false;
        }
        
    }
}
