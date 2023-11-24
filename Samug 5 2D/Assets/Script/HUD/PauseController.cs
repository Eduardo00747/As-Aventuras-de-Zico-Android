using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    private bool isPaused = false; // Uma variável que controla se o jogo está pausado ou não.
    public GameObject pauseObject; // Referência ao objeto "Pause" na HUD.

    //Variaveis de Audios 
    public AudioSource audioSource; // Adicione esta variável para acessar o componente AudioSource
    public AudioClip pause; // Adicione esta variável para armazenar o som de ataque

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Obtenha a referência do componente AudioSource

        if (pauseObject != null)
        {
            pauseObject.SetActive(false); // Garanta que o objeto "Pause" esteja inativo no início.
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Verifica se a tecla "Enter" foi pressionada.
        {
            TogglePause(); // Chama a função TogglePause para pausar ou despausar o jogo.
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused; // Inverte o estado de pausa (se estava pausado, despausa, e vice-versa).

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa o jogo definindo o timeScale para zero. Isso congela todos os objetos que dependem do timeScale para sua animação ou movimento.
            if (pauseObject != null)
            {
                pauseObject.SetActive(true); // Ativa o objeto "Pause" na HUD quando o jogo está pausado.
                audioSource.PlayOneShot(pause);
            }
        }
        else
        {
            Time.timeScale = 1f; // Retoma o jogo definindo o timeScale de volta para 1. Isso faz com que o jogo retome seu ritmo normal.
            if (pauseObject != null)
            {
                pauseObject.SetActive(false); // Desativa o objeto "Pause" na HUD quando o jogo é retomado.
                audioSource.PlayOneShot(pause);
            }
        }
    }
}
