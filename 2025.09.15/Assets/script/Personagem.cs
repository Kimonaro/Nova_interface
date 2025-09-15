using UnityEngine;

public class Personagem : MonoBehaviour
{ 
    [SerializeField] public int Vida;
   [SerializeField] public int Velocidade; 
   [SerializeField] public int Energia;
    
    public void setVida(int vida)
    { 
        this.Vida = vida;
    }

    public int getVida()
    {
        return this.Vida;
    }

    public void setVelocidade(int velocidade)
    {
        this.Velocidade = velocidade;
    }

    public int getVelocidade()
    {
        return this.Velocidade;
    }

    public void setEnergia(int energia)
    {
        this.Energia = energia;
    }

    public int getEnergia()
    {
        return this.Energia;
    }
    
}
