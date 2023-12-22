using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Planes : MonoBehaviour
{
    private PhysicMaterial bouncyMaterial; 
    AudioSource[] audioSources = new AudioSource[6];
    AudioClip[] audioClips = new AudioClip[6];
    public AudioMixerGroup planeAudioMixerGroup; // Assign this in the Inspector
    public bool playSounds = false;

    // Start is called before the first frame update
    void Start()
    { 
        Debug.Log("Hiiii XD");
        float scale = 1;
        int index = 0;
        GameObject[] planes = new GameObject[6];
        BoxCollider[] boxCollider = new BoxCollider[6];
        Rigidbody[] rigidbody = new Rigidbody[6];
        PlaneCollisionDetector[] planeCollisionDetectors = new PlaneCollisionDetector[6];
        // Load the bouncy material from the Assets
        bouncyMaterial = Resources.Load<PhysicMaterial>("bouncyMaterial");
        if (bouncyMaterial == null)
        {
            Debug.LogError("Bouncy Material not found. Ensure it's in a Resources folder.");
            return;
        }

        // Create the front horizontal plane
        planes[index] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planes[index].transform.position = new Vector3(0, 0, 0);
        planes[index].transform.rotation = Quaternion.Euler(0, 0, 0);
        boxCollider[index] = planes[index].AddComponent<BoxCollider>();
        boxCollider[index].material = bouncyMaterial; // Apply bouncy material to the plane's collider
        planeCollisionDetectors[index] = planes[index].AddComponent<PlaneCollisionDetector>();
        planeCollisionDetectors[index].playSound = playSounds;
        planes[index].tag = "Plane";
        planes[index].name = "Plane " + index;
        audioSources[index] = planes[index].AddComponent<AudioSource>();
        audioSources[index].clip = Resources.Load<AudioClip>("c");
        audioSources[index].outputAudioMixerGroup = planeAudioMixerGroup;
        audioSources[index].spatialBlend = 1.0f;
        planes[index++].transform.localScale = new Vector3(scale, scale, scale);

        // Create the front horizontal plane
        planes[index] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planes[index].transform.position = new Vector3(-5, 5, 0);
        planes[index].transform.rotation = Quaternion.Euler(90, 90, 0);
        boxCollider[index] = planes[index].AddComponent<BoxCollider>();
        boxCollider[index].material = bouncyMaterial; // Apply bouncy material to the plane's collider
        planeCollisionDetectors[index] = planes[index].AddComponent<PlaneCollisionDetector>();
        planeCollisionDetectors[index].playSound = playSounds;
        planes[index].tag = "Plane";
        planes[index].name = "Plane " + index;
        audioSources[index] = planes[index].AddComponent<AudioSource>();
        audioSources[index].clip = Resources.Load<AudioClip>("d");
        audioSources[index].outputAudioMixerGroup = planeAudioMixerGroup;
        audioSources[index].spatialBlend = 1.0f;
        planes[index++].transform.localScale = new Vector3(scale, scale, scale);


        // Create the front horizontal plane
        planes[index] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planes[index].transform.position = new Vector3(5, 5, 0);
        planes[index].transform.rotation = Quaternion.Euler(90, 0, 90);
        boxCollider[index] = planes[index].AddComponent<BoxCollider>();
        boxCollider[index].material = bouncyMaterial; // Apply bouncy material to the plane's collider
        planeCollisionDetectors[index] = planes[index].AddComponent<PlaneCollisionDetector>();
        planeCollisionDetectors[index].playSound = playSounds;
        planes[index].tag = "Plane";
        planes[index].name = "Plane " + index;
        audioSources[index] = planes[index].AddComponent<AudioSource>();
        audioSources[index].clip = Resources.Load<AudioClip>("e");
        audioSources[index].outputAudioMixerGroup = planeAudioMixerGroup;
        audioSources[index].spatialBlend = 1.0f;
        planes[index++].transform.localScale = new Vector3(scale, scale, scale);


        // Create the front horizontal plane
        planes[index] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planes[index].transform.position = new Vector3(0, 5, 5);
        planes[index].transform.rotation = Quaternion.Euler(90, 0, 180);
        boxCollider[index] = planes[index].AddComponent<BoxCollider>();
        boxCollider[index].material = bouncyMaterial; // Apply bouncy material to the plane's collider
        planeCollisionDetectors[index] = planes[index].AddComponent<PlaneCollisionDetector>();
        planeCollisionDetectors[index].playSound = playSounds;
        planes[index].tag = "Plane";
        planes[index].name = "Plane " + index;
        audioSources[index] = planes[index].AddComponent<AudioSource>();
        audioSources[index].clip = Resources.Load<AudioClip>("f");
        audioSources[index].outputAudioMixerGroup = planeAudioMixerGroup;
        audioSources[index].spatialBlend = 1.0f;
        planes[index++].transform.localScale = new Vector3(scale, scale, scale);


        // Create the front horizontal plane
        planes[index] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planes[index].transform.position = new Vector3(0, 5, -5);
        planes[index].transform.rotation = Quaternion.Euler(90, 0, 0);
        boxCollider[index] = planes[index].AddComponent<BoxCollider>();
        boxCollider[index].material = bouncyMaterial; // Apply bouncy material to the plane's collider
        planeCollisionDetectors[index] = planes[index].AddComponent<PlaneCollisionDetector>();
        planeCollisionDetectors[index].playSound = playSounds;
        planes[index].tag = "Plane";
        planes[index].name = "Plane " + index;
        audioSources[index] = planes[index].AddComponent<AudioSource>();
        audioSources[index].clip = Resources.Load<AudioClip>("g");
        audioSources[index].outputAudioMixerGroup = planeAudioMixerGroup;
        audioSources[index].spatialBlend = 1.0f;
        planes[index++].transform.localScale = new Vector3(scale, scale, scale);


        // Create the front horizontal plane
        planes[index] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planes[index].transform.position = new Vector3(0, 10, 0);
        planes[index].transform.rotation = Quaternion.Euler(180, 0, 0);
        boxCollider[index] = planes[index].AddComponent<BoxCollider>();
        boxCollider[index].material = bouncyMaterial; // Apply bouncy material to the plane's collider
        planeCollisionDetectors[index] = planes[index].AddComponent<PlaneCollisionDetector>();
        planeCollisionDetectors[index].playSound = playSounds;
        planes[index].tag = "Plane";
        planes[index].name = "Plane " + index;
        audioSources[index] = planes[index].AddComponent<AudioSource>();
        audioSources[index].clip = Resources.Load<AudioClip>("a");
        audioSources[index].outputAudioMixerGroup = planeAudioMixerGroup;
        audioSources[index].spatialBlend = 1.0f; 
        planes[index++].transform.localScale = new Vector3(scale, scale, scale);


    }

    // Update is called once per frame
    void Update()
    {
        if (SphereCollisionHandler.LastCollidedPlane != null)
        { 
   
               PlaneCollisionDetector detector = SphereCollisionHandler.LastCollidedPlane.GetComponent<PlaneCollisionDetector>();
            if (detector != null && detector.HasCollided)
            {
                // Perform your actions here
                Debug.Log("Sphere collided with " + SphereCollisionHandler.LastCollidedPlane.name);

                // Reset collision state
                detector.ResetCollision(); 
                SphereCollisionHandler.ResetLastCollidedPlane();

            }
        }
    }

}
