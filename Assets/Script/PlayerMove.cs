using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocidad;
    public float velocidadMaxima;

    public float salto;
    public bool patasColisionadas = false;

    private Rigidbody2D rBody2D;
    private float horizontal;
    private Animator animaPlayer;

    private bool derecha = true;
    

    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        animaPlayer = GetComponent<Animator>();
    }

    void Update()
    {

        giroX(horizontal);
        animaPlayer.SetFloat("EjeX", Mathf.Abs(rBody2D.velocity.x));
        animaPlayer.SetFloat("EjeY", rBody2D.velocity.y);
        animaPlayer.SetBool("Toca suelo", patasColisionadas);

        patasColisionadas = CheckGround.patasColisionadas;
        if (Input.GetButtonDown("Jump") && patasColisionadas)
        {

            rBody2D.velocity = new Vector2(rBody2D.velocity.x, 0f);
            rBody2D.AddForce(new Vector2(0, salto), ForceMode2D.Impulse);
        }

       
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rBody2D.AddForce(Vector2.right * velocidad * horizontal);

        

        float limiteVelocidad = Mathf.Clamp(rBody2D.velocity.x, -velocidadMaxima, velocidadMaxima);
        rBody2D.velocity = new Vector2(limiteVelocidad, rBody2D.velocity.y);

        
        
    }

    public void giroX(float h)
    {
        if((h > 0 && !derecha) || h < 0 && derecha)
        {
            derecha = !derecha;
            Vector3 escalaGiro = transform.localScale;
            escalaGiro.x = escalaGiro.x * -1;
            transform.localScale = escalaGiro;
        }
    }

    

}
