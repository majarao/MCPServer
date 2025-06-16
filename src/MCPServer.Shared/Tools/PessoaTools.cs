using MCPServer.Shared.Clients;
using MCPServer.Shared.Models;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MCPServer.Shared.Tools;

[McpServerToolType]
public static class PessoaTools
{
    [McpServerTool, Description("Busca as pessoas cadastradas, definindo um filtro opcional por nome")]
    public static async Task<string> ObterPessoas(PessoaClient pessoaClient,
    [Description("Filtro opcional pelo nome da pessoa")] string nome)
    {
        List<PessoaResultModel> pessoas = await pessoaClient.ObterPessoas(nome);

        return pessoas.Count == 0
            ? "Nenhuma pessoa encontrada"
            : JsonSerializer.Serialize(pessoas);
    }

    [McpServerTool, Description("Criar/Cadastrar uma pessoa")]
    public static async Task CriarPessoa(PessoaClient pessoaClient,
    [Description("Dados para criação da pessoa")] PessoaInputModel model) =>
        await pessoaClient.CriarPessoaAsync(model);
}
