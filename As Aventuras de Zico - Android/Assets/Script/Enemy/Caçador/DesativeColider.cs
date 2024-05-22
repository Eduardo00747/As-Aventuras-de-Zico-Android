using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativeColider : MonoBehaviour
{
    //Variaveis de animação
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Escada"))
        {
            animator.SetBool("Subindo", true);

            // Desativa os Box Colliders 2D dos objetos filho
            BoxCollider2D[] colliders = GetComponentsInChildren<BoxCollider2D>();
            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Escada"))
        {

            animator.SetBool("Subindo", false);

            // Ativa os Box Colliders 2D dos objetos filho novamente
            BoxCollider2D[] colliders = GetComponentsInChildren<BoxCollider2D>();
            foreach (var collider in colliders)
            {
                collider.enabled = true;
            }
        }
    }
}
