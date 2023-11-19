using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisiones_gancho : MonoBehaviour
{
    public GameObject bola;
    public GameObject verde;
    private controller_marcador marcador;
    private void OnTriggerEnter(Collider colision)
    {

        // Verificar si el objeto con el que colisionamos es una moneda 
        if (colision.CompareTag("nave"))
        {
            Debug.Log("COLISION GANCHO");

            // Se ha producido una colisión con el objeto deseado
            mover_gancho.getInstancia().setMonedaRecogida(false);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            bola.GetComponent<Rigidbody>().velocity = Vector3.zero;
            verde.GetComponent<Rigidbody>().velocity = Vector3.zero;

            GetComponent<Rigidbody>().isKinematic = true;
            bola.GetComponent<Rigidbody>().isKinematic = true;
            verde.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("PARADO");

            marcador = controller_marcador.getInstancia();
            marcador.quitarAvisoMoneda();
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

    private void Start()
    {
        // Busca el objeto que tiene el script mover_gancho y suscríbete al evento
        mover_gancho scriptMoverGancho = FindObjectOfType<mover_gancho>();
        if (scriptMoverGancho != null)
        {
            scriptMoverGancho.OnGanchoCollision += HandleGanchoCollision;
        }
    }

    private void HandleGanchoCollision()
    {
        // Acciones que deseas realizar cuando hay una colisión
        Debug.Log("El gancho ha tocado el objeto.");
    }
}
