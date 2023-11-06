using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject panel;
    public void jugar()
    {
        // Aquí puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        //SceneManager.LoadScene("minijuego");
        panel.SetActive(true);
    }

    public void ajustes()
    {
        // Aquí puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("ajustes");
    }

    public void video()
    {
        // Aquí puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("video");
    }

    public void instrucciones()
    {
        // Aquí puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
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
