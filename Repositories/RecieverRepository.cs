using AutoMapper;
using BloodTransferAPI.Controllers;
using BloodTransferAPI.Data;
using BloodTransferAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BloodTransferAPI.Repositories
{
    public class RecieverRepository : IRecieverRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public RecieverRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Add(BloodTransferModel model)
        {
            _context.BloodTransfers.Add(model);
            _context.SaveChanges();
        }
        public void Delete(BloodTransferModel model)
        {
            _context.BloodTransfers.Remove(model);
            _context.SaveChanges();
        }
        public void Update(BloodTransferModel model)
        {
            _context.BloodTransfers.Update(model);
            _context.SaveChanges();
        }
        public BloodTransferModel GetById(int id)
        {
            var r = _context.BloodTransfers.Find(id);
            return r;
        }
        BloodTransferModel IRecieverRepository.GetById(int id)
        {
            return GetById(id);
        }
        public List<BloodTransferModel> Get()
        {
            return _context.BloodTransfers.ToList();
        }
    }
}