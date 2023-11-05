using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Arrastra el componente VideoPlayer aqu� desde el inspector.

    private void Start()
    {
        videoPlayer.loopPointReached += EndOfVideo; // Registra el evento loopPointReached.
    }

    private void EndOfVideo(VideoPlayer vp)
    {
        // Este m�todo se llamar� cuando se alcance el final del video.
        // Aqu� puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("menu");
    }
}