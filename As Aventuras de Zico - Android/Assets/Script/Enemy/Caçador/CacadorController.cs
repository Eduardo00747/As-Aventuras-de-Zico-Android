using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacadorController : MonoBehaviour
{
    public Transform[] waypoints; // Insira os Waypoints aqui
    public float moveSpeed = 2.0f;
    public float collisionDistance = 0.1f; // Distância mínima para considerar uma colisão

    private Transform currentWaypoint;
    private int currentWaypointIndex = 0;
    public Cacadorchase cacadorchase;

    private SpriteRenderer spriteRenderer; // Referência ao Sprite Renderer

    //Variaveis de animação
    private Animator animator;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            currentWaypoint = waypoints[0];
        }

        // Obtém a referência ao SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentWaypoint != null)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        cacadorchase.enabled = false;
        Vector3 direction = (currentWaypoint.position - transform.position).normalized;
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        float distance = Vector3.Distance(transform.position, currentWaypoint.position);

        if (distance < collisionDistance)
        {
            // Colisão com o Waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            currentWaypoint = waypoints[currentWaypointIndex];
        }

        // Define FlipX com base na direção do movimento
        spriteRenderer.flipX = (direction.x < 0);

        // Se o jogador não estiver dentro da zona de detecção, o inimigo não está correndo
        animator.SetBool("isRun", false);
    }
}