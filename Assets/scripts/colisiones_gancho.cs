using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisiones_gancho : MonoBehaviour
{

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            // Se ha producido una colisi�n con el objeto deseado
            Debug.Log("Colisi�n con el objeto deseado.");

            // Puedes realizar otras acciones aqu�, como detener el movimiento del objeto o activar alguna animaci�n.
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Objeto"))
        {
            Debug.Log("Colisi�n con el objeto deseado.");


        }
    }

}


