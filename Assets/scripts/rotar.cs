using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour
{
    public float velocidadDeRotacion = 0.5f;
    public Transform pivote;

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(pivote.transform.position, Vector3.up, velocidadDeRotacion);
    }
}
