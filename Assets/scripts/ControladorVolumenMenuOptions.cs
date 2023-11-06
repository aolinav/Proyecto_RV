using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorVolumenMenuOptions : MonoBehaviour
{
    private menuOptions instancia;
    public Toggle FX;
    public Toggle Musica;
    public Slider VolumenGlobal;
    public Slider VolumenFX;
    public Dropdown CalidadGrafica;
    public Toggle PantallaCompleta;

    // Start is called before the first frame update
    void Start()
    {
        CalidadGrafica.value = QualitySettings.GetQualityLevel();
        instancia = menuOptions.getInstancia();
        if (instancia != null)
        {
            VolumenFX.value = instancia.GetFXvolume();
            VolumenGlobal.value = AudioListener.volume;
            FX.isOn = !instancia.GetFX();
            Musica.isOn = !instancia.GetMusica();
            PantallaCompleta.isOn = Screen.fullScreen;
        }
        
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        instancia.volumenFX = PlayerPrefs.GetFloat("volumeFx");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityLevel"));
        if(PlayerPrefs.GetInt("Musica") == 1)
        {
            instancia.Musica = true;

        }
        if(PlayerPrefs.GetInt("Musica") == 0)
        {
            instancia.Musica = false;

        }
        if (PlayerPrefs.GetInt("Fx") == 1)
        {
            instancia.FX = true;

        }
        if (PlayerPrefs.GetInt("Fx") == 0)
        {
            instancia.FX = false;

        }
        if (PlayerPrefs.GetInt("PantallaCompleta") == 1)
        {
            Screen.fullScreen = true;

        }
        if (PlayerPrefs.GetInt("PantallaCompleta") == 0)
        {
            Screen.fullScreen = false;

        }
        

    }

    public void SetMusica(bool value)
    {
        int aux;
        instancia.Musica = !value;
        if (value == true)
        {
            aux = 1;
            PlayerPrefs.SetInt("Musica", aux);

        }
        else
        {
            aux = 0;
            PlayerPrefs.SetInt("Musica", aux);

        }
    }


    public void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }

    public void SetFXVolume(float value)
    {
        instancia.volumenFX = value;
        PlayerPrefs.SetFloat("volumeFx", value);

    }
    public void SetFX(bool value)
    {
        int aux;
        instancia.FX = !value;
        if (value == true)
        {
            aux = 1;
            PlayerPrefs.SetInt("Fx", aux);

        }
        else
        {
            aux = 0;
            PlayerPrefs.SetInt("Fx", aux);

        }
    }
    public void SetPantallaCompleta(bool value)
    {
        int aux;
        Screen.fullScreen = value;
        if (value == true)
        {
            aux = 1;
            PlayerPrefs.SetInt("PantallaCompleta", aux);

        }
        else
        {
            aux = 0;
            PlayerPrefs.SetInt("PantallaCompleta", aux);

        }
    }
    public void SetCalidadGraficos(int value)
    {
        QualitySettings.SetQualityLevel(value);
        PlayerPrefs.SetInt("QualityLevel", value);

    }
}
