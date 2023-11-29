using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_controller : MonoBehaviour
{
    public GameObject player;
    private float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        movimientoPlayer();
    }

    public void movimientoPlayer()
    {
        Vector3 forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0; // No queremos movimiento vertical.

        // Normaliza para asegurarnos de que solo estemos obteniendo la direcci�n, no la magnitud.
        forwardDirection.Normalize();

        Vector3 rightDirection = Camera.main.transform.right;
        rightDirection.y = 0; // No queremos movimiento vertical.

        // Normaliza para asegurarnos de que solo estemos obteniendo la direcci�n, no la magnitud.
        rightDirection.Normalize();

        print(forwardDirection);

        if (Input.GetButtonDown("Adelante"))
        {
            // Obt�n la direcci�n en la que est� mirando la c�mara de realidad virtual.
            print("C");
            player.transform.position += forwardDirection * speed;

        }
        if (Input.GetButtonDown("Atras"))
        {
            // Obt�n la direcci�n en la que est� mirando la c�mara de realidad virtual.
            print("D");
            player.transform.position += rightDirection * speed;

        }
        if (Input.GetButtonDown("Drch"))
        {
            // Obt�n la direcci�n en la que est� mirando la c�mara de realidad virtual.
            print("A");
            player.transform.position += -forwardDirection * speed;
        }
        if (Input.GetButtonDown("Izq"))
        {
            // Obt�n la direcci�n en la que est� mirando la c�mara de realidad virtual.
            print("B");
            player.transform.position += -rightDirection * speed;

        }
    }
}
