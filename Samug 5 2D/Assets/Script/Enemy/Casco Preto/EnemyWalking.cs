using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] waypoints; // Insira os Waypoints aqui

    private Transform currentWaypoint;
    private bool isMoving = true;

    public float minDistanceToWaypoint = 0.1f; // Distância mínima para considerar que alcançou o waypoint

    private SpriteRenderer spriteRenderer; // Referência ao Sprite Renderer

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtenha a referência ao Sprite Renderer

        if (waypoints.Length > 0)
        {
            GetClosestWaypoints();
        }
        else
        {
            // Se não houver Waypoints definidos, pare o movimento.
            isMoving = false;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsWaypoint();
        }
    }

    private void MoveTowardsWaypoint()
    {
        if (currentWaypoint == null)
        {
            GetClosestWaypoints();
            return;
        }

        Vector2 direction = (currentWaypoint.position - transform.position).normalized;
        Vector2 movement = direction * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Verifica se o inimigo está próximo o suficiente do Waypoint atual
        float distance = Vector2.Distance(transform.position, currentWaypoint.position);

        if (distance < minDistanceToWaypoint)
        {
            // Se estiver perto o suficiente, escolha um próximo Waypoint com base nos três mais próximos
            GetClosestWaypoints();
        }

        // Define FlipX com base na direção do movimento
        spriteRenderer.flipX = (direction.x < 0);
    }

    private void GetClosestWaypoints()
    {
        Transform[] closestWaypoints = new Transform[3];

        // Encontra os três waypoints mais próximos
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (closestWaypoints[0] == null || Vector2.Distance(transform.position, waypoints[i].position) < Vector2.Distance(transform.position, closestWaypoints[0].position))
            {
                closestWaypoints[2] = closestWaypoints[1];
                closestWaypoints[1] = closestWaypoints[0];
                closestWaypoints[0] = waypoints[i];
            }
            else if (closestWaypoints[1] == null || Vector2.Distance(transform.position, waypoints[i].position) < Vector2.Distance(transform.position, closestWaypoints[1].position))
            {
                closestWaypoints[2] = closestWaypoints[1];
                closestWaypoints[1] = waypoints[i];
            }
            else if (closestWaypoints[2] == null || Vector2.Distance(transform.position, waypoints[i].position) < Vector2.Distance(transform.position, closestWaypoints[2].position))
            {
                closestWaypoints[2] = waypoints[i];
            }
        }

        // Escolhe aleatoriamente um dos três waypoints mais próximos
        int randomIndex = Random.Range(0, 3);
        currentWaypoint = closestWaypoints[randomIndex];
    }
}
