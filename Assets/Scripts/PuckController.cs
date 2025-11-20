using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    [SerializeField] private AudioClip puckHitSound;
    private Rigidbody rb;
    [SerializeField] float force = 1000f;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayHitSound();
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 forceDirection = collision.contacts[0].point - transform.position;
            forceDirection = -forceDirection.normalized;

            rb.AddForce(forceDirection * force); 
        }
    }
    private void PlayHitSound()
    {
        if (puckHitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(puckHitSound); 
        }
        else
        {
            Debug.LogWarning("Missing AudioClip or AudioSource on the puck.");
        }

    }
}

