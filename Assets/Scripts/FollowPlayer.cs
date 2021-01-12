using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Create reference to an object in unity. => Vehicle
    public GameObject player;
    // Create a vector to hold the camera position.
    private Vector3 offset = new Vector3(0, 5, -7);
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the position to the camera equal to the referenced object and applies the offset.
        transform.position = player.transform.position + offset;
       
    }
}
