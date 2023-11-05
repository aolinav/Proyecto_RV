using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Arrastra el componente VideoPlayer aquí desde el inspector.

    private void Start()
    {
        videoPlayer.loopPointReached += EndOfVideo; // Registra el evento loopPointReached.
    }

    private void EndOfVideo(VideoPlayer vp)
    {
        // Este método se llamará cuando se alcance el final del video.
        // Aquí puedes cargar la nueva escena. Reemplaza "NombreDeLaNuevaEscena" por el nombre de tu nueva escena.
        SceneManager.LoadScene("menu");
    }
}