using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Allows to interact with the variable in the unity editor while staying private.
    [SerializeField] private float _horsePower = 0.0f;
    
    private float turnSpeed = 20;
    private float _horizontalInput;
    private float _forwardInput;

    private Rigidbody _carRigidbody;

    private void Start()
    {
        _carRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the user input for horizontal movement.
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle based on Vertical input. using physics and the local system.
        _carRigidbody.AddRelativeForce(Vector3.forward * (_horsePower * _forwardInput));
        // Rotates the Vehicle based on horizontal input.
        transform.Rotate(Vector3.up, turnSpeed * _horizontalInput * Time.deltaTime);
    }
}