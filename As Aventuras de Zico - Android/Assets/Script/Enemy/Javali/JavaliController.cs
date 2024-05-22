using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaliController : MonoBehaviour
{

    public float moveSpeed = 5f; // Velocidade de movimento

    // Update is called once per frame
    void Update()
    {
        // Movimento para a esquerda
        Vector3 movement = new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);
    }
}
