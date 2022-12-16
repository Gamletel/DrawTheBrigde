using UnityEngine;

public class EnterFirstStepTutorial : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Level1Tutorial.firstStepEnter = true;
            Debug.Log("Начат туториал");
        }
    }
}
