using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text puntosTexto;
    public GameObject gameOverPanel;

    public void MostrarGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        puntosTexto.text = "Puntos: " + ControladorPuntos.Instance.PuntosTotales;
    }

    public void ReiniciarNivel()
    {

        // Reiniciar los puntos a 50 cuando se reinicia el nivel
        ControladorPuntos.Instance.ReiniciarPuntos();
        Time.timeScale = 1;

        // Destruir todos los objetos en la escena antes de cambiar a la nueva escena
        DestroyAllObjects();

        SceneManager.LoadScene(1);
    }

    public void IrAlMenuPrincipal()
    {
        ControladorPuntos.Instance.MenuPrincipal();
        Time.timeScale = 1;

        // Destruir todos los objetos en la escena antes de cambiar a la nueva escena
        DestroyAllObjects();

        SceneManager.LoadScene(0);  // Cambiar al menú principal
    }

    private void DestroyAllObjects()
    {
        // Obtener todos los objetos en la escena
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects)
        {
            // Verificar si el objeto tiene el componente LogicaEntreEscenasMenu y no destruirlo
            
        if (obj.GetComponent<LogicaEntreEscenasMenu>() != null || 
            obj.CompareTag("NoDestruir") || 
            obj.name == "ControladorDeOpciones" || 
            obj.name == "Canvas" ||
            obj.name == "Panel Brillo"|| 
            obj.name == "PhotonMono"
            )
        {
            // Si tiene el componente LogicaEntreEscenasMenu, no destruirlo
            continue;
        }

            // Si el objeto es marcado con DontDestroyOnLoad, también se destruirá
            Destroy(obj);
        }
    }
}
