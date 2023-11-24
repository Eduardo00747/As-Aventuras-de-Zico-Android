using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TineController : MonoBehaviour
{
    public float timeRemaining = 10f; // Tempo inicial em segundos
    public TMP_Text timerText; // Refer�ncia ao objeto de texto
    public LifeController lifeController; // Refer�ncia ao GameManager

    void Start()
    {
        UpdateTimerText();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Subtrai o tempo que passou desde o �ltimo quadro
            UpdateTimerText();
        }
        else
        {
            timeRemaining = 0; // Define o tempo restante como zero
            SceneManager.LoadScene("Fim");
        }
    }

    void UpdateTimerText()
    {
        // Formate o texto com um zero � esquerda para n�meros menores que 10
        timerText.text = " " + string.Format("{0:00}", Mathf.RoundToInt(timeRemaining));
    }

}