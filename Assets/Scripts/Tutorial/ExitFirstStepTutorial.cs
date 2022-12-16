using UnityEngine;

public class ExitFirstStepTutorial : MonoBehaviour
{
    private void OnMouseEnter()
    {
        if(Level1Tutorial.firstStepEnter)
        {
            Level1Tutorial.EndFirstStepTutorial();
            Debug.Log("Туториал закончен");
        }
    }
}
