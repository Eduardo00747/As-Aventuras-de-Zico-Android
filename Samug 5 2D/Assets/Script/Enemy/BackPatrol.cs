using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPatrol : MonoBehaviour
{
    public CacadorController cacadorController;
    public EnemyWaypointChaser enemyWaypointChaser;

    // Chamado quando um Collider entra no Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o Collider que entrou é o "Player"
        if (other.CompareTag("Player"))
        {
            // Desativa o script CacadorController
            cacadorController.enabled = false;

            // Ativa o script EnemyWaypointChaser
            enemyWaypointChaser.enabled = true;
        }
    }

    // Chamado quando um Collider sai do Trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o Collider que saiu é o "Player"
        if (other.CompareTag("Player"))
        {
            // Ativa o script CacadorController
            cacadorController.enabled = true;

            // Desativa o script EnemyWaypointChaser
            enemyWaypointChaser.enabled = false;
        }
    }

    private void OnDisable()
    {
        // Ativa o objeto "BackPatrol" (assumindo que ele seja um filho do inimigo)
        Transform detectTransform = transform.parent.Find("Detect");
        if (detectTransform != null)
        {
            detectTransform.gameObject.SetActive(true);
        }
    }
}