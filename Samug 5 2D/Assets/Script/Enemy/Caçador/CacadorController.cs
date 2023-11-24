using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacadorController : MonoBehaviour
{
    public Transform[] waypoints; // Insira os Waypoints aqui
    public float moveSpeed = 2.0f;
    public float collisionDistance = 0.1f; // Dist�ncia m�nima para considerar uma colis�o

    private Transform currentWaypoint;
    private int currentWaypointIndex = 0;
    public Cacadorchase cacadorchase;

    private SpriteRenderer spriteRenderer; // Refer�ncia ao Sprite Renderer

    //Variaveis de anima��o
    private Animator animator;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            currentWaypoint = waypoints[0];
        }

        // Obt�m a refer�ncia ao SpriteRenderer
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
            // Colis�o com o Waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            currentWaypoint = waypoints[currentWaypointIndex];
        }

        // Define FlipX com base na dire��o do movimento
        spriteRenderer.flipX = (direction.x < 0);

        // Se o jogador n�o estiver dentro da zona de detec��o, o inimigo n�o est� correndo
        animator.SetBool("isRun", false);
    }
}