using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public FixedJoystick _joystick;

    public Transform moon;
    public float rotationSpeed = 50f;

    public float verticalInput;
    public float horizontalInput;

    public float tiltSpeed = 20f;

    void Update()
    {
        verticalInput = _joystick.Vertical;
        horizontalInput = _joystick.Horizontal;

        
        MoveForward();
        Tilt();
        //RotateAroundObject();

    }

    void RotateAroundObject()
    {
        float horizontalInput = _joystick.Horizontal;

        // Rotación alrededor del objeto central (la luna)
        transform.RotateAround(moon.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

    }

    void MoveForward()
    {
        // Aplica una fuerza hacia adelante en la dirección actual de la nave
        _rigidbody.AddForce( Mathf.Abs(verticalInput) * transform.forward * rotationSpeed * Time.deltaTime, ForceMode.Force);
    }

    void Tilt()
    {
        float tiltHorizontalInput = _joystick.Horizontal; // Inclinación en el eje X
        float tiltVerticalInput = _joystick.Vertical; // Inclinación en el eje Y

        // Calcula la inclinación en el eje X
        Vector3 tiltAxisX = moon.right;
        Quaternion tiltRotationX = Quaternion.AngleAxis(tiltVerticalInput * tiltSpeed * Time.deltaTime, tiltAxisX);

        // Calcula la inclinación en el eje Y
        Vector3 tiltAxisY = moon.up;
        Quaternion tiltRotationY = Quaternion.AngleAxis(-tiltHorizontalInput * tiltSpeed * Time.deltaTime, tiltAxisY);

        // Aplica la inclinación al objeto
        transform.rotation *= tiltRotationX * tiltRotationY;
    }



}
