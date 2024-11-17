    using HeneGames.DialogueSystem;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class TriggerCartel : MonoBehaviour
    {
        [Header("Visual Simb")]
        [SerializeField] private GameObject visualSimbolo;

        [Header("Scene to Load")]
        [SerializeField] private string sceneToLoad;

        [Header("Input Key")]
        [SerializeField] private KeyCode interactKey = KeyCode.E; // Puedes cambiar la tecla en el Inspector

    private bool playerInRange;

        //SE MUESTRA INACTIVA LA SEÑAL AL INICIO DEL JUEGO Y LO OCULTA
        private void Awake()
        {
            playerInRange = false;
            visualSimbolo.SetActive(false);
        }

        //MUESTRA LA SEÑAL SI EL JUGADOR ESTA DENTRO DEL RANGO
        private void Update()
        {
            if (playerInRange)
            {
                visualSimbolo.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    LoadScene();
                }
        }
            else
            {
                visualSimbolo.SetActive(false);
            }
        }

        //DETECTA CUANDO UN COLISIONADOR ENTRA O SALE DEL COLISIONADOR DEL OBJETO
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                playerInRange = false;
            }
        }

    //CARGAR ESCENA DE SISTEMA DE PREGUNTAS
        private void LoadScene()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

}
