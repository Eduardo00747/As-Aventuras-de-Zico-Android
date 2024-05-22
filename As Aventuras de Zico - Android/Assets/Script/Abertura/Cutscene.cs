using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Adicione este namespace

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogo;

    [SerializeField]
    private GameObject caixaDeDialogo;

    [SerializeField]
    private List<Dialogue> dialogos;

    [SerializeField]
    private Button botaoB; // Referência ao botão "Botão B"

    [SerializeField]
    private Button botaoSkip; // Referência ao botão "Botão Skip"

    private TextMeshProUGUI dialogoText;
    private int dialogoAtualIndex = 0;

    private Dialogue dialogoAtual; // Referência ao diálogo atual
    private bool podePressionarB = false; // Controle para a tecla B

    void Start()
    {
        dialogoText = dialogo.GetComponent<TextMeshProUGUI>();
        botaoB.onClick.AddListener(OnBotaoBPressionado); // Adiciona o listener para o botão "Botão B"
        botaoSkip.onClick.AddListener(OnBotaoSkipPressionado); // Adiciona o listener para o botão "Botão Skip"
        StartCoroutine(AtivarObjetosDepoisDeDoisSegundos());
    }

    public void OnBotaoBPressionado()
    {
        if (!podePressionarB)
            return;

        podePressionarB = false; // Impede que o botão seja pressionado novamente enquanto o diálogo está sendo atualizado

        if (dialogoAtual != null && dialogoAtualIndex < 13) // Desativa nome e imagem apenas se não for o último diálogo
        {
            dialogoAtual.Nome.gameObject.SetActive(false);
            dialogoAtual.Imagem.gameObject.SetActive(false);
        }

        if (dialogoAtualIndex < dialogos.Count - 1)
        {
            dialogoAtualIndex++;
            AtualizarDialogo();
        }
        else
        {
            // Verifica se o índice do diálogo atual é o último diálogo
            if (dialogoAtualIndex >= 12) // 12 é o 13º diálogo (índice baseado em zero)
            {
                SceneManager.LoadScene("Fase 1");
            }
        }
    }

    public void OnBotaoSkipPressionado()
    {
        SceneManager.LoadScene("Fase 1");
    }

    IEnumerator AtivarObjetosDepoisDeDoisSegundos()
    {
        yield return new WaitForSeconds(2);
        dialogo.SetActive(true);
        caixaDeDialogo.SetActive(true);
        StartCoroutine(AtivarZicoENomeZicoDepoisDeUmSegundo());
    }

    IEnumerator AtivarZicoENomeZicoDepoisDeUmSegundo()
    {
        yield return new WaitForSeconds(1);
        AtualizarDialogo();
    }

    private void AtualizarDialogo()
    {
        if (dialogos.Count > dialogoAtualIndex)
        {
            dialogoAtual = dialogos[dialogoAtualIndex];
            dialogoText.text = ""; // Limpa o texto inicialmente

            // Ativa o TextMeshPro e a imagem
            dialogoAtual.Nome.gameObject.SetActive(true);
            dialogoAtual.Imagem.gameObject.SetActive(true);

            StartCoroutine(ExibirDialogoPorLetra(dialogoAtual));
        }
    }

    private IEnumerator ExibirDialogoPorLetra(Dialogue dialogoAtual)
    {
        for (int i = 0; i < dialogoAtual.dialogo.Length; i++)
        {
            dialogoText.text += dialogoAtual.dialogo[i];
            yield return new WaitForSeconds(0.05f);
        }
        podePressionarB = true; // Reativa a tecla B após a exibição do diálogo
    }
}

[System.Serializable]
public class Dialogue
{
    public TextMeshProUGUI Nome; // Referência ao componente TextMeshProUGUI do nome do personagem
    public Image Imagem; // Referência ao componente Image da imagem do personagem

    public string dialogo; // Texto do diálogo.
}
