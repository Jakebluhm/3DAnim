using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public BouncySphereSpawner spawner; // Assign in Inspector
    public int numberOfSpheres = 5;
    public float spacing = 2.0f;
    public Vector3 initialPosition = new Vector3(0, 3, 0);

    void Start()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            Vector3 position = initialPosition + new Vector3(-4.5f, 3, spacing * i);
            spawner.SpawnSphere(position, 0.5f * (i+1));
        }
    }
}
