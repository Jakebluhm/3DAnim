using System;
using UnityEngine;

public class TimeBasedMovement : MonoBehaviour
{
    public float amplitude = 5f;
    public float frequency = 1f;

    private float adjustedAmplitude = 1.0f;
    private float radius = 1.0f;
    private float lastSineValue = 0f;
    private bool wasAscending = false;
    private Vector3 startPosition;
    private float time;
    private AudioSource audioSource;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("SphereCollisionHandler - AudioSource component not found!");
        }


        startPosition = transform.position;

        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            radius = sphereCollider.radius;
            adjustedAmplitude = amplitude - radius;
        }

        time = 0f;
        lastSineValue = Mathf.Sin(frequency * time);
        wasAscending = lastSineValue < Mathf.Sin(frequency * (time + Time.deltaTime));
    }

    void Update()
    {
        time = Time.timeSinceLevelLoad;
        float currentSineValue = Mathf.Sin((float)(frequency * time ));
        transform.position = new Vector3(currentSineValue * adjustedAmplitude, startPosition.y, startPosition.z);

        bool isAscending = currentSineValue > lastSineValue;

        // Check for peak (transition from ascending to descending)
        if (wasAscending && !isAscending)
        {
            OnPeak();
        }
        // Check for trough (transition from descending to ascending)
        else if (!wasAscending && isAscending)
        {
            OnTrough();
        }
        // Check for zero crossing
        else if (Mathf.Sign(lastSineValue) != Mathf.Sign(currentSineValue))
        {
            OnZeroCrossing();
        }

        lastSineValue = currentSineValue;
        wasAscending = isAscending;
    }

    void OnPeak()
    {
        Debug.Log("Peak Reached");
        PlaySound();
    }

    void OnTrough()
    {
        Debug.Log("Trough Reached");
        PlaySound();
    }

    void OnZeroCrossing()
    {
        Debug.Log("Zero Crossing");
    }

    public void PlaySound()
    {
        // Play the sound
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();

        }
    }
}