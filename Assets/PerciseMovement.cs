using UnityEngine;

public class PreciseMovement : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 bounds = new Vector3(5, 5, 5); // Define the boundaries for bouncing

    void Update()
    {
        Vector3 newPosition = transform.position + velocity * Time.deltaTime;

        // Check for boundary collision and adjust velocity
        if (newPosition.x > bounds.x || newPosition.x < -bounds.x) velocity.x = -velocity.x;
        if (newPosition.y > bounds.y || newPosition.y < -bounds.y) velocity.y = -velocity.y;
        if (newPosition.z > bounds.z || newPosition.z < -bounds.z) velocity.z = -velocity.z;

        transform.position = newPosition;
    }
}
