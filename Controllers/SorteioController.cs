using System;
using Etec.Sorteio.Models;
using Etec.Sorteio.Repositories;

namespace Etec.Sorteio.Controllers;

public class SorteioController
{
    private SorteioRepository _repository;

    public SorteioController(SorteioRepository repository) => _repository = repository;

    public async Task CreateAsync(SorteioModel model)
    {
        await _repository.CreateAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SorteioModel>> GetAsync() 
    {
        return await _repository.GetAsync();
    }

    public async Task MakeRaffle()
    {
        await _repository.MakeRaffle();
    }
}
