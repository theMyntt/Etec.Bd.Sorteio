using System;
using Etec.Sorteio.Context;
using Etec.Sorteio.Models;
using Microsoft.EntityFrameworkCore;

namespace Etec.Sorteio.Repositories;

public class PresenteRepository 
{
    private readonly DatabaseContext _context;

    public PresenteRepository(DatabaseContext context) => _context = context;

    public async Task CreateAsync(PresenteModel model)
    {
        await _context.Presentes.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) 
    {
        var model = await _context.Presentes.FirstOrDefaultAsync(x => x.Id == id);

        if (model == null)
            throw new Exception("Nenhum presente encontrado");
        
        _context.Presentes.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PresenteModel>> GetAsync()
    {
        return await _context.Presentes.ToListAsync();
    }
}
