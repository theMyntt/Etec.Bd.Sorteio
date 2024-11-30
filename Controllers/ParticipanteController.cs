using System;
using Etec.Sorteio.Models;
using Etec.Sorteio.Repositories;

namespace Etec.Sorteio.Controllers;

public class ParticipanteController
{
    private readonly ParticipantesRepository _repository;

    public ParticipanteController(ParticipantesRepository repository) => _repository = repository;

    public async Task<IEnumerable<ParticipanteModel>> GetAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task CreateAsync(string Nome)
    {
        var model = new ParticipanteModel
        {
            Name = Nome
        };

        await _repository.CreateAsync(model);
    }

    public async Task DeleteAsync(int id) 
    {
        await _repository.DeleteAsync(id);
    }
}
