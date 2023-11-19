using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    private int _valorMoneda;
    public controller_marcador marcador;
    public mover_gancho controller_gancho;
    // Start is called before the first frame update
    void Start()
    {
        _valorMoneda = 25;
        marcador = controller_marcador.getInstancia();
        controller_gancho = mover_gancho.getInstancia();

    }

    private void OnTriggerEnter(Collider colision)
    {
        //TODO: detectar la colision del gancho con una moneda
        Debug.Log("COLISION NAVE GANCHO");

        // Verificar si el objeto con el que colisionamos es una moneda 
        if (colision.CompareTag("Player"))
        {
            _monedaRecoguida(colision);
        }
    }

    private void _monedaRecoguida(Collider colision)
    {
        // Hacer que la moneda sea hija del objeto "gancho" 
        transform.parent = colision.transform; // transform hace referencia al transform del gancho 
        marcador.actualizarMonedasRecogidas();
        // Puedes realizar otras acciones o l�gica aqu� si es necesario 
        Debug.Log("MONEDA HIJA");
        controller_gancho.recogerMoneda();
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
