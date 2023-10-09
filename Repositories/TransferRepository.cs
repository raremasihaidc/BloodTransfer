using AutoMapper;
using BloodTransferAPI.Data;
using BloodTransferAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodTransferAPI.Repositories
{
    public class TransferRepository : ITransferRepository
    { 
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public TransferRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Update(BloodTransferModel model)
        {
            _context.BloodTransfers.Update(model);
        }
        public BloodTransferModel GetById(int id)
        {
            var getTransferById = _context.BloodTransfers.Find(id);
            return getTransferById;
        }
        BloodTransferModel ITransferRepository.GetById(int id)
        {
            return GetById(id);
        }
        public List<BloodTransferModel> Get()
        {
            return _context.BloodTransfers.ToList();
        }
    }
}

