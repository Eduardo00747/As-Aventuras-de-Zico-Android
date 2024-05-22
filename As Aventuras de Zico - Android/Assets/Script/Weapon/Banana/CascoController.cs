using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CascoController : MonoBehaviour
{
    public float tempoParaDestruir = 3.0f; // O tempo em segundos antes do objeto ser destru�do

    // Start is called before the first frame update
    void Start()
    {
        // Chama a fun��o Destroy ap�s o tempo especificado
        Destroy(gameObject, tempoParaDestruir);
    }
}