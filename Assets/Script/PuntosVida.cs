using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosVida : MonoBehaviour
{
    public int contadorCorazon = 6;
    [Header("CORAZONES")]
    [SerializeField] private GameObject corazon;
    [SerializeField]
    private Sprite seisCorazones, cincoCorazones,  cuatroCorazones,
        tresCorazones, dosCorazones, unCorazon, ceroCorazones;



    private bool tocando = false;

    private void tocado(float posX)
    {
        if (!tocando)
        {
            if (contadorCorazon > 1)
            {
                barraCorazon(contadorCorazon);
            }
            else
            {
                muertePlayer();
            }
        }
    }

    private void barraCorazon(int salud) 
    {
        if (salud == 5) corazon.GetComponent<Image>().sprite = cincoCorazones;
        if (salud == 4) corazon.GetComponent<Image>().sprite = cuatroCorazones;
        if (salud == 3) corazon.GetComponent<Image>().sprite = tresCorazones;
        if (salud == 2) corazon.GetComponent<Image>().sprite = dosCorazones;
        if (salud == 1) corazon.GetComponent<Image>().sprite = unCorazon;
        if (salud == 0) corazon.GetComponent<Image>().sprite = ceroCorazones;
    }

    private void muertePlayer()
    {
        corazon.GetComponent<Image>().sprite = ceroCorazones;
        Debug.Log("Player Damaged");
        Destroy(corazon.gameObject);
    }

    
}
