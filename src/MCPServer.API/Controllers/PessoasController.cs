using MCPServer.API.Data;
using MCPServer.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCPServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoasController(ApiDbContext apiDbContext) : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string? nome) => 
        Ok(apiDbContext.Pessoas
            .Where(x => string.IsNullOrWhiteSpace(nome) || x.Nome.Contains(nome))
            .Select(x => new PessoaResultModel(x.Nome, x.Resumo, x.Biografia, x.DataNascimento)));


    [HttpPost]
    public async Task<IActionResult> Post(PessoaInputModel model, CancellationToken cancellationToken = default)
    {
        await apiDbContext.Pessoas
            .AddAsync(new(model.Nome, model.Resumo, model.Biografia, model.DataNascimento), cancellationToken);

        await apiDbContext.SaveChangesAsync();

        return Ok();
    }
}
