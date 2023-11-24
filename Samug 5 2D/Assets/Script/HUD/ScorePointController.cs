using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePointController : MonoBehaviour
{
    public TMP_Text scoreText; // Referência ao objeto de texto
    public int score = 0; // Pontuação atual

    // Função para adicionar pontos
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        // Salve a pontuação atual nos PlayerPrefs
        PlayerPrefs.SetInt("Pontuacao", score);
    }

    // Função para atualizar o texto da pontuação
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score.ToString();
        }
    }
}