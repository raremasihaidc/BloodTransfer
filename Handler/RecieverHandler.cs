using AutoMapper;
using BloodTransferAPI.Data;
using BloodTransferAPI.Controllers;
using BloodTransferAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using BloodTransferAPI.Model;
using Azure.Core;
using BloodTransferAPI.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BloodTransferAPI.Handler
{
    public class RecieverHandler : IRecieverHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecieverRepository _repository;
        private readonly IMapper _mapper;
        public RecieverHandler(IRecieverRepository repository, IMapper mapper , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
        public void Add(BloodTransferModel AddTransmitter)
        {
            _repository.Add(AddTransmitter);
            _unitOfWork.save();
        }
        public void Delete(BloodTransferModel DeleteByid)
        {
            var model = _repository.GetById(DeleteByid.UserId);
            if (model != null)
            {
                _repository.Delete(model);
            }
            _unitOfWork.save();
        }
        public void Update(RecieverDTO UpdateReciever)
        {
            var reciever = _repository.GetById(UpdateReciever.UserId);
            if (reciever != null)
            {
                reciever.UnitOfBlood = UpdateReciever.UnitOfBlood;
                reciever.RecieverId = UpdateReciever.RecieverId;
                reciever.NumberOfRecieving = UpdateReciever.NumberOfRecieving;
                reciever.BloodGroupType = UpdateReciever.BloodGroupType;
                reciever.FullName = UpdateReciever.FullName;
            }
            _repository.Update(reciever);
            _unitOfWork.save();
        }
        public List<RecieverDTO> Get()
        {
            var result = _repository.Get();
            var getReciever= _mapper.Map<List<RecieverDTO>>(result);
            return getReciever;
        }
        public BloodTransferModel GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                _repository.Delete(model);
            }
            return model;

        }
    }
}
