using UnityEngine;

public class StartCar : MonoBehaviour
{
    public delegate void CarStart();
    public static event CarStart carStart;

    public void StartEng()
    {
        carStart?.Invoke();
    }
}
