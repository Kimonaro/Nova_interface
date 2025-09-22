using UnityEngine;

public class Player : Personagem
{
    private SpriteRenderer sprit;

    public Transform arma;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprit = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arma.rotation.eulerAngles.z > -90 && arma.rotation.eulerAngles.z < 90)
        {
            sprit.flipX = false;
        }

        if (arma.rotation.eulerAngles.z > 90 && arma.rotation.eulerAngles.z < 270)
        {
            sprit.flipX = true;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(getVelocidade() * Time.deltaTime , 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(getVelocidade() * Time.deltaTime , 0, 0);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, getVelocidade() * Time.deltaTime , 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, getVelocidade() * Time.deltaTime, 0);
        }

    }
    
        void OnCollisionEnter2D  (Collision2D other)
        {
            if (other.gameObject.tag == "Inimigo")
            {
                int vida = getVida() - 1;
                setVida(vida);
            }
        }
}
