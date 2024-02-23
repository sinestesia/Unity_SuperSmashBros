using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMenu : MonoBehaviour
{
    Camera cam;
    [SerializeField] Color color;
    [SerializeField]float velocidadCambio;
    [SerializeField] float sentido;

    private void Awake()
    {
        cam = Camera.main;
        sentido = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        color.r = 1;
        color.g = 0.5f;
        color.b = 0;
        color.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (color.g > 1f) {
            sentido = -1f;  
        }
        if (color.g < 0f) {
            sentido = 1f;
        }
        color.g = color.g  + velocidadCambio * sentido;
       
        //Debug.Log("Color g=" + color.g.ToString());
        cam.backgroundColor = color;
       
    }
}
