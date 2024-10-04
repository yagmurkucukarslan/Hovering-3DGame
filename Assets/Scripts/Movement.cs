using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSoruce;
    ParticleSystem particle;
    [SerializeField] float moveSpeed = 1000;
    [SerializeField] float rotationThrust = 100;
    [SerializeField] AudioClip mainSound;
    [SerializeField] ParticleSystem Turnleft;
    [SerializeField] ParticleSystem Turnright;
    [SerializeField] ParticleSystem Mainjet;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSoruce = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if (!Turnleft.isPlaying)
            {
                Turnleft.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if (!Turnright.isPlaying)
            {
                Turnright.Play();
            }
        }
        else
        {
            Turnleft.Stop();
            Turnright.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * moveSpeed * Time.deltaTime);
            if (!audioSoruce.isPlaying)
            {
                audioSoruce.PlayOneShot(mainSound);
            }
            if (!Mainjet.isPlaying)
            {
                Mainjet.Play();
            }
        }
        else
        {
            audioSoruce.Stop();
            Mainjet.Stop();
        }
    }

}
