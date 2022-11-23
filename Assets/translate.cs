using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //movement speed in units per second
    private float movementSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis (arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput
                            * movementSpeed * Time.deltaTime, 0, 
                            verticalInput * movementSpeed * Time.deltaTime);

        //output to log the position change
        // Debug.Log(transform.position);
    }
}
