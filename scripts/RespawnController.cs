using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint; // O ponto de respawn para onde o personagem vai
    private Vector3 startPosition; // A posição inicial do personagem (caso você queira respawnar para o ponto inicial)

    void Start()
    {
        // Armazena a posição inicial do personagem no início do jogo
        startPosition = transform.position;
    }

    void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu do cenário é o personagem
        if (other.CompareTag("Player"))
        {
            // Respawn o jogador para o ponto de respawn
            RespawnPlayer();
        }
    }

    // Função para respawnar o jogador
    void RespawnPlayer()
    {
        // Verifica se há um ponto de respawn definido
        if (respawnPoint != null)
        {
            // Move o jogador para o ponto de respawn
            transform.position = respawnPoint.position;
        }
        else
        {
            // Se não houver ponto de respawn, respawna no ponto inicial
            transform.position = startPosition;
        }
    }
}
