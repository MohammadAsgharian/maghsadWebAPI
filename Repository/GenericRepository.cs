using System;
using System.Collections.Generic;
using System.Linq;
using maghsadAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace maghsadAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        private readonly Data.MaghsadContext _context;

        public GenericRepository(Data.MaghsadContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetListAsync()
        {
        return await _context.Set<T>().ToListAsync();
        }
    }
}