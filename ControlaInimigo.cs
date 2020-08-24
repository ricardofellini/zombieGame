using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;

    public float Velocidade = 5f;
    private Rigidbody rigidbodyInimigo;
    private Animator animatorInimigo;


    public void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        rigidbodyInimigo = GetComponent<Rigidbody>();
        animatorInimigo = GetComponent<Animator>();


    }


    void Update()
    {




    }

    private void FixedUpdate()
    {

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;


        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbodyInimigo.MoveRotation(novaRotacao);

        if (distancia > 2.5f)
        {

            rigidbodyInimigo.MovePosition(rigidbodyInimigo.position + direcao.normalized * Velocidade * Time.deltaTime);


            animatorInimigo.SetBool("Atacando", false);

        }
        else
        {
            animatorInimigo.SetBool("Atacando", true);

        }

    }

        void AtacaJogador()
        {

        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Vivo = false;

        }


    
}
