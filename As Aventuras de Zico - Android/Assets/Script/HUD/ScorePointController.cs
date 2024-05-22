using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePointController : MonoBehaviour
{
    public TMP_Text scoreText; // Refer�ncia ao objeto de texto
    public int score = 0; // Pontua��o atual

    // Fun��o para adicionar pontos
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        // Salve a pontua��o atual nos PlayerPrefs
        PlayerPrefs.SetInt("Pontuacao", score);
    }

    // Fun��o para atualizar o texto da pontua��o
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score.ToString();
        }
    }
}