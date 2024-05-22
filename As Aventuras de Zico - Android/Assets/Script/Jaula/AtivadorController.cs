using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorController : MonoBehaviour
{
    public GameObject paredeJaula1;
    public GameObject paredeJaula2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo2"))
        {

            Rigidbody2D parentRigidbody = transform.parent.GetComponent<Rigidbody2D>();
            if (parentRigidbody != null)
            {
                parentRigidbody.gravityScale = 1f;
            }

            // Ative os objetos "ParedeJaula 1" e "ParedeJaula 2"
            if (paredeJaula1 != null)
            {
                paredeJaula1.SetActive(true);
            }
            if (paredeJaula2 != null)
            {
                paredeJaula2.SetActive(true);
            }

        }
    }
}