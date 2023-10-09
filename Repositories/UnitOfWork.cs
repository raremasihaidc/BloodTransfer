using AutoMapper;
using BloodTransferAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BloodTransferAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {   private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(AppDbContext Context, IMapper mapper )
        {   _context = Context;
            _mapper = mapper;
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
