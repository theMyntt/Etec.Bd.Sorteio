using System;
using Etec.Sorteio.Context;
using Etec.Sorteio.Models;
using Microsoft.EntityFrameworkCore;

namespace Etec.Sorteio.Repositories;

public class SorteioRepository
{
    private readonly DatabaseContext _context;

    public SorteioRepository(DatabaseContext context) => _context = context;

    public async Task CreateAsync(SorteioModel model) 
    {
        await _context.Sorteios.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) 
    {
        var model = await _context.Sorteios.FirstOrDefaultAsync(x => x.Id == id);

        if (model == null)
            throw new Exception("Nenhum sorteio encontrado");

        _context.Sorteios.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SorteioModel>> GetAsync() 
    {
        return await _context.Sorteios.ToListAsync();
    }
}
