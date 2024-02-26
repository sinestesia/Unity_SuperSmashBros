using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class GameManager : MonoBehaviour
{

// -----------------------------------------------------------------
#region 1) Definicion de Variables
    public static GameManager instancia;

    public EstadosJuego estadoPrevio;
    public EstadosJuego estadoActual;

    Coroutine corrutina_CuentaAtras;
#endregion
// -----------------------------------------------------------------
#region 2) Funciones Predeterminadas de Unity 
void Awake (){

        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

        }else Destroy (gameObject);
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (estadoActual == EstadosJuego.Jugando) EstablecerNuevoEstado(EstadosJuego.JuegoPausado);
            else if (estadoActual == EstadosJuego.JuegoPausado) EstablecerNuevoEstado(EstadosJuego.Jugando);
        }
    }
#endregion
// -----------------------------------------------------------------
#region 3) Metodos Originales
    public void EstablecerNuevoEstado (EstadosJuego _nuevoEstado)
    {
        estadoPrevio = estadoActual;
        estadoActual = _nuevoEstado;

        string _mensaje = string.Format("estado GAME MANAGER : {0} {1} {2}", "<color=yellow>", estadoActual.ToString(), "</color>");
        Debug.Log(_mensaje);

        switch (estadoActual)
        {
            case EstadosJuego.MenuInicial:

                Time.timeScale = 1f;

                break;
            case EstadosJuego.CuentaAtras:

                Time.timeScale = 1f;

                if (estadoPrevio == EstadosJuego.MenuInicial)
                {
                    SceneManager.LoadScene(1);
                    Empezar_CuentaAtras();

                }

                break;
            case EstadosJuego.Jugando:

                Time.timeScale = 1f;

                HudManager.instancia.VisibilidadInfoPlayers(true);
                break;
            case EstadosJuego.JuegoPausado:

                Time.timeScale = 0f;

                HudManager.instancia.VisibilidadInfoPlayers(false);
                break;
            case EstadosJuego.JuegoFinalizado:

                Time.timeScale = 0f;

                HudManager.instancia.VisibilidadInfoPlayers(false);
                GameplayMenuManager.instancia.VisibilidadPantalla(1, true);
                break;
        }
    }

    void Empezar_CuentaAtras()
    {
        if (corrutina_CuentaAtras == null) corrutina_CuentaAtras = StartCoroutine(Corrutina_CuentaAtras());
    }

    void Terminar_CuentaAtras()
    {
        if (corrutina_CuentaAtras != null)
        {
            StopCoroutine(corrutina_CuentaAtras);
            corrutina_CuentaAtras = null;
        }
    }

  IEnumerator Corrutina_CuentaAtras() {

        yield return new WaitForSeconds(1f);

        int _pasos = 3;

        GameplayMenuManager.instancia.VisibilidadPantalla(2, true);
        GameplayMenuManager.instancia.Actualizar_CuentaAtrasText(string.Empty);

        while (_pasos > -1)
        {
            if (_pasos > 0)
            {
                GameplayMenuManager.instancia.Actualizar_CuentaAtrasText(_pasos.ToString());
                Debug.Log("Partida empieza en: " + _pasos);
            }
            else
            {
                GameplayMenuManager.instancia.Actualizar_CuentaAtrasText("¡YA!");
                Debug.Log("¡YA!");
            }
            yield return new WaitForSeconds(1f);
            _pasos--;
        }

        GameplayMenuManager.instancia.VisibilidadPantalla(2, false);

        Terminar_CuentaAtras();
        EstablecerNuevoEstado(EstadosJuego.Jugando);
    }
    #endregion
    // -----------------------------------------------------------------

}

public enum EstadosJuego
{
    Ninguno,
    MenuInicial,
    CuentaAtras,
    Jugando,
    JuegoPausado,
    JuegoFinalizado
}