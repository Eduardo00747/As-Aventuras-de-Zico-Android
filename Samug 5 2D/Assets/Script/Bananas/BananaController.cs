using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar se a colisão ocorreu com a tag "Player" ou "Borda"
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto que possui este script (o Machado)
            Destroy(gameObject);
        }
    }
}