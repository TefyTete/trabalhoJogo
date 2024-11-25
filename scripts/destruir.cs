using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public int dano = 20;  // Quantidade de dano que o objeto causa ao jogador

    // Essa função é chamada quando o Player entra em um Collider com "Is Trigger" marcado como true
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player recebeu dano!");

            // Acessa o script PlayerHealth no jogador e aplica o dano
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dano); // Aplica o dano ao jogador
            }
        }
    }
}
