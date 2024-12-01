using System;
using Etec.Sorteio.Models;
using Etec.Sorteio.Repositories;

namespace Etec.Sorteio.Controllers;

public class MensagemController
{
    private readonly MensagemRepository _repository;

    public MensagemController(MensagemRepository repository) => _repository = repository;

    public async Task CreateAsync(MensagemModel model) => await _repository.CreateAsync(model);
    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    public async Task<IEnumerable<MensagemModel>> GetAsync() => await _repository.GetAsync();
}
