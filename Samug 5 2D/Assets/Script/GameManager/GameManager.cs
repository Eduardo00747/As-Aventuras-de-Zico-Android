using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Esta é uma referência estática à instância do GameManager, permitindo que outros scripts acessem facilmente este objeto.


    public int quantidadeVida = 3; // Valor inicial da vida do jogador.

    private void Awake()
    {


        if (instance == null) // Verifica se já existe uma instância do GameManager.
        {
            instance = this; // Se não existir, esta instância se torna a instância única.
            DontDestroyOnLoad(gameObject); // Impede que o objeto GameManager seja destruído ao trocar de cena.
        }
        else
        {
            Destroy(gameObject); // Se já existir uma instância, destrói este objeto para evitar duplicatas.
        }

        // Inscreve o método na chamada de cena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se o objeto foi destruído antes de tentar acessá-lo
        if (this != null)
        {
            // Verifica se a cena carregada é "Menu Inicial"
            if (scene.name == "Menu Inicial")
            {
                // Destroi o objeto ao qual este script está anexado
                Destroy(gameObject);
            }
        }
    }

    public void SetVida(int vida)
    {
        quantidadeVida = vida; // Esta função permite definir a quantidade de vida do jogador.
    }

    public int GetVida()
    {
        return quantidadeVida; // Esta função retorna a quantidade atual de vida do jogador.
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Esta função reinicia a cena atual, o que é útil para reiniciar o jogo.
    }
}