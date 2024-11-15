using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;//Para Toggle pantalla completa

using TMPro; //Para Dropdown para resoluciones

public class CodigoPantallaCompleta : MonoBehaviour
{
    //Para pantalla completa
    public Toggle toggle; 

    //Para resolucion
    public TMP_Dropdown resolucionesDropdown;
    Resolution[] resoluciones;


    // Start is called before the first frame update
    void Start()
    {
        //Para pantalla completa
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        //Para resoluciones
        RevisionResoluciones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Funcion para activar o desactivar pantalla completa
    public void ActivarPantallaCompleta(bool pantallaCompleta){
        Screen.fullScreen = pantallaCompleta;
    } 

    public void RevisionResoluciones(){
        resoluciones = Screen.resolutions;
        resolucionesDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolucionesDropdown.AddOptions(opciones);
        resolucionesDropdown.value = resolucionActual;
        resolucionesDropdown.RefreshShownValue();

        //Para guardar la resolucion seleccionada si se cierra la aplicacion 
        resolucionesDropdown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void CambiarResolucion(int indiceResolucion){

        //Para guardar la resolucion seleccionada si se cierra la aplicacion se guarda en el registro de windows
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropdown.value);

        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
