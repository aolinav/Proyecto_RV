using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mover_gancho : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Recoge los tres objetos que conforman el gancho
    public GameObject bola;
    public GameObject garras;
    public GameObject verde;
    //Auxiliar para mover el gancho
    private bool presionado = false;
    

    // Update is called once per frame
    void Update()
    {
        if (presionado)
        {
            //Movimiento hacia abajo de los objetos recogidos
            bola.transform.Translate(Vector3.back * Time.deltaTime, Space.World);
            garras.transform.Translate(Vector3.back * Time.deltaTime, Space.World);
            verde.transform.Translate(Vector3.back * Time.deltaTime, Space.World);

            //TODO: detectar la colision del gancho con una moneda


            //TODO: recoger el gancho cuando haya tocado la moneda

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

}
