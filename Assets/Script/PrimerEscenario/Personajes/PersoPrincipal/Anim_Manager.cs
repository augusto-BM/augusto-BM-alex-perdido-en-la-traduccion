using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Manager : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //ANIMACION  PARA CORRER TECLA FLECHA DEERECHA O LA TECLA D
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("Correr", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Correr", false);
        }

        //ANIMACION  PARA CORRER TECLA FLECHA IZQUIERDA O LA TECLA A
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Correr", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Correr", false);
        }

        //ANIMACION  PARA SALTAR TECLA FLECHA ARRIBA
        if (Input.GetKeyDown(KeyCode.UpArrow) )
        {
            anim.SetBool("Saltar", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("Saltar", false);
        }


    }
}
