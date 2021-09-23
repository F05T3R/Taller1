using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosVida : MonoBehaviour
{
    public float health;
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            if(health <= 0)
            {
                
            }
        }
    }
}
