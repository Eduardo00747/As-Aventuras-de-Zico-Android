using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Velocidade de movimento do inimigo
    public float moveDuration = 3.0f; // Duração de cada movimento

    private bool movingRight = true; // Controla a direção do movimento
    private float timer = 0.0f; // Timer para controlar a duração do movimento

    private GameObject player; // Referência ao jogador
    private bool isChasing = false; // Indica se o inimigo está perseguindo o jogador

    private Rigidbody2D rb;

    private void Start()
    {
        // Encontra o jogador usando a tag "Player"
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Se o inimigo estiver perseguindo o jogador
        if (isChasing && player != null)
        {
            // Calcula a direção do movimento em direção ao jogador
            Vector3 movementDirection = (player.transform.position - transform.position).normalized;

            // Calcula o movimento baseado na direção e velocidade
            Vector3 movement = movementDirection * moveSpeed * Time.deltaTime;

            // Move o inimigo
            transform.Translate(movement);
        }
        else
        {
            // Atualiza o timer
            timer += Time.deltaTime;

            // Verifica se o tempo de movimento foi atingido
            if (timer >= moveDuration)
            {
                // Alterna a direção do movimento
                movingRight = !movingRight;
                timer = 0.0f; // Reinicia o timer
            }

            // Calcula a direção do movimento
            Vector3 movementDirection = movingRight ? Vector3.right : Vector3.left;

            // Calcula o movimento baseado na direção e velocidade
            Vector3 movement = movementDirection * moveSpeed * Time.deltaTime;

            // Move o inimigo
            transform.Translate(movement);
        }
    }

    // Função chamada quando o objeto filho "Detect" é destruído
    public void StartChasing()
    {
        isChasing = true;
        moveSpeed = 1f;
        rb.gravityScale = 0; // Reativa a gravidade ao sair da escada

    }

    // Função chamada quando o objeto filho "Detect" é ativado ou desativado
    public void StartChasing(bool chase)
    {
        isChasing = chase;
        moveSpeed = 1f;
        rb.gravityScale = 1; // Reativa a gravidade ao sair da escada
    }
}