using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text pontuacaoFinalText;

    void Start()
    {
        // Recupere a pontuação salva nos PlayerPrefs
        int pontuacao = PlayerPrefs.GetInt("Pontuacao", 0);
        pontuacaoFinalText.text = "" + pontuacao.ToString();
    }
}