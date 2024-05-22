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
        StartCoroutine(PlayMusicAndLoadScene("Abertura"));
    }

    public void Options()
    {
        //Bot�o de configura��o 
        //SceneManager.LoadScene("Configura��o");
        StartCoroutine(PlayMusicAndLoadScene("Configura��o"));
    }
    public void Credits()
    {
        //Bot�o de configura��o 
        //SceneManager.LoadScene("Configura��o");
        StartCoroutine(PlayMusicAndLoadScene("Credits"));
    }

    public void QuitGame()
    {
        // Sai do jogo (funciona somente no build execut�vel)
        Application.Quit();
        Debug.Log("Jogo Fechado");
    }

    public void Sair()
    {
        //Caso o jogador esteja na tela de configura��o 
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