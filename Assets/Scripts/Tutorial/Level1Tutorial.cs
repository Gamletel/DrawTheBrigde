using System.Collections;
using UnityEngine;

public class Level1Tutorial : MonoBehaviour
{
    private static Animator _animator;
    public static bool firstStepEnter;

    private void Awake() => _animator = GetComponent<Animator>();

    public static void EndFirstStepTutorial()
    {
        _animator.SetInteger("tutorialIndex", 1);
    }

    public void ExitTutorial()
    {
        _animator.SetInteger("tutorialIndex", 4);
    }
}
