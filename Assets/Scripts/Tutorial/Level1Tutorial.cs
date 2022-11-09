using UnityEngine;

public class Level1Tutorial : MonoBehaviour
{
    private Animator _animator;
    private bool _firstStep;

    private void Start() => _animator = GetComponent<Animator>();

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !_firstStep)
        {
            _animator.SetInteger("tutorialIndex", 1);
            _firstStep = true;
        }
    }

    public void ExitTutorial()
    {
        _animator.SetInteger("tutorialIndex", 4);
    }
}
