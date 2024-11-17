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
            ControladorPuntos.Instance.SumarPuntos(ScoreP);
        }
        // Esperar un poco antes de cambiar de escena
        StartCoroutine(CambiarEscenaConDelay());
    }

    private IEnumerator CambiarEscenaConDelay()
    {
        yield return new WaitForSeconds(5f); // Espera 2 segundos
        SceneManager.LoadScene("PrimerEscenario"); // Reemplaza con el nombre de tu escena
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
        if (ScoreP < 0) ScoreP = 0; // Asegurarse de que el puntaje no sea negativo
        audioSource.PlayOneShot(wrongAnswerSound); // Reproducir sonido incorrecto
        UpdateScoreUI();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void UpdateScoreUI()
    {
        ScoreTxt2.text = ScoreP.ToString();//convierte el int en string para poder mostrar el puntaje
    }


    void SetAnswers()
    {
        
        for (int i = 0; i < options.Length; i++)
        {
            if (i < QnA[currentQuestion].Answers.Length) // Verifica que el índice esté dentro del rango
            {
                //options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
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
