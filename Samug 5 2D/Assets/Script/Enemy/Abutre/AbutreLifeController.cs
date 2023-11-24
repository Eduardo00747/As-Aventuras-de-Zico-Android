using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbutreLifeController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colis�o ocorreu com um objeto de tag "CascoBanana"
        if (collision.gameObject.CompareTag("Parede"))
        {
            // Destrua este inimigo
            Destroy(gameObject);
        }
    }
}
