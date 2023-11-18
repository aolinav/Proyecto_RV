using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    private int _valorMoneda;
    public controller_marcador marcador;
    // Start is called before the first frame update
    void Start()
    {
        _valorMoneda = 25;
        marcador = controller_marcador.getInstancia();

    }

    private void OnTriggerEnter(Collider colision)
    {
        Debug.Log("COLISION NAVE GANCHO");

        // Verificar si el objeto con el que colisionamos es una moneda 
        if (colision.CompareTag("Moneda"))
        {
            _monedaRecoguida(colision);
        }
    }

    private void _monedaRecoguida(Collider colision)
    {
        // Hacer que la moneda sea hija del objeto "gancho" 
        colision.transform.parent = transform; // transform hace referencia al transform del gancho 
        marcador.actualizarMonedas();
        // Puedes realizar otras acciones o l�gica aqu� si es necesario 
        Debug.Log("MONEDA HIJA");
    }

    public int getValor()
    {
        return _valorMoneda;
    }

    public void setValor(int valor)
    {
        _valorMoneda = valor;
    }
}
