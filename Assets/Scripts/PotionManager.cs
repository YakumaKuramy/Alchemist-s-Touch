using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Receita
{
    public string nomeDaReceita; // Nome que você dá no Inspector
    public List<string> ingredientes;
    public GameObject resultadoPrefab;
}

public class PotionManager : MonoBehaviour
{
    public List<Receita> receitasDisponiveis;
    public Transform pontoDeSpawn;

    private List<string> itensNoCaldeirao = new List<string>();

    public void RegistrarIngrediente(GameObject ingrediente)
    {
        var settings = ingrediente.GetComponent<ObjectSettings>();
        if (settings != null)
        {
            itensNoCaldeirao.Add(settings.Id);
            Debug.Log("Caldeirão recebeu: " + settings.Id);
            VerificarCombinacoes();
        }
    }

    void VerificarCombinacoes()
    {
        foreach (var receita in receitasDisponiveis)
        {
            if (itensNoCaldeirao.Count == receita.ingredientes.Count)
            {
                bool sucesso = true;
                foreach (var ing in receita.ingredientes)
                {
                    if (!itensNoCaldeirao.Contains(ing)) { sucesso = false; break; }
                }

                if (sucesso)
                {
                    CriarResultado(receita);
                    break;
                }
            }
        }
    }

    void CriarResultado(Receita receita)
    {
        Debug.Log("✨ Você criou: " + receita.nomeDaReceita);
        if (receita.resultadoPrefab != null)
        {
            // Isso faz a poção aparecer exatamente onde o caldeirão está
            GameObject novaPocao = Instantiate(receita.resultadoPrefab, pontoDeSpawn.position, Quaternion.identity);

            // Isso coloca a poção "dentro" da sua tela (Canvas)
            novaPocao.transform.SetParent(pontoDeSpawn.parent, false);
            novaPocao.transform.position = pontoDeSpawn.position;
            novaPocao.transform.localScale = Vector3.one; // Garante o tamanho certo
        }
        itensNoCaldeirao.Clear();
    }
}