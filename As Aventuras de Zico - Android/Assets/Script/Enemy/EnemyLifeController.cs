using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão ocorreu com um objeto de tag "CascoBanana"
        if (collision.gameObject.CompareTag("CascoBanana"))
        {
            // Destrua este inimigo
            Destroy(gameObject);
        }
    }
}
