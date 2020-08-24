using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{


    public GameObject bala;
    public GameObject CanoDaBala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if(Input.GetButtonDown("Fire1"))
        {

            Instantiate(bala, CanoDaBala.transform.position, transform.rotation);
        }

        
    }
}
