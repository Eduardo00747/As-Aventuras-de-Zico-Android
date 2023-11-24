using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGaiola : MonoBehaviour
{
    public JaulaController jaulaController; // Referência ao script JaulaController.
    public GameObject jaulaPrefab; // Referência ao prefab da gaiola que você deseja instanciar.
    public float respawnDelay = 4f; // Atraso em segundos para respawn.
    private bool gaiolaSpawnada = false;
    public ScorePointController scoreController; // Referência ao script ScorePointController.
    private bool primeiroRespawn = true;

    void Start()
    {
        SpawnNovaGaiola();
    }

    void Update()
    {
        // Verifique se a gaiola atual foi destruída e se uma gaiola não foi spawnada.
        if (jaulaController == null && !gaiolaSpawnada)
        {
            // Se foi destruída e uma gaiola não foi spawnada, chame a função para spawnar uma nova gaiola.
            Invoke("SpawnNovaGaiola", respawnDelay);
            gaiolaSpawnada = true;
        }
    }

    void SpawnNovaGaiola()
    {
        // Verifique se este é o primeiro respawn ou não
        if (!primeiroRespawn)
        {
            // Adicione pontuação apenas a partir do segundo respawn
            scoreController.AddScore(10);
        }
        primeiroRespawn = false;

        // Crie uma nova instância da gaiola a partir do prefab.
        GameObject novaGaiola = Instantiate(jaulaPrefab, transform.position, Quaternion.identity);

        // Obtenha a referência ao script JaulaController da nova gaiola.
        jaulaController = novaGaiola.GetComponent<JaulaController>();
        gaiolaSpawnada = false; // Resete a variável para permitir o próximo spawn.
    }
}
