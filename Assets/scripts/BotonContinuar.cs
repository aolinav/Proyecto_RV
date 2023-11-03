using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class BotonContinuar : MonoBehaviour
    {

        GameController gameManager;

        // Start is called before the first frame update
        void Start()
        {
            gameManager = GameController.GetInstancia();
        }

        public void Continuar()
        {
            gameManager.Pausado = false;
            
        }
    }

