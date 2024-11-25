using UnityEditor;
using UnityEngine;

public class CustomEditorWindow : EditorWindow
{
    [MenuItem("Window/Custom Editor Example")]
    public static void ShowWindow()
    {
        // Abre a janela do editor
        GetWindow<CustomEditorWindow>("My Custom Editor");
    }

    void OnGUI()
    {
        // Começa um grupo horizontal
        GUILayout.BeginHorizontal();
        GUILayout.Label("Escolha uma opção:", GUILayout.Width(150));
        
        // Botões
        if (GUILayout.Button("Iniciar"))
        {
            Debug.Log("Iniciar Jogo");
        }
        if (GUILayout.Button("Sair"))
        {
            Debug.Log("Sair do Jogo");
        }
        // Finaliza o grupo horizontal
        GUILayout.EndHorizontal();
    }
}
