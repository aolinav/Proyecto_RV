using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject panel;
    public GameObject principal;

    public void jugar()
    {
        // Aqu� puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        //SceneManager.LoadScene("minijuego");
        panel.SetActive(true);
        principal.SetActive(false);
    }

    public void ajustes()
    {
        // Aqu� puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("Options");
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

    public void naveRotar()
    {
        SceneManager.LoadScene("naveRotar");
    }

    public void naveMover()
    {
        SceneManager.LoadScene("naveMover");
    }

    public void minijuego()
    {
        SceneManager.LoadScene("minijuego");
    }

    public void salir()
    {
        Application.Quit();
    }

    public void volver()
    {
        // Para volver del panel secundario al principal
        panel.SetActive(false);
        principal.SetActive(true);
    }
}
