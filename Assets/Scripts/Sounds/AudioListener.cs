using UnityEngine;

public class AudioListener : MonoBehaviour
{
    public delegate void ButtonPressed();
    public static event ButtonPressed _btnPressed;

    public delegate void EngineStarted();
    public static event EngineStarted _engineStarted;

    public static void OnBtnPressed()
    {
        _btnPressed?.Invoke();
    }

    public static void OnEngineStarted()
    {
        _engineStarted?.Invoke();
    }
}
