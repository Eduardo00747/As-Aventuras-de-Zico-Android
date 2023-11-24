using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private int auxDirecaoX; // Dire��o horizontal
    private int auxJump;
    private float jumpForce = 3f; // For�a do pulo
    private bool canJump;    // Indica se o jogador pode pular
    public float moveSpeed;

    private Rigidbody2D rb; // Refer�ncia ao Rigidbody2D do personagem

                            //Variaveis de som
    public AudioSource audioSource; // Adicione esta vari�vel para acessar o componente AudioSource
    public AudioClip jump; // Adicione esta vari�vel para armazenar o som de ataque

    private Animator animator;
    //Outras Variaveis 
    private SpriteRenderer spriteRenderer;

    public GameObject cipo; //Referencia ao Objeto Cip�
    public GameObject DropBanana; // Refer�ncia ao objeto HitBoxAtaque
    public DropBanana dropBanana; // Script Banana

    private bool isPressingVerticalKey; // Adicionada para verificar se o jogador est� tocando verticalmente
    private bool isPressingVerticalbaixo; // Adicionada para verificar se o jogador est� tocando verticalmente
    private bool isClimbing;
    public float climbSpeed = 3f; // Adicione esta vari�vel para a velocidade de subida na escada

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.9f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // Obtenha a refer�ncia do componente AudioSource

        // Obt�m a refer�ncia do objeto "Throw Cruz"
        DropBanana = transform.Find("Drop Banana").gameObject;

        // Obt�m a refer�ncia do objeto "DropBanana"
        dropBanana = transform.Find("Drop Banana").GetComponent<DropBanana>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalk", false);

        // Ativa ou desativa o objeto "Cipo" com base na vari�vel de controle
        cipo.SetActive(isPressingVerticalKey || isPressingVerticalbaixo);

        if (auxDirecaoX != 0)
        {
            transform.Translate(moveSpeed * Time.deltaTime * auxDirecaoX, 0, 0);
            animator.SetBool("isWalk", true);
        }

        // Verifica se o jogador est� na escada e se est� pressionando para cima ou para baixo
        if ((isPressingVerticalKey || isPressingVerticalbaixo) && isClimbing)
        {
            // Adiciona l�gica para a movimenta��o vertical para cima ou para baixo
            float verticalInput = isPressingVerticalKey ? 1 : -1;
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
        }

        // Ativa ou desativa o objeto "Cipo" com base na vari�vel de controle

        if (canJump && auxJump != 0) // Verifica se pode pular e se o comando de pulo foi acionado
        {
            //Aqui � a l�gica para a movimenta��o vertical 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJump", true);
            canJump = false; // Desativa o pulo at� que o jogador toque no ch�o novamente
            audioSource.PlayOneShot(jump);
        }

        if (auxDirecaoX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (auxDirecaoX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void LateUpdate()
    {
        // Verifique o valor de spriteRenderer.flipX
        float dropBananaOffsetX = spriteRenderer.flipX ? 0.41f : -0.55f;

        // Defina a posi��o X da DropBanana com base no valor calculado
        Vector3 dropBananaPos = DropBanana.transform.localPosition;
        dropBananaPos.x = dropBananaOffsetX;
        DropBanana.transform.localPosition = dropBananaPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            animator.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            animator.SetBool("EstaSubindo", true);
            rb.gravityScale = 0; // Desativa a gravidade enquanto estiver na escada
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            animator.SetBool("EstaSubindo", false);
            rb.gravityScale = 1; // Reativa a gravidade ao sair da escada
        }
    }

    public void TouchHorizontal(int direcao)
    {
        auxDirecaoX = direcao;
    }

    public void TouchVerticalCIma()
    {
        isPressingVerticalKey = true;
    }

    public void TouchVerticalBaixo()
    {
        isPressingVerticalbaixo = true;
    }

    public void ReleaseVerticalKey()
    {
        isPressingVerticalKey = false;
        isPressingVerticalbaixo = false;
    }

    public void TouchJump(int direcaojump)
    {
        auxJump = direcaojump;
    }

    public void Banana()
    {
        // Chame o m�todo Banana do script DropBanana
        dropBanana.Banana();
    }
}
