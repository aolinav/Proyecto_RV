using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisiones_gancho : MonoBehaviour
{
    public GameObject bola;
    public GameObject verde;
    
    private void OnTriggerEnter(Collider colision)
    {

        // Verificar si el objeto con el que colisionamos es una moneda 
        if (colision.CompareTag("nave"))
        {
            Debug.Log("COLISION GANCHO");

            // Se ha producido una colisi�n con el objeto deseado
            mover_gancho.getInstancia().setMonedaRecogida(false);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            bola.GetComponent<Rigidbody>().velocity = Vector3.zero;
            verde.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().isKinematic = true;
            bola.GetComponent<Rigidbody>().isKinematic = true;
            verde.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("PARADO");
            
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

    private void Start()
    {
        // Busca el objeto que tiene el script mover_gancho y suscr�bete al evento
        mover_gancho scriptMoverGancho = FindObjectOfType<mover_gancho>();
        if (scriptMoverGancho != null)
        {
            scriptMoverGancho.OnGanchoCollision += HandleGanchoCollision;
        }
    }

    private void HandleGanchoCollision()
    {
        // Acciones que deseas realizar cuando hay una colisi�n
        Debug.Log("El gancho ha tocado el objeto.");
    }
}
