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
    public KeyCode teclaDisparo;
    public KeyCode teclaRecarga;

    public float vida;

    [Header("ARMA")]
    public Rigidbody balaOriginal;
    public Transform origenBalas;
    public int balasActuales;


    float ejeH;
    float velocidad;

    Rigidbody rb;

    bool rotando;
    float dirRotFinal;
    Vector3 posInicial;

    Coroutine cargandoCoro;

#endregion
// -----------------------------------------------------------------
#region 2) Funciones Predeterminadas de Unity 
void Awake (){

        velocidad = 2f;

        vida = 10;
        balasActuales = 5;

        rb = GetComponent<Rigidbody>();
        posInicial = transform.position;


        if (transform.GetSiblingIndex() == 0)
        {
            jugador = Jugadores.Jugador_1;
            teclaSalto = KeyCode.E;
            teclaDisparo = KeyCode.R;
            teclaRecarga = KeyCode.T;
        }

        if (transform.GetSiblingIndex() == 1)
        {
            jugador = Jugadores.Jugador_2;
            teclaSalto = KeyCode.Keypad1;
            teclaDisparo = KeyCode.Keypad2;
            teclaRecarga = KeyCode.Keypad3;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HudManager.instancia.ActualizarVida_Player((int)jugador, vida / 10f);
        HudManager.instancia.ActualizarBalas_Player((int)jugador, balasActuales);
    }

    // Update is called once per frame
    void Update()
    {
        CheckearAccionesJugador();

        RotacionGradual();
    }

    private void FixedUpdate()
    {
        DesplazamientoFisicas();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Balas"))
        {
            PierdeVida(1f);
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Limite"))
        {

            PierdeVida(2f);
            
            rb.velocity = Vector3.zero;
            rb.position = posInicial;
        }
    }
    #endregion
    // -----------------------------------------------------------------
    #region 3) Metodos Originales
    void DesplazamientoFisicas()
    {
        rb.MovePosition(rb.position + Vector3.right * ejeH * velocidad * Time.fixedDeltaTime);
    }

    void CheckearAccionesJugador()
    {
        if (jugador == Jugadores.Jugador_1)
        {
            ejeH = Input.GetAxisRaw("Horizontal_J1");

            if (Input.GetKeyDown(teclaSalto))
            {
                Debug.Log("Salta J1");
                Saltar();
            }

            if (Input.GetKeyDown(teclaRecarga))
            {
                Debug.Log("Recarga J1");
                Recargar();
            }

            if (Input.GetKeyDown(teclaDisparo))
            {
                Debug.Log("Dispara J1");
                Disparar();
            }
        }
        if (jugador == Jugadores.Jugador_2)
        {
            ejeH = Input.GetAxisRaw("Horizontal_J2");

            if (Input.GetKeyDown(teclaSalto))
            {
                Debug.Log("Salta J2");
                Saltar();
            }

            if (Input.GetKeyDown(teclaRecarga))
            {
                Debug.Log("Recarga J2");
                Recargar();
            }

            if (Input.GetKeyDown(teclaDisparo))
            {
                Debug.Log("Dispara J2");
                Disparar();
            }
        }
    }

    void RotacionGradual()
    {
        if (ejeH != 0f)
        {
            rotando = true;
            dirRotFinal = ejeH;
        }

        if (rotando)
        {
            Quaternion _rotActual = transform.rotation;

            Vector3 _dirRotFinal = Vector3.up * (180f - 90f * dirRotFinal);
            Quaternion _rotFinal = Quaternion.Euler(_dirRotFinal);

            Quaternion _rotGradual = Quaternion.RotateTowards(_rotActual, _rotFinal, 720f * Time.deltaTime);
            transform.rotation = _rotGradual;

            if (Vector3.Angle(transform.forward, _dirRotFinal) == 0f) rotando = false;
        }
    }

    void Saltar()
    {
        float _fuerzaSalto = Mathf.Sqrt(1.51f * -2 * (Physics.gravity.y * rb.mass));

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.VelocityChange);
    }

    void Disparar()
    {
        if (balasActuales > 0)
        {
            Rigidbody _clonBala = Instantiate(balaOriginal, origenBalas.position, origenBalas.rotation);
            _clonBala.AddForce(_clonBala.transform.forward * 10f, ForceMode.VelocityChange);

            balasActuales--;
            HudManager.instancia.ActualizarBalas_Player((int)jugador, balasActuales);
        }
    }

    void Recargar()
    {
        Empieza_CargandoCoro();
    }

    public void PierdeVida (float _danno)
    {
        vida -= _danno;
        HudManager.instancia.ActualizarVida_Player((int)jugador, vida / 10f);

        if (vida <= 0f)
        {
            GameplayMenuManager.instancia.Actualizar_InfoJuegoFinalizado(jugador);
            GameManager.instancia.EstablecerNuevoEstado(EstadosJuego.JuegoFinalizado);
        }
    }

    void Empieza_CargandoCoro()
    {
        if (cargandoCoro == null) cargandoCoro = StartCoroutine (CargandoCoro());
    }

    void Termina_CargandoCoro()
    {
        if (cargandoCoro != null)
        {
            StopCoroutine(cargandoCoro);
            cargandoCoro = null;
        }
    }

    IEnumerator CargandoCoro()
    {
        yield return new WaitForSeconds(1f);

        balasActuales = 5;
        HudManager.instancia.ActualizarBalas_Player((int)jugador, balasActuales);

        Termina_CargandoCoro();
    }
    #endregion
    // -----------------------------------------------------------------

}

public enum Jugadores
{
    Jugador_1,
    Jugador_2
}
