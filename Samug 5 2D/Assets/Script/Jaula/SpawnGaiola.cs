using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGaiola : MonoBehaviour
{
    public JaulaController jaulaController; // Refer�ncia ao script JaulaController.
    public GameObject jaulaPrefab; // Refer�ncia ao prefab da gaiola que voc� deseja instanciar.
    public float respawnDelay = 4f; // Atraso em segundos para respawn.
    private bool gaiolaSpawnada = false;
    public ScorePointController scoreController; // Refer�ncia ao script ScorePointController.
    private bool primeiroRespawn = true;

    void Start()
    {
        SpawnNovaGaiola();
    }

    void Update()
    {
        // Verifique se a gaiola atual foi destru�da e se uma gaiola n�o foi spawnada.
        if (jaulaController == null && !gaiolaSpawnada)
        {
            // Se foi destru�da e uma gaiola n�o foi spawnada, chame a fun��o para spawnar uma nova gaiola.
            Invoke("SpawnNovaGaiola", respawnDelay);
            gaiolaSpawnada = true;
        }
    }

    void SpawnNovaGaiola()
    {
        // Verifique se este � o primeiro respawn ou n�o
        if (!primeiroRespawn)
        {
            // Adicione pontua��o apenas a partir do segundo respawn
            scoreController.AddScore(10);
        }
        primeiroRespawn = false;

        // Crie uma nova inst�ncia da gaiola a partir do prefab.
        GameObject novaGaiola = Instantiate(jaulaPrefab, transform.position, Quaternion.identity);

        // Obtenha a refer�ncia ao script JaulaController da nova gaiola.
        jaulaController = novaGaiola.GetComponent<JaulaController>();
        gaiolaSpawnada = false; // Resete a vari�vel para permitir o pr�ximo spawn.
    }
}
