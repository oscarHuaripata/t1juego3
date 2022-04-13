using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueSaltar : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
    public float velocityy = 5;
    public float jumpForce = 4;
    // Start is called before the first frame update
    
    private bool estaSaltando = false;
    public bool puedeSaltar = true;

   // private float tiempo = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeSaltar  && !estaSaltando )
        {
            rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
        
            estaSaltando = true;
            puedeSaltar = false;
        }


       Invoke("enfriamiento_salta", 1.9f);
        //rb.velocity = new Vector2(rb.velocity.x, velocityy);


    }

    void enfriamiento_salta()
    {
        puedeSaltar = true;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Piso")
            estaSaltando = false;
    }
}
