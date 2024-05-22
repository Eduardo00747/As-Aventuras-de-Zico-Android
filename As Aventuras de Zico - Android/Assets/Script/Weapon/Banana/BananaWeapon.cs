using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BananaWeapon : MonoBehaviour
{
    // Contagem de Banana
    public TMP_Text bananaScore; // Referência para o objeto de texto "Banana Score"
    public int bananasColetadas = 0; // Contagem de corações coletados, SE FOR QUARDAR O VALOR USAR O STATIC

    //Variaveis de Audios 
    public AudioSource audioSource; // Adicione esta variável para acessar o componente AudioSource
    public AudioClip hearth; // Adicione esta variável para armazenar o som de ataque

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar o objeto de texto com a contagem de corações
        bananaScore.text = " 0";
        audioSource = GetComponent<AudioSource>(); // Obtenha a referência do componente AudioSource

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar se a colisão ocorreu com a tag "Player" ou "Borda"
        if (other.CompareTag("Banana"))
        {

            // Incrementar a contagem de corações coletados
            bananasColetadas++;

            // Atualizar o objeto de texto com a nova contagem de corações
            bananaScore.text = "= " + bananasColetadas.ToString();

            audioSource.PlayOneShot(hearth);
        }
    }
}