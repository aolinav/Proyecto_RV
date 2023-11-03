using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompleteWindow : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolucionesDropdown;

    //Lista de resoluciones
    Resolution[] resoluciones;

    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        RevisarResoluciones();
        
    }

    public void ToggleFullScreen(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }


    public void RevisarResoluciones(){
        //Obtenemos todas las resoluciones disponibles
        resoluciones = Screen.resolutions;
        //Limpiamos el dropdown
        resolucionesDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int indiceResolucionActual = 0;

        for(int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                indiceResolucionActual = i;
            }
        }

        resolucionesDropdown.AddOptions(opciones);
        resolucionesDropdown.value = indiceResolucionActual;
        resolucionesDropdown.RefreshShownValue();
        resolucionesDropdown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    
    }

    public void CambiarResolucion(int indiceResolucionActual)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropdown.value);
        Resolution resolucionSeleccionada = resoluciones[indiceResolucionActual];
        Screen.SetResolution(resolucionSeleccionada.width, resolucionSeleccionada.height, Screen.fullScreen);
    }

}

