using UnityEngine;

public class Level1Tutorial : MonoBehaviour
{
    private Animator _animator;

    private void Start() => _animator = GetComponent<Animator>();

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _animator.SetInteger("tutorialIndex", 1);
    }

    public void ExitTutorial()
    {
        _animator.SetInteger("tutorialIndex", 4);
    }
}
