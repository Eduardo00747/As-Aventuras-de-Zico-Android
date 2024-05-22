using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Esta � uma refer�ncia est�tica � inst�ncia do GameManager, permitindo que outros scripts acessem facilmente este objeto.


    public int quantidadeVida = 3; // Valor inicial da vida do jogador.

    private void Awake()
    {


        if (instance == null) // Verifica se j� existe uma inst�ncia do GameManager.
        {
            instance = this; // Se n�o existir, esta inst�ncia se torna a inst�ncia �nica.
            DontDestroyOnLoad(gameObject); // Impede que o objeto GameManager seja destru�do ao trocar de cena.
        }
        else
        {
            Destroy(gameObject); // Se j� existir uma inst�ncia, destr�i este objeto para evitar duplicatas.
        }

        // Inscreve o m�todo na chamada de cena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se o objeto foi destru�do antes de tentar acess�-lo
        if (this != null)
        {
            // Verifica se a cena carregada � "Menu Inicial"
            if (scene.name == "Menu Inicial")
            {
                // Destroi o objeto ao qual este script est� anexado
                Destroy(gameObject);
            }
        }
    }

    public void SetVida(int vida)
    {
        quantidadeVida = vida; // Esta fun��o permite definir a quantidade de vida do jogador.
    }

    public int GetVida()
    {
        return quantidadeVida; // Esta fun��o retorna a quantidade atual de vida do jogador.
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Esta fun��o reinicia a cena atual, o que � �til para reiniciar o jogo.
    }
}