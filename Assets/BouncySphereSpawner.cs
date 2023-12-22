using UnityEngine;

public class BouncySphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Assign a sphere prefab with a collider in the Inspector
    public Vector3 initialVelocity = new Vector3(-50, 0, 25); // Customizable initial velocity
    public Vector3 initialPosition = new Vector3(0, 3, 0); // Customizable initial velocity
    private PhysicMaterial bouncyMaterial; // Physics material for bounce

    void Start()
    {
        // Load the bouncy material from the Assets
        bouncyMaterial = Resources.Load<PhysicMaterial>("bouncyMaterial");
        if (bouncyMaterial == null)
        {
            Debug.LogError("Bouncy Material not found. Ensure it's in a Resources folder.");
            return;
        }

        SpawnBouncySphere();
    }

    void SpawnBouncySphere()
    {
        // Instantiate the sphere
        GameObject sphere = Instantiate(spherePrefab, initialPosition, Quaternion.identity);
        sphere.tag = "Sphere";

        // Apply the bouncy material to the sphere's collider
        Collider sphereCollider = sphere.GetComponent<Collider>();
        if (sphereCollider != null)
        { 
            sphereCollider.material = bouncyMaterial;
        }

        // Add a Rigidbody and set its initial velocity
        Rigidbody rb = sphere.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;   // not ContinousDynamic
        rb.velocity = initialVelocity;
        sphere.AddComponent<SphereCollisionHandler>();
    }
}
