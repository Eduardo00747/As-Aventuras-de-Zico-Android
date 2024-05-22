using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;

    //Variaveis de Audios 
    public AudioSource audioSource; // Adicione esta vari�vel para acessar o componente AudioSource
    public AudioClip jaula; // Adicione esta vari�vel para armazenar o som de ataque

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Obtenha a refer�ncia do componente AudioSource
    }

    void Update()
    {
        // Verifica se o gravityScale atingiu o valor 1
        if (rb.gravityScale == 1 && !isFalling)
        {
            audioSource.PlayOneShot(jaula);
            // Inicia a contagem regressiva para destruir o objeto ap�s 2 segundos
            Invoke("DestruirGaiola", 4f);
            isFalling = true;
        }
    }

    void DestruirGaiola()
    {
        // Destrua o objeto "Gaiola"
        Destroy(gameObject);
    }
}