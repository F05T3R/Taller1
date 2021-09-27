
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int contadorMonedas = 0;
    [Header("MONEDAS")]
    [SerializeField] private GameObject moneda;
    [SerializeField]
    private Sprite unaMoneda, dosMonedas, tresMonedas, cuatroMonedas, cincoMonedas, seisMonedas, sieteMonedas, ochoMonedas, nueveMonedas,
        diezMonedas, onceMonedas;


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

    private void BarraVida(int saludJ)
    {


    }

    public void giroX(float h)
    {
        if ((h > 0 && !derecha) || h < 0 && derecha)
        {
            derecha = !derecha;
            Vector3 escalaGiro = transform.localScale;
            escalaGiro.x = escalaGiro.x * -1;
            transform.localScale = escalaGiro;
        }
    }
    private void UIcuentaMonedas(int dinero)
    {

        if (dinero == 1) moneda.GetComponent<Image>().sprite = unaMoneda;
        if (dinero == 2) moneda.GetComponent<Image>().sprite = dosMonedas;
        if (dinero == 3) moneda.GetComponent<Image>().sprite = tresMonedas;
        if (dinero == 4) moneda.GetComponent<Image>().sprite = cuatroMonedas;
        if (dinero == 5) moneda.GetComponent<Image>().sprite = cincoMonedas;
        if (dinero == 6) moneda.GetComponent<Image>().sprite = seisMonedas;
        if (dinero == 7) moneda.GetComponent<Image>().sprite = sieteMonedas;
        if (dinero == 8) moneda.GetComponent<Image>().sprite = ochoMonedas;
        if (dinero == 9) moneda.GetComponent<Image>().sprite = nueveMonedas;
        if (dinero == 10) moneda.GetComponent<Image>().sprite = diezMonedas;
        if (dinero == 11) moneda.GetComponent<Image>().sprite = onceMonedas;

        contadorMonedas++;


    }
}