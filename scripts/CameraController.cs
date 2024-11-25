using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focoPlayer;
    public Transform camPLayer;
    // Start is called before the first frame update
void Start()
{
    // Mantém a posição da câmera, mas ajusta a rotação para olhar para o jogador
    transform.position = camPLayer.position;
    transform.rotation = camPLayer.rotation; // Atribui rotação (Quaternion)
    transform.LookAt(focoPlayer);  // Faz a câmera olhar para o foco do jogador
}

// Update is called once per frame
void Update()
{
    // Mantém a posição da câmera, mas ajusta a rotação para olhar para o jogador
    transform.position = camPLayer.position;
    transform.rotation = camPLayer.rotation; // Atribui rotação (Quaternion)
    transform.LookAt(focoPlayer);  // Faz a câmera olhar para o foco do jogador
}

}
