using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacadorchase : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Velocidade de movimento do inimigo
    private Rigidbody2D rb; // Referência ao Rigidbody2D
    private SpriteRenderer spriteRenderer; // Referência ao Sprite Renderer

    public CacadorController cacadorController; // Referencia ao script do Caçador 
    public Detect detect;

    //Variaveis de animação
    private Animator animator;
    private bool canMove = true; // Variável para controlar se o inimigo pode se mover


    void Start()
    {
        // Obtém a referência ao SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Obtém a referência ao Rigidbody2D

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

            // Congela a posição Y do Rigidbody
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            // Define FlipX com base na direção do movimento
            spriteRenderer.flipX = (horizontalMovement < 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão ocorreu com um objeto de tag "CascoBanana"
        if (collision.gameObject.CompareTag("Parede"))
        {
            cacadorController.enabled = true;
            detect.enabled = true;

        }

        // Verifica se o objeto tem a tag "Gaiola"
        if (collision.collider.CompareTag("Gaiola"))
        {
            // Define a variável para parar o movimento
            canMove = false;
            //animator.SetBool("isRun", false);
            animator.SetBool("IsDown", true);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica se a colisão deixou de ocorrer com um objeto de tag "Gaiola"
        if (collision.collider.CompareTag("Gaiola"))
        {
            // Define a variável para permitir o movimento novamente
            canMove = true;
            animator.SetBool("IsDown", false);
        }
    }
}