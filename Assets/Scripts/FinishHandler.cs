using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finishParticle;
    [SerializeField] private AudioClip _finishSound;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _finishParticle.Play();
            col.gameObject.GetComponent<CarEngineHandler>().DisableCarEngine();
            col.gameObject.GetComponent<Collider2D>().enabled = false;
            FinishCounter.OnFinished();
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(_finishSound);
        }
    }
}
