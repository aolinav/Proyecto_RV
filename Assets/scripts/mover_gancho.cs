using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class mover_gancho : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Recoge los tres objetos que conforman el gancho
    public GameObject bola;
    public GameObject garras;
    public GameObject verde;
    public Button botonGancho;
    public float velocidad = 10f;
    private bool moneda_recogida = false;
    //La parte del gancho que sera la referencia de vuelta del gancho cuando recoga la moneda
    public Transform objetivo;
    //Auxiliar para mover el gancho
    private bool presionado = false;
    public static mover_gancho instancia;

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

    public void setMonedaRecogida(bool i)
    {
        moneda_recogida = i;
    }

    public void Start()
    {
        
    }

    public event Action OnGanchoCollision;
    // Update is called once per frame
    void Update()
    {
        if (presionado)
        {
            //Movimiento hacia abajo de los objetos recogidos           
            // Calcula el vector hacia abajo en relación con el objeto padre
            Vector3 movimientoHaciaAbajo = -objetivo.up;

            // Mueve el objeto perpendicularmente a su objeto padre
            garras.transform.Translate(movimientoHaciaAbajo * velocidad * Time.deltaTime, Space.World);
            // Mueve el objeto perpendicularmente a su objeto padre
            bola.transform.Translate(movimientoHaciaAbajo * velocidad * Time.deltaTime, Space.World);
            // Mueve el objeto perpendicularmente a su objeto padre
            verde.transform.Translate(movimientoHaciaAbajo * velocidad * Time.deltaTime, Space.World);
        }
        if (moneda_recogida)
        {

            // Calcula el vector hacia abajo en relación con el objeto padre
            Vector3 movimientoHaciaAbajo = objetivo.up;

            // Mueve el objeto perpendicularmente a su objeto padre
            garras.transform.Translate(movimientoHaciaAbajo * velocidad * Time.deltaTime, Space.World);
            // Mueve el objeto perpendicularmente a su objeto padre
            bola.transform.Translate(movimientoHaciaAbajo * velocidad * Time.deltaTime, Space.World);
            // Mueve el objeto perpendicularmente a su objeto padre
            verde.transform.Translate(movimientoHaciaAbajo * velocidad * Time.deltaTime, Space.World);
        }
    
    }

  
    //Evento llamado cuando se deja de clickar un objeto de la interfaz en el que este como componente este script
    //en este caso el boton
    public void OnPointerUp(PointerEventData eventData)
    {
        print("Boton liberado");
        presionado = false;

    }

    //Evento llamado cuando se clicka un objeto de la interfaz
    public void OnPointerDown(PointerEventData eventData)
    {
        print("Boton pulsado");
        presionado = true;

    }

    public static mover_gancho getInstancia()
    {
        return instancia;
    }

    public void recogerMoneda()
    {
        //TODO: recoger el gancho cuando haya tocado la moneda

        Debug.Log("DEVOLVIENDO MONEDA");
        // Mueve gradualmente "moneda" hacia la posición de "nave"
        float velocidadMovimiento = .05f; // Puedes ajustar la velocidad según sea necesario
        float paso = velocidadMovimiento * Time.deltaTime;

        botonGancho = GetComponent<Button>();
        botonGancho.interactable = false;
        moneda_recogida = true;
        // Calcula la dirección hacia el objetivo
        //Vector3 direccion = (objetivo.position - garras.transform.position).normalized;


       
    }
}


