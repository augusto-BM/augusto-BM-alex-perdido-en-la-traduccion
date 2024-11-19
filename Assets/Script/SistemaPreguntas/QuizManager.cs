using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI ScoreTxt2;
    public TextMeshProUGUI ScoreTxt3;


    public AudioClip correctAnswerSound; // Sonido para respuesta correcta
    public AudioClip wrongAnswerSound;   // Sonido para respuesta incorrecta
    private AudioSource audioSource;

    public int pointsPerCorrectAnswer = 10;  // Puntos por respuesta correcta
    public int pointsPerWrongAnswer = 5;    // Puntos que se restan por respuesta incorrecta
    public int ScoreP;
  

    int TotalQuestions = 0;
    public int Score;
    private void Start()
    {
        TotalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>(); // Referencia al AudioSource
        // Inicializar ScoreP con los puntos actuales del ControladorPuntos
        if (ControladorPuntos.Instance != null)
        {
            ScoreP = ControladorPuntos.Instance.PuntosTotales;
            UpdateScoreUI(); // Actualizar UI con los puntos iniciales
        }
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);

        ScoreTxt.text = Score + "/" + TotalQuestions;
        // Enviar los puntos al ControladorPuntos
        if (ControladorPuntos.Instance != null)
        {
            // Si los puntos llegaron a 0, reiniciar los puntos del controlador
            if (ScoreP <= 0)
            {
                ControladorPuntos.Instance.ReiniciarPuntos();
            }
            else
            {
                ControladorPuntos.Instance.SumarPuntos(ScoreP - ControladorPuntos.Instance.PuntosTotales);
            }
        }
        
       
    }

    public void Correct_P()
    {
        ScoreP += pointsPerCorrectAnswer; // Sumar puntos por respuesta correcta
        Score += 1;
        audioSource.PlayOneShot(correctAnswerSound); // Reproducir sonido correcto
        UpdateScoreUI();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void Wrong()
    {
        //Cuando la pregunta es incorrecta
        ScoreP -= pointsPerWrongAnswer; // Restar puntos por respuesta incorrecta
        // Verificar si los puntos llegan a 0 o menos
        if (ScoreP <= 0)
        {
            ScoreP = 0;
            UpdateScoreUI();
            GameOver(); // Llamar a GameOver si los puntos llegan a 0
            return; // Salir del método para no generar más preguntas
        }
        audioSource.PlayOneShot(wrongAnswerSound); // Reproducir sonido incorrecto
        UpdateScoreUI();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void UpdateScoreUI()
    {
        //Actualiza los puntos
        ScoreTxt2.text = ScoreP.ToString();//convierte el int en string para poder mostrar el puntaje
        ScoreTxt3.text = ScoreP.ToString();
    }


    void SetAnswers()
    {
        
        for (int i = 0; i < options.Length; i++)
        {
            if (i < QnA[currentQuestion].Answers.Length) // Verifica que el índice esté dentro del rango
            {

                options[i].GetComponent<AnswerScript>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

                if (QnA[currentQuestion].CorrectAnswer == i + 1)
                {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;
                }
            }
            else
            {
                // Oculta el botón si no hay suficientes respuestas para esta pregunta
                options[i].SetActive(false);
            }
        }

    }
   

    void generateQuestion() 
    {

        if (QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            // Mostrar un mensaje de finalización del quiz en consola.
            Debug.LogWarning("No hay preguntas disponibles en la lista QnA.");
            GameOver();

        }

    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }


}
