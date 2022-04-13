using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzquierdaDerecha : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
    public float velocityx = 5;
    public float jumpForce = 8;
    
    private bool estaSaltando = false;
    public bool puedeSaltar = true;

    public bool saltaIzquierda = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if ( puedeSaltar  && !estaSaltando  )
        {
            rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
        
            rb.velocity = new Vector2(velocityx, rb.velocity.y);
            sr.flipX = false;
            estaSaltando = true;
            puedeSaltar = false;

            saltaIzquierda = true;
            Invoke("enfriamiento_salta", 1.0f);
            //StartCoroutine("Esperar");
            
          
        }

        if (saltaIzquierda && !estaSaltando)
        {
            rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
            rb.velocity = new Vector2(- velocityx, rb.velocity.y);
            
            estaSaltando = true;
            puedeSaltar = false; 
            sr.flipX = true;
        }
        
      
    }


    IEnumerator Esperar()
    {
        yield return new WaitForSeconds (1);
    }
    void enfriamiento_salta()
    {
        puedeSaltar = true;
    }

    void saltaDerecha()
    {
        saltaIzquierda = true;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Piso")
            estaSaltando = false;
    }
}
