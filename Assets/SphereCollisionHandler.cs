using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    public static GameObject LastCollidedPlane { get; private set; }
    private float speedIncreaseFactor = 1.008f; // Define how much speed increases each collision


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            LastCollidedPlane = collision.gameObject;

            // Increase speed but manage maximum velocity
            ManageVelocity();
        }
    }

    private void ManageVelocity()
    {
        // Increase the speed of the sphere
        Rigidbody rb = GetComponent<Rigidbody>();
        // Increase velocity
        rb.velocity *= speedIncreaseFactor;

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
