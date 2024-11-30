using System;
using Etec.Sorteio.Context;
using Etec.Sorteio.Models;
using Microsoft.EntityFrameworkCore;

namespace Etec.Sorteio.Repositories;

public class MensagemRepository
{
    private readonly DatabaseContext _context;

    public MensagemRepository(DatabaseContext context) => _context = context;

    public async Task CreateAsync(MensagemModel model)
    {
        await _context.Mensagens.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _context.Mensagens.FirstOrDefaultAsync(x => x.Id == id);

        if (model == null)
            throw new Exception("Nenhuma mensagem encontrada");

        _context.Mensagens.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MensagemModel>> GetAsync()
    {
        return await _context.Mensagens.ToListAsync();
    }
}
