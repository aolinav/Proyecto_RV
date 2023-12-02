using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject GameMenuObject;

    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CloseCanvas()
    {
            GameMenuObject.SetActive(false);
    }
}