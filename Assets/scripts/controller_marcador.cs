using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controller_marcador : MonoBehaviour
{
    public static controller_marcador instancia;
    public GameObject luna;

    private TextMeshProUGUI _marcadorMonedas;
    private TextMeshProUGUI _marcadorTiempo;
    // _contador monedas contiene el total de monedas de una escena
    private int _contadorMonedas = 0;
    private string _tagMoneda = "Moneda";
    private int _monedasRecogidas = 0;
    private float _segundosNivel = 60000f;
    private float _tiempoTranscurrido = 0f;
    private float _tiempoTranscurridoEnMilisegundos = 0f;

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
        _marcadorMonedas = GameObject.Find("MarcadorMonedas").GetComponent<TextMeshProUGUI>();
        _marcadorTiempo = GameObject.Find("Tiempo").GetComponent<TextMeshProUGUI>();

        //recogemos los hijos de luna
        Transform[] hijos = luna.GetComponentsInChildren<Transform>(true);

        // Inicializa el contador
        _contadorMonedas = 0;

        // Itera a través de los hijos y cuenta aquellos que coinciden con la etiqueta _tagMoneda
        foreach (Transform hijo in hijos)
        {
            if (hijo.CompareTag(_tagMoneda))
            {
                //Si no tuviesen el script de moneda aplicado puede correrse esta linea que automatiza el proceso
                //hijo.gameObject.AddComponent<moneda>();
                _contadorMonedas++;
            }
        }
        Debug.Log("Número total de monedas: " + _contadorMonedas);

    }

    // Update is called once per frame
    void Update()
    {
        
        _tiempoTranscurrido += Time.deltaTime;
        // Multiplica _tiempoTranscurrido por 1000 para convertirlo a milisegundos
        _tiempoTranscurridoEnMilisegundos = _tiempoTranscurrido * 1000;
        //Actualiza los marcadores de monedas y tiempo de la interfaz
        actualizarUI();
        // Compara _tiempoTranscurrido en milisegundos con valorEnMilisegundos
        tiempoLimiteExcedido();
        // Compara _monedasRecogidas con _contadorMonedas para ver si se han recogido todas las monedas
        monedasExcedidas();
     
    }

    public void actualizarUI()
    {
        //Actualiza cada frame el numero de monedas recogidas y totales 
        _marcadorMonedas.text = _monedasRecogidas.ToString() + " / " + _contadorMonedas.ToString();
        //Actualiza el tiempo que le queda al usuario para acabar el nivel
        _marcadorTiempo.text = ((int)(_segundosNivel / 1000 - _tiempoTranscurrido)).ToString();

    }

    public void tiempoLimiteExcedido()
    {
        if (_tiempoTranscurridoEnMilisegundos >= _segundosNivel)
        {
            Debug.Log("Han pasado " + _segundosNivel + " milisegundos.");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void monedasExcedidas()
    {
        if (_monedasRecogidas == _contadorMonedas)
        {
            Debug.Log("Se han recogido todas las monedas");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void actualizarMonedasRecogidas()
    {
        setMonedasRecogidas(1);
        Debug.Log("MONEDA RECOGIDA");
    }

    private void setMonedasRecogidas(int cantidad)
    {
        _monedasRecogidas += cantidad;
    }

    private int getMonedasRecogidas()
    {
        return _monedasRecogidas;
    }

    private void setMonedas(int cantidad)
    {
        _contadorMonedas = cantidad;
    }

    private float getTiempoTranscurrido()
    {
        return _tiempoTranscurrido;
    }

   
    private int getMonedas(int cantidad)
    {
        return _contadorMonedas;
    }

    public static controller_marcador getInstancia()
    {
        return instancia;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // La aplicación está en pausa
            Debug.Log("La aplicación está en pausa. Tiempo total: " + _tiempoTranscurrido + " segundos");
        }
    }

    void OnApplicationQuit()
    {
        // La aplicación está saliendo
        Debug.Log("La aplicación está saliendo. Tiempo total: " + _tiempoTranscurrido + " segundos");
    }
}
