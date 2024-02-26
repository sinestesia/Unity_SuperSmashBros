using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class HudManager : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public static HudManager instancia;

    public GameObject infoPlayers;

    public Image vida_J1;
    public TextMeshProUGUI balas_J1;

    public Image vida_J2;
    public TextMeshProUGUI balas_J2;

    #endregion
    // -----------------------------------------------------------------
    #region 2) Funciones Predeterminadas de Unity 
    void Awake (){

        instancia = this;


        VisibilidadInfoPlayers(false);
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
    public void ActualizarVida_Player(int _indicePlayer, float _vida)
    {
        if (_indicePlayer == 0)
        {
            vida_J1.fillAmount = _vida;
        }

        if (_indicePlayer == 1)
        {
            vida_J2.fillAmount = _vida;
        }
    }

    public void VisibilidadInfoPlayers(bool _estado)
    {
        infoPlayers.SetActive(_estado);
    }

    public void ActualizarBalas_Player (int _indicePlayer, int _balas)
    {
        if (_indicePlayer == 0)
        {
            balas_J1.text = _balas.ToString();
        }

        if (_indicePlayer == 1)
        {
            balas_J2.text = _balas.ToString();
        }
    }
    #endregion
    // -----------------------------------------------------------------

}
