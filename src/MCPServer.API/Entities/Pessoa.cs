namespace MCPServer.API.Entities;

public class Pessoa
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; }
    public string Resumo { get; private set; }
    public string Biografia { get; private set; }
    public DateOnly DataNascimento { get; set; }

    protected Pessoa() { }

    public Pessoa(string nome, string resumo, string bioagrafia, DateOnly dataNascimento)
    {
        Nome = nome;
        Resumo = resumo;
        Biografia = bioagrafia;
        DataNascimento = dataNascimento;
    }
}
