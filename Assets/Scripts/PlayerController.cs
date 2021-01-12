using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10.0f;
    private float turnSpeed = 20;
    private float _horizontalInput;
    private float _forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the user input for horizontal movement.
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        
        // Move the vehicle based on Vertical input.
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * _forwardInput));
        
        // Rotates the Vehicle based on horizontal input.
        transform.Rotate(Vector3.up, turnSpeed * _horizontalInput * Time.deltaTime);
    }
}
