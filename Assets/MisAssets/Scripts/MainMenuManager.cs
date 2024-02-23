using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
     public void Boton_Jugar()
    {
        Debug.Log("Se hace click en JUGAR");
        GameManager.instancia.EstablecerEstadoJuego(GameManager.EstadosJuego.EnTransicion);
    }
    public void Boton_Salir()
    {
        Debug.Log("Se hace click en SALIR");
        Application.Quit();
    }
}
