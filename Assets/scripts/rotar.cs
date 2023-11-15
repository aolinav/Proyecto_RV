using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public float velocidadRotacionLuna = 0.1f;
    public Transform pivote;
    public List<Transform> objetosArotarAltura1;
    public List<Transform> objetosArotarAltura2;

    public float alturaOffset1 = 1.0f;
    public float alturaOffset2 = 2.0f;
    public float velocidadRotacionMin = 0.3f;
    public float velocidadRotacionMax = 0.7f;
    public float velocidadRotacionPropiaAltura2 = 5.0f; // Nueva variable

    private void Start()
    {
        // Limpiar las listas actuales
        objetosArotarAltura1.Clear();
        objetosArotarAltura2.Clear();

        // Obtener todos los objetos hijos de la luna y asignarlos a las listas correspondientes
        foreach (Transform hijo in pivote.transform)
        {
            if (Random.Range(0, 2) == 0)
            {
                objetosArotarAltura1.Add(hijo);
            }
            else
            {
                objetosArotarAltura2.Add(hijo);
            }
        }

        // Asignar velocidades de rotación aleatorias para cada lista
        AsignarVelocidadesAleatorias(objetosArotarAltura1);
        AsignarVelocidadesAleatorias(objetosArotarAltura2);

        // Asignar velocidad de rotación propia en el eje Z para objetosArotarAltura2
        AsignarVelocidadRotacionPropia(objetosArotarAltura2, velocidadRotacionPropiaAltura2);
    }

    // Update is called once per frame
    void Update()
    {
        RotarObjetos(objetosArotarAltura1, alturaOffset1);
        RotarObjetos(objetosArotarAltura2, alturaOffset2);
        RotarLuna();
    }

    void RotarObjetos(List<Transform> objetos, float alturaOffset)
    {
        foreach (Transform objeto in objetos)
        {
            objeto.transform.RotateAround(pivote.transform.position + Vector3.up * alturaOffset, Vector3.up, objeto.GetComponent<VelocidadOrbital>().velocidadRotacion * Time.deltaTime);
        }
    }

    void RotarLuna()
    {
        // Rotar la luna sobre su propio eje
        pivote.transform.Rotate(Vector3.up, velocidadRotacionLuna * Time.deltaTime);
    }

    void AsignarVelocidadesAleatorias(List<Transform> objetos)
    {
        foreach (Transform objeto in objetos)
        {
            objeto.gameObject.AddComponent<VelocidadOrbital>().velocidadRotacion = Random.Range(velocidadRotacionMin, velocidadRotacionMax);
        }
    }

    void AsignarVelocidadRotacionPropia(List<Transform> objetos, float velocidad)
    {
        foreach (Transform objeto in objetos)
        {
            objeto.gameObject.AddComponent<VelocidadPropia>().velocidadRotacionPropia = velocidad;
        }
    }
}

public class VelocidadOrbital : MonoBehaviour
{
    public float velocidadRotacion;
}

public class VelocidadPropia : MonoBehaviour
{
    public float velocidadRotacionPropia;
}