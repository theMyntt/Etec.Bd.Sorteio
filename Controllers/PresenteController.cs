using System;
using Etec.Sorteio.Models;
using Etec.Sorteio.Repositories;

namespace Etec.Sorteio.Controllers;

public class PresenteController
{
    private readonly PresenteRepository _repository;

    public PresenteController(PresenteRepository repository) => _repository = repository;

    public async Task CreateAsync(PresenteModel model)
    {
        await _repository.CreateAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PresenteModel>> GetAsync()
    {
        return await _repository.GetAsync();
    }
}
