using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrucciones : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;

    public void objetivosbtnD()
    {
        // Para volver del panel secundario al principal
        p1.SetActive(false);
        p2.SetActive(true);
    }
    public void objetivosbtnI()
    {
        // Para volver del panel secundario al principal
        p1.SetActive(false);
        p3.SetActive(true);
    }

    public void movimientobtnD()
    {
        // Para volver del panel secundario al principal
        p2.SetActive(false);
        p3.SetActive(true);
    }
    public void movimientobtnI()
    {
        // Para volver del panel secundario al principal
        p2.SetActive(false);
        p1.SetActive(true);
    }

    public void monedasbtnD()
    {
        // Para volver del panel secundario al principal
        p3.SetActive(false);
        p1.SetActive(true);
    }
    public void monedasbtnI()
    {
        // Para volver del panel secundario al principal
        p3.SetActive(false);
        p2.SetActive(true);
    }

}
