using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class GameplayMenuManager : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public static GameplayMenuManager instancia;
    GameObject[] pantallas;

    public TextMeshProUGUI cuentaAtras_Text;
    public TextMeshProUGUI ganador_Text;

#endregion
// -----------------------------------------------------------------
#region 2) Funciones Predeterminadas de Unity 
void Awake (){
        instancia = this;

        pantallas = new GameObject[transform.childCount];

        for (int i = 0; i < pantallas.Length; i++)
        {
            pantallas[i] = transform.GetChild(i).gameObject;
        }
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
    public void Boton_Reanudar()
    {
        GameManager.instancia.EstablecerNuevoEstado(EstadosJuego.Jugando);
    }

    public void Boton_Reiniciar()
    {

    }

    public void Boton_Salir()
    {

    }

    public void Actualizar_CuentaAtrasText (string _nuevoTexto)
    {
        cuentaAtras_Text.text = _nuevoTexto;
    }

    public void Actualizar_InfoJuegoFinalizado(Jugadores _ganador)
    {
        ganador_Text.text = _ganador.ToString();
    }

    public void VisibilidadPantalla (int _indice, bool _estado)
    {
        pantallas[_indice].gameObject.SetActive (_estado);
    }
    #endregion
    // -----------------------------------------------------------------

}
