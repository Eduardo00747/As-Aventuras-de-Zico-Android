using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int maxHealth = 100;// Saúde máxima do jogador
    private int currentHealth;// Saúde atual do jogador

    public TMP_Text vidaScore;// Referência ao texto para exibir a quantidade de vidas

    private int vidasRestantes;// Variável para controlar o número de vidas restantes

    public AudioSource audioSource; // Adicione esta variável para acessar o componente AudioSource
    public AudioClip punch; // Adicione esta variável para armazenar o som de ataque

    void Start()
    {
        currentHealth = maxHealth;// Configura a saúde atual para o valor máximo no início
        vidasRestantes = GameManager.instance.GetVida();// Obtém o valor da vida do GameManager
        vidaScore.text = " " + vidasRestantes.ToString(); // Atualiza o texto da quantidade de vidas no UI
        audioSource = GetComponent<AudioSource>(); // Obtenha a referência do componente AudioSource

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;// Reduz a saúde atual do jogador com base no dano recebido

        if (currentHealth <= 0)
        {
            Die();// Se a saúde chegar a zero ou menos, chama a função Die

        }
    }

    public void Die()
    {
        vidasRestantes--;// Subtrai 1 das vidas restantes

        vidaScore.text = " " + vidasRestantes.ToString(); // Atualiza o texto da quantidade de vidas no UI

        audioSource.PlayOneShot(punch);


        if (vidasRestantes > 0)
        {
            GameManager.instance.SetVida(vidasRestantes); // Atualiza o valor da vida no GameManager
            GameManager.instance.ResetGame(); // Reinicia o jogo se ainda houver vidas restantes
        }
        else
        {
            // Se não houver mais vidas restantes, vá para a cena "Game Over"
            SceneManager.LoadScene("Game Over");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo2"))
        {
            TakeDamage(10);// Se colidir com um objeto com a tag "Inimigo", aplique 10 de dano
        }
    }
}
