using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    private EstadosJuego estadoJuego;
    private EstadosJuego estadoAnterior;  
  
    void Awake()
    {
        //Singleton que controla que exista una y solo una instancia
        //Permite que el GameManager navegue entre escenas
        if (instancia == null)
        {
            instancia = this;
            //Evita la destrucción del GameManager al cambiar de escena
            DontDestroyOnLoad(gameObject);
            //Activa Otros Gestores
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        EstablecerEstadoJuego(EstadosJuego.MenuInicio);
    }

    public void EstablecerEstadoJuego(EstadosJuego nuevoEstadoJuego) {
        estadoAnterior = estadoJuego;
        estadoJuego = nuevoEstadoJuego;
        switch (estadoJuego)
        {
            case EstadosJuego.MenuInicio:
                //Muestra el menu

                break;
            case EstadosJuego.EnTransicion:
                //Muestra transicion
                //TransitionManager.instancia.Transicion_SeMuestraEmpieza();

                break;
            case EstadosJuego.CuentaAtras:

                break;
            case EstadosJuego.Gameplay:

                break;
            case EstadosJuego.JuegoPausado:

                break;
            case EstadosJuego.JuegoFinalizado:

                break;
            case EstadosJuego.TiempoAgotado:

                break;
        }
    }


    public enum EstadosJuego
    { 
       MenuInicio,
       EnTransicion,
       CuentaAtras,
       Gameplay,
       JuegoPausado,
       JuegoFinalizado,
       TiempoAgotado
    }

}

