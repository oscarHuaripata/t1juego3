using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    
    private const int Run = 0;
    private const int Jump = 1;
    private const int Dead = 2;
    
    public float velocityX = 5;
    
    private bool estaSaltando = false;
    public float jumpForce = 50;

    private bool isDead = false;
    
    bool active;

    private bool muerteJugador = true;

    //private bool pausar = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead )
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            CambiarAnimacion(Run);
        
            if (Input.GetKeyUp(KeyCode.Space)  && !estaSaltando )
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                CambiarAnimacion(Jump);
                estaSaltando = true;
            }  
        }
        
       
        
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Piso")
            estaSaltando = false;

        if (other.gameObject.CompareTag("Morir"))
        {
            isDead = true;
           

  
           
                CambiarAnimacion(Dead);
                
             


        }
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }

    void muerte()
    {
        muerteJugador = true;
    }
    
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds (2);
    }
}
