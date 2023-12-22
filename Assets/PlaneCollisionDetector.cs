using UnityEngine;

public class PlaneCollisionDetector : MonoBehaviour
{
    public bool HasCollided { get; private set; }

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            PlaySound();
            HasCollided = true;
        }
    }

    public void PlaySound()
    {
        // Play the sound
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    public void ResetCollision()
    {
        HasCollided = false;
    }
}
