using UnityEngine;

using UnityEngine.Audio;
public class BouncySphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Assign a sphere prefab with a collider in the Inspector
    public Vector3 initialVelocity = new Vector3(-50, 0, 25); // Customizable initial velocity
    public Vector3 initialPosition = new Vector3(0, 3, 0); // Customizable initial velocity
    private PhysicMaterial bouncyMaterial; // Physics material for bounce
    public AudioMixerGroup sphereAudioMixerGroup; // Assign this in the Inspector
    public bool useGravity;
    public float speedIncreaseFactor = 1.0f;
    public bool playSound = true;
    public RigidbodyInterpolation interpolate;


    AudioSource audioSource;

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


        TimeBasedMovement timePosScript = sphere.AddComponent<TimeBasedMovement>();
        timePosScript.frequency = initialVelocity.magnitude/5;

        // Add PreciseMovement script and set initial velocity
        //PreciseMovement movementScript = sphere.AddComponent<PreciseMovement>();
        //movementScript.velocity = initialVelocity;

        // Add a Rigidbody and set its initial velocity
        //Rigidbody rb = sphere.AddComponent<Rigidbody>();
        //rb.interpolation = interpolate;
        //rb.collisionDetectionMode = CollisionDetectionMode.Discrete;   // not ContinousSpeculative good at high speeds
        //rb.velocity = initialVelocity;
        //rb.useGravity = useGravity;
        //rb.drag = 0;
        //rb.angularDrag = 0;
        //rb.freezeRotation = true; 
        SphereCollisionHandler sphereCollission = sphere.AddComponent<SphereCollisionHandler>();
        sphereCollission.playSound = playSound;
        sphereCollission.speedIncreaseFactor = speedIncreaseFactor;
        audioSource = sphere.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("c");
        audioSource.outputAudioMixerGroup = sphereAudioMixerGroup;
        audioSource.spatialBlend = 1.0f;


    }
}
