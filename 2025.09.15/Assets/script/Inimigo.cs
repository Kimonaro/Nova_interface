using System;
using UnityEngine;

public class Inimigo : Personagem
{
    [SerializeField] public Transform posicaoDoPlayer;
    [SerializeField] private int dano = 1;

    public void setDano(int dano)
    {
        this.dano = dano;
    }

    public int getDano()
    {
        return this.dano;
    }


// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (posicaoDoPlayer == null)
        {
           posicaoDoPlayer = GameObject.Find("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (posicaoDoPlayer != null)
        {
            Debug.Log("Pocição do player");
            transform.position = Vector3.MoveTowards(transform.position, posicaoDoPlayer.position,getVelocidade() * Time.deltaTime);
        }
        
        if (getVida() <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //causa dano ao player
         if (collision.gameObject.CompareTag( "Player"))
         {
             int novaVida = collision.gameObject.GetComponent<Personagem>().getVida() - getDano();
             collision.gameObject.GetComponent<Personagem>().setVida(novaVida);
             
             gameObject.SetActive(false);
         }
    }
}
