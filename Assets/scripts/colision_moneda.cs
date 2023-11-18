using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class colision_moneda_gancho : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLISION NAVE GANCHO");

        // Verificar si el objeto con el que colisionamos es una moneda 
        if (other.CompareTag("Moneda"))
        {
            // Hacer que la moneda sea hija del objeto "gancho" 
            other.transform.parent = transform; // transform hace referencia al transform del gancho 

            // Puedes realizar otras acciones o l�gica aqu� si es necesario 
            Debug.Log("MONEDA HIJA");
        }
    }
}