using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Rigidbody _rb;

    public Camera camaraObjetivo;
    
    private int Vida;

    private int Olor;

    private bool EscudoDisponible;

    private bool LlamadoDisponible;

    private bool DobleSaltoDisponible;

    private bool HormonasDisponible;

    private Animator animador;

    public GameObject sprite;

    public float velocidadSaltoInicial = 500;

    public float velocidadHorizontal = 1;

    public bool enPiso = false;

    public bool enemigo=true;

    //public SpriteRenderer sprite;

    //public Transform deteccionSuelo;

    public int saltoMax = 1;
    
    public int saltoActual = 0;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        animador=sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        animador.SetBool("se_mueve",false);
        animador.SetBool("en_piso",enPiso);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Saltar();

        } else if (Input.GetKey(KeyCode.A)) {
            //sprite.SpriteRenderer.flipX=false;
            animador.SetBool("se_mueve",true);
            transform.Translate(-0.1f * velocidadHorizontal,0f,0f);

        } else if (Input.GetKey(KeyCode.D)) {
            //sprite.SpriteRenderer.flipX=true;
            animador.SetBool("se_mueve",true);
            transform.Translate(0.1f * velocidadHorizontal,0f,0f);

        } else if (Input.GetKey(KeyCode.W)){
            animador.SetBool("se_mueve",true);
            transform.Translate(0f,0f,0.1f * velocidadHorizontal);

        }else if (Input.GetKey(KeyCode.S)) {
            animador.SetBool("se_mueve",true);
            transform.Translate(0f,0f,-0.1f * velocidadHorizontal);

        }else if (Input.GetKey(KeyCode.E)) {
            Debug.Log("Activo mi escudo");

        }else if (Input.GetKey(KeyCode.Q)) {
            Debug.Log("Utilizo mis hormonas");
        }

    }

    public void Saltar()
    {
        if (saltoActual < saltoMax ){
            _rb.AddForce(Vector3.up * velocidadSaltoInicial);
            enPiso = false;
            saltoActual += 1;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        enPiso = true;
        saltoActual = 0; 
    }
}
