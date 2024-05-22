using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaliLifeController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão ocorreu com um objeto de tag "CascoBanana"
        if (collision.gameObject.CompareTag("Queda"))
        {
            // Destrua este inimigo
            Destroy(gameObject);
        }
    }
}
