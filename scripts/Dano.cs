using UnityEngine;

public class Dano : MonoBehaviour
{
    public int dano = 20; // Quantidade de dano que o objeto causa ao jogador

    // Função chamada quando o Player entra em um Collider com "Is Trigger" marcado como true
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto colidido tem a tag "Player"
        {
            // Encontra o script PlayerHealth no jogador e causa o dano
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dano); // Aplica o dano ao jogador
            }
        }
    }
}
