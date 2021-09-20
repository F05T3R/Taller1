using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float velocidadMovimiento = 2;

    public float salto = 3;

    private Rigidbody2D rbody2D;


    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rbody2D.velocity = new Vector2(velocidadMovimiento, rbody2D.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            rbody2D.velocity = new Vector2(-velocidadMovimiento, rbody2D.velocity.y);
        }
        else
        {
            rbody2D.velocity = new Vector2(0, rbody2D.velocity.y);
        }
    }
}
