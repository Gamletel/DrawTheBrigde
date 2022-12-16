using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    public delegate void LineSelected();
    public static event LineSelected lineSelected;

    public delegate void CarSelected();
    public static event CarSelected carSelected;

    public static void OnLineSelected()
    {
        lineSelected?.Invoke();
    }

    public static void OnCarSelected()
    {
        carSelected?.Invoke();
    }
}
