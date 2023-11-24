using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacadorchase : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Velocidade de movimento do inimigo
    private Rigidbody2D rb; // Refer�ncia ao Rigidbody2D
    private SpriteRenderer spriteRenderer; // Refer�ncia ao Sprite Renderer

    public CacadorController cacadorController; // Referencia ao script do Ca�ador 
    public Detect detect;

    //Variaveis de anima��o
    private Animator animator;
    private bool canMove = true; // Vari�vel para controlar se o inimigo pode se mover


    void Start()
    {
        // Obt�m a refer�ncia ao SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Obt�m a refer�ncia ao Rigidbody2D

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove)
        {
            animator.SetBool("isRun", true);

            // Movimento para a esquerda ou direita com base no valor de flipX
            float horizontalMovement = spriteRenderer.flipX ? -moveSpeed : moveSpeed;
            Vector3 movement = new Vector3(horizontalMovement * Time.deltaTime, 0, 0);
            transform.Translate(movement);

            // Congela a posi��o Y do Rigidbody
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            // Define FlipX com base na dire��o do movimento
            spriteRenderer.flipX = (horizontalMovement < 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colis�o ocorreu com um objeto de tag "CascoBanana"
        if (collision.gameObject.CompareTag("Parede"))
        {
            cacadorController.enabled = true;
            detect.enabled = true;

        }

        // Verifica se o objeto tem a tag "Gaiola"
        if (collision.collider.CompareTag("Gaiola"))
        {
            // Define a vari�vel para parar o movimento
            canMove = false;
            //animator.SetBool("isRun", false);
            animator.SetBool("IsDown", true);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica se a colis�o deixou de ocorrer com um objeto de tag "Gaiola"
        if (collision.collider.CompareTag("Gaiola"))
        {
            // Define a vari�vel para permitir o movimento novamente
            canMove = true;
            animator.SetBool("IsDown", false);
        }
    }
}