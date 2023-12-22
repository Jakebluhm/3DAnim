using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    public static GameObject LastCollidedPlane { get; private set; }
    public float speedIncreaseFactor = 1.0f; // Define how much speed increases each collision
    private AudioSource audioSource;
    public bool playSound = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("SphereCollisionHandler - AudioSource component not found!");
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            PlaySound();

            LastCollidedPlane = collision.gameObject;

            // Increase speed but manage maximum velocity
            ManageVelocity(collision);
        }
    }
    public void PlaySound()
    {
        // Play the sound
        if (audioSource != null && audioSource.clip != null && playSound)
        {
            audioSource.Play();
        }
    }
    private void ManageVelocity(Collision collision)
    {
        //Rigidbody rb = GetComponent<Rigidbody>();

        //// Calculate the new velocity. Reflect the velocity based on the collision normal
        //Vector3 newVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
         

        //// Update the Rigidbody's velocity
        //rb.velocity = newVelocity;
        //rb.velocity *= speedIncreaseFactor;

        // Cap the velocity to avoid extreme speeds that break the simulation
        //float maxVelocity = 5000; // Set this to the highest velocity you want to allow
        //if (rb.velocity.magnitude > maxVelocity)
        //{
        //    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        //}
    }


    // Method to reset the last collided plane
    public static void ResetLastCollidedPlane()
    { 
        LastCollidedPlane = null;
    }
}
