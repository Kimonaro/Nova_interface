using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform SaidaDoTiro;
    public GameObject bala;
    public float intervaloDoDisparo = 0.5f;
    private float tempoDisparo = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoDisparo <= 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("bala disparada");
            GameObject bala = Instantiate(this.bala, SaidaDoTiro.position, SaidaDoTiro.rotation);
            
            tempoDisparo = intervaloDoDisparo;
        }
        if (tempoDisparo > 0)
        {
            tempoDisparo -= Time.deltaTime;
        }
    }
}
