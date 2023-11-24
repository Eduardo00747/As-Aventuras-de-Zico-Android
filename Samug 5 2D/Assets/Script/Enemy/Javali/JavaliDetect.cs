using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaliDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Obtém o componente JavaliController do objeto pai
            JavaliController javaliController = transform.parent.GetComponent<JavaliController>();

            // Verifica se o componente foi encontrado
            if (javaliController != null)
            {
                // Ativa o script do JavaliController
                javaliController.enabled = true;
            }

            Destroy(gameObject);
        }
    }
}