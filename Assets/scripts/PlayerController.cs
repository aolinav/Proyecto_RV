using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    public Transform moon;
    public float orbitSpeed = 50f;
    public float orbitRadius = 1f;
    public float rotationSpeed = 5f;

    void Update()
    {
        // Movimiento orbital alrededor de la Luna
        OrbitAroundMoon();

        // Control de orientación de la nave
        AdjustOrientation();
    }

    void OrbitAroundMoon()
    {
        // Calcula la posición relativa a la Luna
        Vector3 relativePosition = transform.position - moon.position;

        // Calcula la nueva posición orbital
        Quaternion rotation = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0);
        relativePosition = rotation * relativePosition;
        Vector3 newPosition = moon.position + relativePosition.normalized * orbitRadius;

        // Actualiza la posición de la nave
        transform.position = newPosition;

        // Alinea la nave hacia el centro de la Luna y hacia abajo
        transform.LookAt(moon.position, Vector3.down);
    }

    void AdjustOrientation()
    {
        // Controla la orientación de la nave utilizando las teclas de flecha
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        Vector3 rotationInput = new Vector3(-verticalInput, horizontalInput, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationInput * rotationSpeed * Time.deltaTime);
        transform.rotation *= deltaRotation;
    }
}
