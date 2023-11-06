using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuOptions : MonoBehaviour
{
    private static menuOptions instancia;
    public float volumenFX=1;
    public bool FX=true;
    public bool Musica = true;

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

    void Update()
    {
        if (!Musica)
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("MusicaUI"))
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("MusicaUI"))
            {
                item.SetActive(true);
            }
        }
    }

    public bool GetMusica()
    {
        return Musica;
    }

    public static menuOptions getInstancia()
    {
        return instancia;
    }

    public float GetFXvolume()
    {
        return volumenFX;
    }
    public bool GetFX()
    {
        return FX;
    }

    
}
