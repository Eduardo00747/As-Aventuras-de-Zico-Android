using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBanana : MonoBehaviour
{
    //Variaveis para a arma do personagem 
    public BananaWeapon bananaWeapon; // Refer�ncia ao script BananaWeapon
    public GameObject cascoBananaPrefab; // Refer�ncia ao prefab do CascoBanana que voc� deseja instanciar.
    //public PlayerController playerController; // Refer�ncia ao script PlayerController
    public TouchController touchController; //Referencia ao script Touch Controller

    //Variaveis de Audios 
    public AudioSource audioSource; // Adicione esta vari�vel para acessar o componente AudioSource
    public AudioClip hurt; // Adicione esta vari�vel para armazenar o som de ataque

    //Variaveis para o aumento de velocidade do personagem 
    private float originalMoveSpeed = 0.9f; // Vari�vel para armazenar a velocidade original do jogador
    private bool isSpeedChanged = false; // Vari�vel para controlar se a velocidade foi alterada

    private Animator animator;


    void Start()
    {
        originalMoveSpeed = touchController.moveSpeed; // Salve a velocidade original do jogador
        //originalMoveSpeed = playerController.moveSpeed; // Salve a velocidade original do jogador
        audioSource = GetComponent<AudioSource>(); // Obtenha a refer�ncia do componente AudioSource
        animator = GetComponentInParent<Animator>();

    }

    void Update()
    {
        // Verifica se a tecla "K" foi pressionada e se o jogador tem pelo menos uma banana.
        if (Input.GetKeyDown(KeyCode.K) && bananaWeapon.bananasColetadas > 0)
        {
            // Reduz a contagem de bananas em 1.
            bananaWeapon.bananasColetadas--;

            // Atualiza o objeto de texto com a nova contagem de bananas.
            bananaWeapon.bananaScore.text = "= " + bananaWeapon.bananasColetadas.ToString();

            // Instancia o prefab do CascoBanana na posi��o atual deste objeto.
            Instantiate(cascoBananaPrefab, transform.position, Quaternion.identity);

            audioSource.PlayOneShot(hurt);
            animator.SetBool("IsRuning", true);

            // Altera a velocidade do jogador para 1.3
            //playerController.moveSpeed = 1.3f;
            touchController.moveSpeed = 1.3f;

            // Define a vari�vel de controle para indicar que a velocidade foi alterada
            isSpeedChanged = true;

            // Chame uma fun��o para reverter a velocidade ap�s 2 segundos
            StartCoroutine(ResetSpeedAfterDelay(2.0f));

        }
    }

    IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Verifique se a velocidade foi alterada
        if (isSpeedChanged)
        {
            // Reverta a velocidade para o valor original
            //playerController.moveSpeed = originalMoveSpeed;
            touchController.moveSpeed = originalMoveSpeed;
            animator.SetBool("IsRuning", false);

            // Redefina a vari�vel de controle
            isSpeedChanged = false;
        }
    }

    public void Banana()
    {
        // Verifica se a tecla "K" foi pressionada e se o jogador tem pelo menos uma banana.
        if (bananaWeapon.bananasColetadas > 0)
        {
            // Reduz a contagem de bananas em 1.
            bananaWeapon.bananasColetadas--;

            // Atualiza o objeto de texto com a nova contagem de bananas.
            bananaWeapon.bananaScore.text = "= " + bananaWeapon.bananasColetadas.ToString();

            // Instancia o prefab do CascoBanana na posi��o atual deste objeto.
            Instantiate(cascoBananaPrefab, transform.position, Quaternion.identity);

            audioSource.PlayOneShot(hurt);
            animator.SetBool("IsRuning", true);

            // Altera a velocidade do jogador para 1.3
            //playerController.moveSpeed = 1.3f;
            touchController.moveSpeed = 1.3f;

            // Define a vari�vel de controle para indicar que a velocidade foi alterada
            isSpeedChanged = true;

            // Chame uma fun��o para reverter a velocidade ap�s 2 segundos
            StartCoroutine(ResetSpeedAfterDelay(2.0f));

        }
    }
}
