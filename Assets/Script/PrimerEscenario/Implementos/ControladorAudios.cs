using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ControladorAudios : MonoBehaviour
{
    public static ControladorAudios Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake(){

        if(Instance == null){
            Instance = this;
        }else{
            Debug.Log("Ya existe una instancia de ControladorAudios");
        }
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip audio){
        audioSource.PlayOneShot(audio);
    }
}
