using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using PathCreation.Examples;

public class rocketMove : MonoBehaviour
{
    //[SerializeField] InputAction movement;
    [Tooltip("м/с")] [SerializeField] float xSpeed = 4f;
    [SerializeField] float ySpeed = 4f;
    [SerializeField] float xMax = 6f;
    [SerializeField] float yMax = 6f;
    [SerializeField] float xRotationFactor = -5f;
    [SerializeField] float yRotationFactor = 5f;
    [SerializeField] float xMoveRotation = -10f;
    [SerializeField] float yMoveRotation = 10f;
    [SerializeField] float zMoveRotation = 0f;
    float xMove, yMove;

    // void OnEnable()
    // {
    //     movement.Enable();
    // }

    // void OnDisable()
    // {
    //     movement.Disable();
    // }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControlManager();
    }
    
    void ControlManager()
    {
        // управление по X
        //xMove = movement.ReadValue<Vector2>().x;
        xMove = Input.GetAxis("Horizontal");
        float xOffset = xMove * xSpeed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float maxXPos = Mathf.Clamp(newXPos, -xMax, xMax);
        transform.localPosition = new Vector3(maxXPos, transform.localPosition.y, transform.localPosition.z);
        // управление по Y
        //yMove = movement.ReadValue<Vector2>().y;
        yMove = Input.GetAxis("Vertical");
        float yOffset = yMove * ySpeed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float maxYPos = Mathf.Clamp(newYPos, -yMax, yMax);
        transform.localPosition = new Vector3(transform.localPosition.x, maxYPos, transform.localPosition.z);
        // вращение
        float xRotation = transform.localPosition.y * xRotationFactor + yMove * xMoveRotation;
        float yRotation = transform.localPosition.x * yRotationFactor + xMove * yMoveRotation;
        float zRotation = xMove * zMoveRotation;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }
}
