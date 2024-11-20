using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;

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

        IrAlMenuPrincipal();
    }

    public void IrAlMenuPrincipal()
    {
        ControladorPuntos.Instance.MenuPrincipal();
        Time.timeScale = 1;

        // Destruir todos los objetos en la escena antes de cambiar a la nueva escena
        DestroyAllObjectsMenu();

        SceneManager.LoadScene(0);  // Cambiar al menú principal
    }

    private void DestroyAllObjectsMenu()
    {
                // Obtener todos los objetos en la escena
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects)
        {
            
        if (obj.name == "PhotonMono")
        {
            // Si tiene el componente LogicaEntreEscenasMenu, no destruirlo
            continue;
        }

            // Si el objeto es marcado con DontDestroyOnLoad, también se destruirá
            Destroy(obj);
        }

    }
}
