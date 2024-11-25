using UnityEngine;
using UnityEngine.SceneManagement;  // Para carregar cenas
using System.Collections;  // Para usar coroutines

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;  // Vida inicial do jogador
    public Transform spawnPoint; // Ponto de respawn (onde o jogador será reposicionado)
    public string sceneName = "CenaInicial"; // Nome da cena para respawn ou reinício
    public int maxDamageCount = 3;  // Máximo de danos que o jogador pode receber antes de morrer
    private int damageCount = 0;  // Contador de danos

    private Collider playerCollider;  // Referência ao collider do jogador

    void Start()
    {
        playerCollider = GetComponent<Collider>();  // Pegando o componente Collider do jogador
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido tem a tag "Dano"
        if (other.CompareTag("Dano"))
        {
            // Aplica o dano ao jogador
            TakeDamage(20); // Aqui estamos aplicando 20 de dano
        }
    }

    // Função para reduzir a vida do jogador
    public void TakeDamage(int damage)
    {
        // Verifique se o jogador ainda pode levar dano
        if (damageCount < maxDamageCount)
        {
            damageCount++;  // Incrementa o contador de dano
            health -= damage;  // Aplica o dano ao jogador
            Debug.Log("Vida do jogador: " + health + ", Dano recebido: " + damageCount);  // Exibe no console a vida atual e o número de danos

            // Se a quantidade de dano for suficiente, o jogador morre
            if (damageCount >= maxDamageCount)
            {
                Die();  // Chama a função para a morte do jogador
            }
        }
    }

    // Função chamada quando a vida chega a zero (ou o jogador recebe 3 danos)
    void Die()
    {
        Debug.Log("Jogador morreu!");

        // Desabilita o Collider do jogador para evitar colisões enquanto ele morre
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        // Desabilitar o dano temporariamente ou os inimigos (se necessário)
        DisableEnemiesDamage();

        // Chama a Coroutine de respawn
        StartCoroutine(Respawn());
    }

    // Função para desabilitar dano de inimigos temporariamente
    void DisableEnemiesDamage()
    {
        // Aqui você pode buscar e desabilitar o dano de inimigos, por exemplo:
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Inimigo");

        foreach (GameObject enemy in enemies)
        {
            DanoInimigo enemyScript = enemy.GetComponent<DanoInimigo>();
            if (enemyScript != null)
            {
                enemyScript.enabled = false;  // Desabilita o dano do inimigo
            }
        }
    }

    // Função para respawnar o jogador
    IEnumerator Respawn()
    {
        // Aguarda 3 segundos antes de realizar o respawn (ajuste conforme necessário)
        yield return new WaitForSeconds(3f);

        // Se o ponto de respawn foi definido, reposiciona o jogador
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }
        else
        {
            Debug.LogError("Ponto de respawn não definido!");
        }

        health = 100;  // Restaura a vida para o valor inicial (100)
        damageCount = 0;  // Reseta o contador de danos
        Debug.Log("Jogador respawnado!");

        // Reabilita o Collider do jogador após o respawn
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }

        // Reabilita o dano dos inimigos
        EnableEnemiesDamage();

        // Reinicia a cena atual ou carrega uma nova cena
        ReloadScene();
    }

    // Função para reabilitar o dano dos inimigos
    void EnableEnemiesDamage()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Inimigo");

        foreach (GameObject enemy in enemies)
        {
            DanoInimigo enemyScript = enemy.GetComponent<DanoInimigo>();
            if (enemyScript != null)
            {
                enemyScript.enabled = true;  // Reabilita o dano do inimigo
            }
        }
    }

    // Função para reiniciar a cena ou carregar uma nova
    void ReloadScene()
    {
        // Opcional: Carregar a mesma cena para reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Ou carregar uma cena específica (caso queira mudar para uma nova cena)
        // SceneManager.LoadScene(sceneName); // Descomente se quiser mudar para uma nova cena
    }
}
