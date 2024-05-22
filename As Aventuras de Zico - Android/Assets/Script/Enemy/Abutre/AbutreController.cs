using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbutreController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravityIncreased = false;

    // Referência para o componente Animator do inimigo
    //private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Obtenha a referência para o componente Animator do inimigo
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!gravityIncreased && rb.gravityScale == 1f)
        {
            StartCoroutine(StartWavyMovement());
            gravityIncreased = true;
        }
    }

    IEnumerator StartWavyMovement()
    {
        yield return new WaitForSeconds(0.5f);

        // Ative o parâmetro "MorteCav" na animação para executar a animação de morte
        //animator.SetBool("isVoando", true);

        float originalY = transform.position.y;
        float timeElapsed = 0f;
        float amplitude = 0.5f; // Ajuste o valor da amplitude desejada
        float frequency = 0.8f; // Ajuste o valor da frequência desejada

        while (true)
        {
            timeElapsed += Time.deltaTime;
            float newY = originalY + Mathf.Sin(timeElapsed * frequency) * amplitude;
            Vector3 newPosition = new Vector3(transform.position.x - Time.deltaTime, newY, transform.position.z); // Note o sinal negativo aqui
            transform.position = newPosition;

            yield return null;
        }
    }
}
