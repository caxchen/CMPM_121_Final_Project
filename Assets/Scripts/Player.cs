using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class Player : MonoBehaviour

{
    public float speed = 10;
    //public ParticleSystem ps;
    private Rigidbody rb;
    private float movementX; // left/right arrow or A/D
    private float movementY; // up/down arrow or W/S
    private float rotationX; // mouse X movement (left or right)
    private float rotationY; // mouse Y movement (front or back)
    private float heightMovement; // range between -1 (down) to 1 (up)
    private float rollAmount; // range between -1 (left) to 1 (right)
    // Start is called before the first frame update 

    private GameObject cam;
    private GameObject body;

    void Start()
    {
        //GameObject body = this.gameObject.transform.getChild(0).getComponent<Rigidbody>();
        cam = GameObject.Find("Player");
        //body = self.transform.GetChild(1).gameObject;
        body = GameObject.Find("body");
        rb = body.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // hide cursor when playing the game
        //ps.Stop();
    }
    // On<Action> functions are defined in the InputActions Asset
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();
        rotationX = lookVector.x;
        rotationY = lookVector.y;
    }
    private void OnMoveUpDown(InputValue heightValue)
    {
        Vector2 heightVector = heightValue.Get<Vector2>();
        // Debug.Log(heightVector);
        heightMovement = heightVector.y;
    }
    private void OnRoll(InputValue rollValue)
    {
        Vector2 rollVector = rollValue.Get<Vector2>();
        // Debug.Log(rollVector);
        rollAmount = rollVector.x;
    }
    private void OnFire(InputValue fireValue)
    {
        // Debug.Log(fireValue.Get<float>());
        //ps.Emit(10);
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, heightMovement, movementY);
        rb.AddRelativeForce(movement * speed); //Local space
        // rb.AddForce(movement * speed); //World space
        // transform.Translate(new Vector3(-movementY, 0.0f, movementX) * speed * Time.fixedDeltaTime);
        //Vector3 rotation = new Vector3(-rotationY, rotationX, -rollAmount);
        //Quaternion deltaRotation = Quaternion.Euler(rotation * 10.0f * Time.fixedDeltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);
         float lookModifier = 0.75f;
         cam.transform.Rotate(-rotationY*lookModifier, rotationX*lookModifier, 0f);
         float dif = 6f;
         float b = body.transform.eulerAngles.y;
         float c = cam.transform.eulerAngles.y;
         float cminusb = c - b;
         if (b>c) {
            if (b-c > 180f && b-c>dif) { //rotate negative
                //Debug.Log(c.ToString()+"/"+b.ToString()+"  rotate "+(dif).ToString());
                body.transform.Rotate(0, dif, 0);
            }
            else if (b-c < 180f && b-c>dif) { //rotate positive
                //Debug.Log(c.ToString()+"/"+b.ToString()+"  rotate "+(-dif).ToString());
                body.transform.Rotate(0, -dif, 0);
            }
         } else if (c>b) {
            if (cminusb > 180f && cminusb > dif) { //rotate negative
                //Debug.Log(c.ToString()+"/"+b.ToString()+"  rotate "+(-dif).ToString());
                body.transform.Rotate(0, -dif, 0);
            }
            else if (cminusb < 180f-dif && cminusb > dif) { //rotate positive
                //Debug.Log(c.ToString()+"/"+b.ToString()+"  rotate "+(dif).ToString());
                body.transform.Rotate(0, dif, 0);
            }
         }
         cam.transform.rotation = Quaternion.Euler(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, 0);
         body.transform.rotation = Quaternion.Euler(0, body.transform.eulerAngles.y, 0);

        cam.transform.position = body.transform.position;

    }

}