using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private int dano = 1;
    [SerializeField]private float velocidade = 1.5f;
    
    private Renderer rend;
    
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
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidade * Time.deltaTime, 0, 0);

        if (!rend.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            //Causa dano ao inimigo
            int novaVida = collision.gameObject.GetComponent<Personagem>().getVida() - getDano();
            collision.gameObject.GetComponent<Personagem>().setVida(novaVida);
            
        }

        gameObject.SetActive(false);
    }
}
