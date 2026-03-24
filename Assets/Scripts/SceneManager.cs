using UnityEngine;
using UnityEngine.SceneManagement; // ESSA LINHA É A MAIS IMPORTANTE!

public class GerenciadorCenas : MonoBehaviour
{
    // Função pública que o botão vai chamar
    public void CarregarCenaDoJogo()
    {
        // Aqui dizemos o NOME EXATO da cena que queremos abrir
        SceneManager.LoadScene("SceneGamePlay");
    }

    // Função opcional para fechar o jogo (só funciona no jogo buildado)
    public void SairDoJogo()
    {
        Application.Quit();
    }
}