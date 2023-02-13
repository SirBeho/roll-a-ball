using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hay que agregar la libreria
using UnityEngine.UI;


public class JugadorController : MonoBehaviour
{

    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public AudioClip moneda, ganar;
    private AudioSource sonido;
    public Text textoGanar;
    public Text textoContador;

    public GameObject btn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sonido = GetComponent<AudioSource>();

        contador = 0;
        textoGanar.text = "";
        setTextoContador();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad  );
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Coleccionable"))
        {
            //desactiva el objeto coleccoable con el que colicione
            other.gameObject.SetActive(false);
            //suma la cantidad de objetos
            contador += 1;
            setTextoContador();
            sonido.PlayOneShot(moneda, 1.0f);
        }
    }
    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
            btn.gameObject.SetActive(true);
            sonido.PlayOneShot(ganar, 0.8f);
        }
    }

}