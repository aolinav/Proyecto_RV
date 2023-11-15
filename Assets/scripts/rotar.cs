using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour
{
    public float velocidadDeRotacion = 0.5f;
    public float velocidadRotacionLuna = 0.1f;
    public Transform pivote;
    public List<Transform> objetosArotar;

    private void Start()
    {
        // Limpiar la lista actual
        objetosArotar.Clear();

        // Obtener todos los objetos hijos de la luna
        foreach (Transform hijo in pivote.transform)
        {
            objetosArotar.Add(hijo);
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Transform objeto in objetosArotar)
        {
            objeto.transform.RotateAround(pivote.transform.position, Vector3.up, velocidadDeRotacion);
        }
        
    }

    void RotarLuna()
    {
        // Rotar la luna sobre su propio eje
        pivote.transform.Rotate(Vector3.up, velocidadRotacionLuna * Time.deltaTime);
    }
}
