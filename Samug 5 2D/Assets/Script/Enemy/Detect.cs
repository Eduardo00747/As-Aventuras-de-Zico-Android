using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public CacadorController cacadorController; // Referencia ao script do Ca�ador 

    public Cacadorchase cacadorchase;


    // Chamado quando um Collider entra no Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o Collider que entrou � o "Player"
        if (other.CompareTag("Player"))
        {
            cacadorController.enabled = false;
            cacadorchase.enabled = true;

        }
    }
}