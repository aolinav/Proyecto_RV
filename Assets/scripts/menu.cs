using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void jugar()
    {
        // Aqu� puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("minijuego");
    }

    public void ajustes()
    {
        // Aqu� puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("ajustes");
    }

    public void video()
    {
        // Aqu� puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("video");
    }

    public void instrucciones()
    {
        // Aqu� puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("instrucciones");
    }

    public void menu_principal()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void salir()
    {
        Application.Quit();
    }
}
