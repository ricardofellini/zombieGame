﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public float velocidade = 20f;
    private Rigidbody rigidbodyBala;

    private void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {


        rigidbodyBala.MovePosition
            (rigidbodyBala.position + transform.forward * velocidade * Time.deltaTime);


    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {


        if(objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);

        }

        Destroy(gameObject);


    }
}
