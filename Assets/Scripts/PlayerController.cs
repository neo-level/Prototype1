using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    // Allows to interact with the variable in the unity editor while staying private.
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] private float horsePower = 0.0f;

    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;


    private float turnSpeed = 20;
    private float _horizontalInput;
    private float _forwardInput;

    private Rigidbody _carRigidbody;

    private void Start()
    {
        _carRigidbody = GetComponent<Rigidbody>();
        _carRigidbody.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Get the user input for horizontal movement.
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle based on Vertical input. using physics and the local system.
        _carRigidbody.AddRelativeForce(Vector3.forward * (horsePower * _forwardInput));
        // Rotates the Vehicle based on horizontal input.
        transform.Rotate(Vector3.up, turnSpeed * _horizontalInput * Time.deltaTime);

        // Calculates the speed in KMh and displays it in the gui.
        speed = _carRigidbody.velocity.magnitude * 3.6f; // Use 2.237 for mph.
        speedometerText.text = $"Speed: {(int) speed} kmh";

        // Calculate the RPM value
        rpm = (speed % 30) * 40;
        rpmText.SetText($"RPM: {(int) rpm}");
    }
}