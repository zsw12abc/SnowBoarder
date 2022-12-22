using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] AudioClip crashSFX;
    bool crashed = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") && !crashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashParticles.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke(nameof(ReloadScene), loadDelay);
            crashed = true;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}