using AutoMapper;
using BloodTransferAPI.Data;
using BloodTransferAPI.DTOs;
using BloodTransferAPI.Model;
using BloodTransferAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BloodTransferAPI.Handler
{
    public class TransfertHandler : ITransferHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _appDbContext;
        private readonly ITransferRepository _repository;
        private readonly IMapper _mapper;
        public TransfertHandler(ITransferRepository repository, IMapper mapper, AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appDbContext = appDbContext;
            _repository = repository;
            _mapper = mapper;
        }
        public void Update(TransferDTO UpdateTransfer)
        {
            var transmitter = _appDbContext.BloodTransfers.FirstOrDefault(x => x.TransmiiterId == UpdateTransfer.TransmiiterId);
            var reciever = _appDbContext.BloodTransfers.FirstOrDefault(y => y.RecieverId == UpdateTransfer.RecieverId);
            if (transmitter != null && reciever != null)
            {
                if (transmitter.BloodGroupType == reciever.BloodGroupType)
                {
                    transmitter.UnitOfBlood -= 2;
                    transmitter.NumberOfTransmitting++;
                    reciever.NumberOfRecieving++;
                    reciever.UnitOfBlood += 2;
                    _repository.Update(transmitter);
                    _repository.Update(reciever);
                }
                    else {
                          throw new Exception("The blood group types of the transmitter and receiver do not match.");
                        }
            _unitOfWork.save();
        }
        public List<BloodTransferModel> Get()
        {
            var result = _repository.Get();
            var getTransfer = _mapper.Map<List<BloodTransferModel>>(result);
            return getTransfer;
        }
        public BloodTransferModel GetById(int id)
        {
            var model = _repository.GetById(id);
            return model;
        }
    }
}
