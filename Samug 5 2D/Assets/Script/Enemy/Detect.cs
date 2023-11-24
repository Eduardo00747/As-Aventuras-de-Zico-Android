using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public CacadorController cacadorController; // Referencia ao script do Caçador 

    public Cacadorchase cacadorchase;


    // Chamado quando um Collider entra no Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o Collider que entrou é o "Player"
        if (other.CompareTag("Player"))
        {
            cacadorController.enabled = false;
            cacadorchase.enabled = true;

        }
    }
}