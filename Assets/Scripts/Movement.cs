using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float vertical_thrust = 1000f;
    [SerializeField] float rotation_thrust = 0.1f;
    [SerializeField] AudioClip mainEngine;

    Rigidbody rb;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        //Method for getting spacebar input for accelerating rocket
        if (Input.GetKey(KeyCode.Space)) {
            float vertical_force = vertical_thrust * Time.deltaTime;
            rb.AddRelativeForce(0, vertical_force, 0);
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(mainEngine);
            } 
        } else {
            audioSource.Stop();
        }
    }

    void ProcessRotation() {
        //Method for checking if player is rotating the rocket and seeing which direction to rotate
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotation_thrust);
        }
        else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotation_thrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        float rotation_force = rotationThisFrame * Time.deltaTime;
        transform.Rotate(0, 0, rotation_force);
        rb.freezeRotation = false;
    }
}
