using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public Color startColor;



    private void Start()
    {
        startColor = GetComponent<Image>().color;   
    }
    public void Answer()
    {
        if (isCorrect)
        {
            //GetComponent<Image>().color = Color.green;
            Debug.Log("Respuesta Correcta");
            quizManager.Correct_P();
        }
        else
        {
            //GetComponent<Image>().color = Color.red;
            Debug.Log("Respuesta Incorrecta");
            quizManager.Wrong();

        }
    }
}
