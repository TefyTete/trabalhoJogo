using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Função para iniciar o jogo
    public void StartGame()
    {
        // Carrega a cena do jogo (modifique o nome da cena para o nome correto)
        SceneManager.LoadScene("CenaJogo"); // Corrija o nome da cena
    }

    // Função para sair do jogo
    public void ExitGame()
    {
        // Exibe uma mensagem no console quando o jogador clica para sair
        Debug.Log("Saindo do jogo...");

        // Se estiver no editor, mostra uma mensagem para evitar fechamento inesperado
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para parar a execução no editor
        #else
        Application.Quit(); // Fecha o aplicativo na versão final
        #endif
    }
}
