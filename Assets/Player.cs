using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 rotation = new Vector3(-rotationY, rotationX, -rollAmount);
        Quaternion deltaRotation = Quaternion.Euler(rotation * 10.0f * 
            Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}