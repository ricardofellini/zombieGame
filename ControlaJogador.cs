using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10.0f;
    Vector3 direcao;
    public LayerMask mascaraChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;

    public void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }




    void Update()
    {

       float eixoX = Input.GetAxis("Horizontal");
       float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);        



        if(direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Movendo", true);
        }
        else
        {
            animatorJogador.SetBool("Movendo", false);

        }
        if (Vivo == false)
        {


            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Scene_1");

            }

        }



    }

    private void FixedUpdate()
    {

        rigidbodyJogador.MovePosition
            (rigidbodyJogador.position +
            (direcao * Velocidade * Time.deltaTime));




        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impact;

        if(Physics.Raycast(raio, out impact, 100, mascaraChao ))
        {

            Vector3 posicaoMiraJogador = impact.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;


            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            rigidbodyJogador.MoveRotation(novaRotacao);


        }
    }
}
