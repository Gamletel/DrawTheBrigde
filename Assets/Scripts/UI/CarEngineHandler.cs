using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CarEngineHandler : MonoBehaviour
{
    public delegate void EngEnabled();
    public static event EngEnabled engEnabled;

    public GameObject[] _wheels;

    private void OnEnable()
    {
        StartCar.carStart += EnableCarEngine;
    }

    private void OnDisable()
    {
        StartCar.carStart -= EnableCarEngine;
    }

    public void EnableCarEngine()
    {
        engEnabled?.Invoke();
        AudioListener.OnEngineStarted();
        StartCoroutine(EnableEngine());   
    }

    public void DisableCarEngine()
    {
        foreach (GameObject wheel in _wheels)
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            wheel.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            wheel.GetComponent<WheelJoint2D>().useMotor = false;
        }
    }

    private IEnumerator EnableEngine()
    {
        yield return new WaitForSeconds(.5f);
        foreach (GameObject wheel in _wheels)
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            wheel.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            wheel.GetComponent<WheelJoint2D>().useMotor = true;
        }
    }
}
