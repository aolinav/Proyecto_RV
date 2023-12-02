using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactuar : MonoBehaviour
{
    // Variables Globales
    public GameObject obj; // Objeto que queremos coger
    public Transform virtualCamera; // Asigna tu cámara virtual desde el editor
    public float movementSpeed = 10f; // Velocidad de movimiento, puedes ajustarla desde el editor
    public GameObject player;


    Vector3 objPos;

    // Start is called before the first frame update
    void Start()
    {
        objPos = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Variables Locales
        RaycastHit hit;
        // Asegúrate de que el rayo se lance desde la posición de la cámara y en la dirección de la cámara
        Ray ray = new Ray(virtualCamera.position, virtualCamera.forward);

        // Debug para visualizar el rayo en la escena
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.blue);
        // Cambiar por el boton del mando
        if (Input.GetButton("Fire1"))
        {

            // Comprobamos que estamos apuntando al objeto
            if (Physics.Raycast(virtualCamera.position, virtualCamera.forward, out hit))
            {
                if (hit.transform.CompareTag("inte"))
                {

                    Debug.DrawRay(transform.position, Vector3.forward + hit.point, Color.red);
                    // Si el objeto no esta en mis manos, posicionarlo en mis manos


                    MoveObject(hit.transform.gameObject, virtualCamera);

                }
                else
                {
                    Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.red);
                }

            }



        }
        else
        {
            // El objeto se devuelve a su posicion inicial
            //obj.transform.localPosition = objPos;
        }

    }

    private void MoveObject(GameObject objToMove, Transform camera)
    {
        Vector3 newPosition = camera.position + camera.forward;
        Quaternion newRotation = camera.rotation;

        // Establece la nueva posición y rotación del objeto
        objToMove.transform.position = Vector3.Lerp(objToMove.transform.position, newPosition, Time.deltaTime * 10f);
        objToMove.transform.rotation = Quaternion.Lerp(objToMove.transform.rotation, newRotation, Time.deltaTime * 10f);
    }

}