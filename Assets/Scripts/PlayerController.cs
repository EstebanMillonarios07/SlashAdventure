using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 7f;
    public bool isGrounded = false;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    [SerializeField] LayerMask groundLayer;
    Animator anim;
    Vector2 savePoint; // El lugar al que debe regresar el jugador
    [SerializeField] float RespawnHeight; // La altura de caída; si el jugador alguna vez está por debajo de ella, lo devolveremos al punto de guardado.
    [SerializeField]Animator animEspada;

    [SerializeField] Collider2D espada;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
           transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }

        // Controles de personaje
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);


        // Almacenando el colisionador en una variable separada para facilitar su uso
        Collider2D col = GetComponent<Collider2D>();
        // Creando un área circular debajo de los pies del personaje
        isGrounded = Physics2D.OverlapCircle(transform.position - transform.up * ((col.bounds.extents.y / transform.localScale.y - col.offset.y) * transform.localScale.y), 0.01f, groundLayer);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButton("Fire1"))
        {

            Ataque();
        }
    }

    [SerializeField] float health;
    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Ataque()
    {
        espada.GetComponent<Collider2D>().enabled=true;
        animEspada.SetTrigger("Ataque");

    }

}
