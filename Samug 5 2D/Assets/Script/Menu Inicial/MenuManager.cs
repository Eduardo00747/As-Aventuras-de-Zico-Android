using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuSelect;

    public void StartGame()
    {
        // Carrega a cena "Fase 1"
        //SceneManager.LoadScene("Fase 1");
        StartCoroutine(PlayMusicAndLoadScene("Fase 1"));
    }

    public void Options()
    {
        //Botão de configuração 
        //SceneManager.LoadScene("Configuração");
        StartCoroutine(PlayMusicAndLoadScene("Configuração"));
    }
    public void Credits()
    {
        //Botão de configuração 
        //SceneManager.LoadScene("Configuração");
        StartCoroutine(PlayMusicAndLoadScene("Credits"));
    }

    public void QuitGame()
    {
        // Sai do jogo (funciona somente no build executável)
        Application.Quit();
        Debug.Log("Jogo Fechado");
    }

    public void Sair()
    {
        //Caso o jogador esteja na tela de configuração 
        //SceneManager.LoadScene("Menu Inicial");
        StartCoroutine(PlayMusicAndLoadScene("Menu Inicial"));
    }

    IEnumerator PlayMusicAndLoadScene(string sceneName)
    {
        audioSource.PlayOneShot(menuSelect);
        yield return new WaitForSeconds(menuSelect.length);
        SceneManager.LoadScene(sceneName);
    }
}