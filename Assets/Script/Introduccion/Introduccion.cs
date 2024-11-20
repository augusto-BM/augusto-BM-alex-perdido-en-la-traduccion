using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Introduccion : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string siguienteEscena = "PrimerEscenario";  

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();  
        }

        videoPlayer.loopPointReached += terminoVideo;
    }

    void terminoVideo(VideoPlayer vp)
    {

        SceneManager.LoadScene(siguienteEscena);
    }
}
