using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variaveis Controller
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Força do pulo
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    //Variaveis de som
    public AudioSource audioSource; // Adicione esta variável para acessar o componente AudioSource
    public AudioClip jump; // Adicione esta variável para armazenar o som de ataque

    //Outras Variaveis 
    private SpriteRenderer spriteRenderer;

    public GameObject cipo; //Referencia ao Objeto Cipó
    private bool isPressingVerticalKey;

    //public GameObject escadaEnemyCima; // Referência ao objeto "Escada Enemy Cima"
    //public GameObject escadaEnemyBaixo; // Referência ao objeto "Escada Enemy Baixo"

    //Variaveis Escada
    public float climbSpeed = 3f; // Velocidade de subida na escada
    [SerializeField] private bool isClimbing; // Indica se o jogador está subindo na escada

    //Variaveis de animação
    private Animator animator;

    //Referencia as armas 
    public GameObject DropBanana; // Referência ao objeto HitBoxAtaque

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // Obtenha a referência do componente AudioSource

        // Obtém a referência do objeto "Throw Cruz"
        DropBanana = transform.Find("Drop Banana").gameObject;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Configura a variável de animação "isWalk" no Animator
        bool isWalk = Mathf.Abs(horizontalInput) > 0.1f;

        animator.SetBool("isWalk", isWalk);

        isPressingVerticalKey = Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;

        if (isPressingVerticalKey)
        {
            // Ativa o objeto "Cipo"
            cipo.SetActive(true);
        }
        else
        {
            // Desativa o objeto "Cipo"
            cipo.SetActive(false);
        }


        // Verificar se o jogador está se movendo para a esquerda e inverter o sprite
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        // Verificar se o jogador está se movendo para a direita e restaurar a orientação do sprite
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }


        // Configura o parâmetro "isJump" na animação
        animator.SetBool("isJump", !isGrounded); // Inverte o estado do pulo (true quando não estiver no chão)

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audioSource.PlayOneShot(jump);
        }

        if (isClimbing)
        {
            ClimbLadder();
        }
    }

    private void LateUpdate()
    {
        // Verifique o valor de spriteRenderer.flipX
        float dropBananaOffsetX = spriteRenderer.flipX ? 0.41f : -0.55f;

        // Defina a posição X da DropBanana com base no valor calculado
        Vector3 dropBananaPos = DropBanana.transform.localPosition;
        dropBananaPos.x = dropBananaOffsetX;
        DropBanana.transform.localPosition = dropBananaPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0; // Desativa a gravidade enquanto estiver na escada
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            animator.SetBool("EstaSubindo", false);
            animator.SetBool("isWalk", true);
            rb.gravityScale = 1; // Reativa a gravidade ao sair da escada
        }
    }

    // Adicione um novo método para a movimentação vertical
    public void ClimbLadder()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
            animator.SetBool("EstaSubindo", true);
            animator.SetBool("isWalk", false);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}