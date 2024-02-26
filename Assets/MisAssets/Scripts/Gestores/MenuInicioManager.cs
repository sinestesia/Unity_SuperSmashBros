using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class MenuInicioManager : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public static MenuInicioManager instancia;
    #endregion
    // -----------------------------------------------------------------
    #region 2) Funciones Predeterminadas de Unity 
    void Awake (){
        instancia = this;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    // -----------------------------------------------------------------
    #region 3) Metodos Originales
    public void Boton_Jugar()
    {
        GameManager.instancia.EstablecerNuevoEstado(EstadosJuego.CuentaAtras);
    }

    public void Boton_Salir()
    {
        Application.Quit();
    }
    #endregion
    // -----------------------------------------------------------------    
}
