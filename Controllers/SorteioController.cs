using System;
using Etec.Sorteio.Models;
using Etec.Sorteio.Repositories;

namespace Etec.Sorteio.Controllers;

public class SorteioController
{
    private SorteioRepository _sorteioRepository;
    private ParticipantesRepository _participantesRepository;
    private PresenteRepository _presenteRepository;

    public SorteioController(SorteioRepository sorteioRepository, ParticipantesRepository participanteRepository, PresenteRepository presenteRepository)
    {
        _presenteRepository = presenteRepository;
        _sorteioRepository = sorteioRepository;
        _participantesRepository = participanteRepository;
    }

    public async Task CreateAsync(SorteioModel model)
    {
        await _sorteioRepository.CreateAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        await _sorteioRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SorteioModel>> GetAsync()
    {
        return await _sorteioRepository.GetAsync();
    }

    public async Task MakeRaffle()
    {
        var participantes = await _participantesRepository.GetAsync();
        var presentes = await _presenteRepository.GetAsync();

        if (participantes.Count() != presentes.Count())
            throw new Exception("Para realizar o sorteio, você precisa ter o mesmo número de participantes e presentes!");

        await _sorteioRepository.MakeRaffle();
    }
}
