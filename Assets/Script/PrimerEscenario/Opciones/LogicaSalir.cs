using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaSalir : MonoBehaviour
{
    public void SalirEscena()
    {
        // Destruir todos los objetos en la escena antes de cambiar a la nueva escena
        DestroyAllObjects();

        // Regresamos al menu principal
        SceneManager.LoadScene(0);
    }

    private void DestroyAllObjects()
    {
        // Obtener todos los objetos en la escena
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects)
        {
            // Si el objeto es marcado con DontDestroyOnLoad, también se destruirá
            Destroy(obj);
        }
    }
}
