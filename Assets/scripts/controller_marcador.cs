using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class controller_marcador : MonoBehaviour
{
    public static controller_marcador instancia;

    private List<moneda> listaMonedas = new List<moneda>();
    public GameObject luna;

    // _contador monedas contiene el total de monedas de una escena
    private int _contadorMonedas = 0;
    private string _tagMoneda = "Moneda";
    private int _monedasRecogidas = 0;
    private int _segundosNivel = 60;

    void Awake()
    {
        //Comprobamos si hay una instancia ya creada

        //Si no la hay, creamos una y la marcamos como insdestructible
        //entre escenas para poder usarla en todas las escenas del juego
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }

        //Si la hay destruimos inmediatamente la recien creada para no
        //tener ningun tipo de problema de compatibilidad
        else
        {
            DestroyImmediate(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //recogemos los hijos de luna
        Transform[] hijos = luna.GetComponentsInChildren<Transform>(true);

        // Inicializa el contador
        _contadorMonedas = 0;

        // Itera a través de los hijos y cuenta aquellos que coinciden con la etiqueta _tagMoneda
        foreach (Transform hijo in hijos)
        {
            if (hijo.CompareTag(_tagMoneda))
            {
                _contadorMonedas++;
            }
        }
        Debug.Log("Número total de monedas: " + _contadorMonedas);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void actualizarMonedas()
    {
        setMonedas(1);
    }

    private void setMonedas(int cantidad)
    {
        _monedasRecogidas += cantidad;
    }

    public static controller_marcador getInstancia()
    {
        return instancia;
    }
}
