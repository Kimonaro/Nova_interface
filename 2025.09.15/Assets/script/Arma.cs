using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform SaidaDoTiro;
    public GameObject bala;
    public float intervaloDoDisparo = 0.5f;
    
    private float tempoDoDisparo = 0;
    private Camera camera;

    public GameObject cursor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float camDis = camera.transform.position.y - transform.position.y;
        
        Vector3 mouse = camera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2 (mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        transform.rotation =  Quaternion.AngleAxis( angle, Vector3.forward);
       
        Debug.Log("Angilo: "+angle);
        
        cursor.transform.position = new Vector3(mouse.x, mouse.y, cursor.transform.position.z);
        
        Debug.DrawLine(transform.position, mouse , Color.red);
        
        if (tempoDoDisparo <= 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("bala disparada");
            GameObject b = Instantiate (this.bala, SaidaDoTiro.position, SaidaDoTiro.rotation) as GameObject;
            
            tempoDoDisparo = intervaloDoDisparo;
        }
        if (tempoDoDisparo > 0)
        {
            tempoDoDisparo -= Time.deltaTime;
        }
    }
}
