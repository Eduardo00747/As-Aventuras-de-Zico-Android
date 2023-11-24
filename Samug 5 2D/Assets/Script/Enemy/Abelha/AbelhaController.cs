using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbelhaController : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Velocidade de movimento da abelha
    public float verticalDistance = 2.0f; // Distância vertical entre subir e descer
    private bool movingUp = true; // Controla a direção de movimento


    private float currentVerticalDistance = 0.0f;

    void Update()
    {
        // Move a abelha verticalmente
        float verticalMovement = moveSpeed * Time.deltaTime;

        if (movingUp)
        {
            transform.Translate(Vector3.up * verticalMovement);
            currentVerticalDistance += verticalMovement;

            if (currentVerticalDistance >= verticalDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * verticalMovement);
            currentVerticalDistance -= verticalMovement;

            if (currentVerticalDistance <= 0)
            {
                movingUp = true;
            }
        }
    }
}
