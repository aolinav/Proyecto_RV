using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    GameController gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameController.GetInstancia();
    }

    // Update is called once per frame
    public void Exit()
    {
        gameManager.ChooselvlScreen();
        gameManager.Pausado = false;
    }
    public void Repeat()
    {
        gameManager.RestartCurrentScene();
        gameManager.Pausado = false;
    }
}
