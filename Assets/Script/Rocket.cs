using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource rocketSound;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void Thrust()
    {
        if(Input.GetKey(KeyCode.Space)) //can thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if(!rocketSound.isPlaying) rocketSound.Play(); //so the sounds don't layer on top of each other
        }
        else rocketSound.Stop(); //when we aren't holding down the space key then stop the sound
    }

    void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation
        float rcsThrust = 100f;
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame); //go left
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame); //go right
        }
        rigidBody.freezeRotation = false; //resume physics control of rotation
    }
}
