using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisiones_gancho : MonoBehaviour
{

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            // Se ha producido una colisión con el objeto deseado
            Debug.Log("Colisión con el objeto deseado.");

            // Puedes realizar otras acciones aquí, como detener el movimiento del objeto o activar alguna animación.
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Objeto"))
        {
            Debug.Log("Colisión con el objeto deseado.");


        }
    }

}


