using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainPanel : MonoBehaviour
{
    [Header("Opciones")]
    public Slider volumenFX;
    public Slider volumenMaster;
    public Toggle mute;

    public Slider volumenFXGL;
    public Slider volumenMasterGL;
    public Toggle muteGL;
    public AudioMixer mixer;
    public float lastVolume;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject levelSelectPanel;


    private void Awake(){
        //Cargar volumen de los audios
        volumenFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumenMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        volumenFXGL.onValueChanged.AddListener(ChangeVolumeFX);
        volumenMasterGL.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void SetMute(){

        if(mute.isOn || muteGL.isOn){
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }else{
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }
    
    public void BorrarPanelActivo(){
        settingsPanel.SetActive(false);
    }




    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
    }

    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVolumeMaster(float volume)
    {
        mixer.SetFloat("VolMaster", volume);
    }  

    public void ChangeVolumeFX(float volume)
    {
        mixer.SetFloat("VolFX", volume);  
    } 




}
