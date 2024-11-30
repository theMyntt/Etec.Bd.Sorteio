using System;
using Etec.Sorteio.Context;
using Etec.Sorteio.Models;
using Microsoft.EntityFrameworkCore;

namespace Etec.Sorteio.Repositories;

public class ParticipantesRepository
{
    private readonly DatabaseContext _context;

    public ParticipantesRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ParticipanteModel participante)
    {
        await _context.Participantes.AddAsync(participante);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Participantes.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new Exception("Nenhum participante encontrado");

        _context.Participantes.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ParticipanteModel>> GetAsync()
    {
        return await _context.Participantes.ToListAsync();
    }
}