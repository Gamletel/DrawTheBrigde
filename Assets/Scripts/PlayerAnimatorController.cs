using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        FinishCounter.finished += Finished;
        CarEngineHandler.engEnabled += Started;
    }

    private void OnDisable()
    {
        FinishCounter.finished -= Finished;
        CarEngineHandler.engEnabled -= Started;
    }

    private void Started()
    {
        _animator.SetTrigger("Started");
    }

    private void Finished()
    {
        _animator.SetTrigger("Finished");
    }
}
