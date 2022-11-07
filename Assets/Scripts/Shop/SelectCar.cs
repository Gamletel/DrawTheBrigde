using UnityEngine;

public class SelectCar : MonoBehaviour
{
    [SerializeField] private int _carID;
    public void Select()
    {
        PlayerPrefs.SetInt("carID", _carID);
    }
}
