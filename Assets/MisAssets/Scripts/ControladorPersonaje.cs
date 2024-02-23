using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class ControladorPersonaje : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public Jugadores jugador;

    public KeyCode teclaSalto;
    public KeyCode teclaRecarga;

    public float ejeH;
    public float velocidad;

#endregion
// -----------------------------------------------------------------
#region 2) Funciones Predeterminadas de Unity 
    void Awake (){

	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador == Jugadores.Jugador_1)
        {
            ejeH = Input.GetAxisRaw("Horizontal_J1");

            if (Input.GetKeyDown(teclaSalto))
            {
                Debug.Log("Salta J1");
            }

            if (Input.GetKeyDown(teclaRecarga))
            {
                Debug.Log("Recarga J1");
            }
        }
        if (jugador == Jugadores.Jugador_2)
        {
            ejeH = Input.GetAxisRaw("Horizontal_J2");

            if (Input.GetKeyDown(teclaSalto))
            {
                Debug.Log("Salta J2");
            }

            if (Input.GetKeyDown(teclaRecarga))
            {
                Debug.Log("Recarga J2");
            }
        }

        transform.Translate (transform.forward * ejeH * velocidad * Time.deltaTime, Space.World);

    }
#endregion
// -----------------------------------------------------------------
#region 3) Metodos Originales

#endregion
// -----------------------------------------------------------------

}

public enum Jugadores
{
    Jugador_1,
    Jugador_2
}
