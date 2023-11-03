using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class BotonPausa : MonoBehaviour
{

    GameController gameManager;


    public AudioMixerSnapshot Nivel;
    public AudioMixerSnapshot Pausado;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameController.GetInstancia();
    }

    public void Pausa()
    {
        gameManager.CambiarPausa();
        //Pausado.TransitionTo(0.1f);

        // Sonido mixer
    }
}
