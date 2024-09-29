using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainTrust;
    [SerializeField] float mainRotate;
    Rigidbody body;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotating();
    }

    void ProcessThrust()
    {
        bool isPlaying = audioSource.isPlaying;

        if (Input.GetKey(KeyCode.Space))
        {
            body.AddRelativeForce(Vector3.up * mainTrust * Time.deltaTime);
            
            if(isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else if(isPlaying)
        {
            audioSource.Stop();
        }
    }

    void ProcessRotating()
    {
        Vector3 rotation = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            rotation = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation = -Vector3.forward;
        }

        if (rotation == Vector3.zero)
            return;



        body.freezeRotation = true;
        transform.Rotate(rotation * mainRotate * Time.deltaTime);
        body.freezeRotation = false;
    }
}
