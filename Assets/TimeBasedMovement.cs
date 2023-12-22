using UnityEngine;

public class TimeBasedMovement : MonoBehaviour
{
    public float amplitude = 5f;
    public float frequency = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float time = Time.timeSinceLevelLoad;
        transform.position = startPosition + amplitude * new Vector3(Mathf.Sin(frequency * time), 0, 0);
    }
}
