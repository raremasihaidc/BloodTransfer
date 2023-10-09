using AutoMapper;
using BloodTransferAPI.Data;
using BloodTransferAPI.DTOs;
using BloodTransferAPI.Model;
using BloodTransferAPI.Repositories;

namespace BloodTransferAPI.Handler
{
    public class TransmitterHandler : ITransmiiterhandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransmitterRepository _repository;
        private readonly IMapper _mapper;
        public TransmitterHandler(IMapper mapper, ITransmitterRepository repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }
        public void Add(BloodTransferModel AddTransmitter)
        {
            var reciever = _repository.GetById(AddTransmitter.UserId);
            if (reciever != null)
            {
                reciever.UnitOfBlood = AddTransmitter.UnitOfBlood;
                reciever.TransmiiterId = AddTransmitter.TransmiiterId;
                reciever.NumberOfRecieving = AddTransmitter.NumberOfRecieving;
                reciever.BloodGroupType = AddTransmitter.BloodGroupType;
                reciever.FullName = AddTransmitter.FullName;
            }
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
        public List<TransmitterDTO> Get()
        {
            var result = _repository.Get();
            var getTransmitter = _mapper.Map<List<TransmitterDTO>>(result);
            return getTransmitter;
        }
        public void Update(TransmitterDTO UpdateTransmitter)
        {
            var transmitter = _repository.GetById(UpdateTransmitter.UserId);
            if (transmitter != null)
            {
                transmitter.UnitOfBlood = UpdateTransmitter.UnitOfBlood;
                transmitter.TransmiiterId = UpdateTransmitter.TransmiiterId;
                transmitter.NumberOfTransmitting = UpdateTransmitter.NumberOfTransmitting;
                transmitter.BloodGroupType = UpdateTransmitter.BloodGroupType;
                transmitter.FullName = UpdateTransmitter.FullName;
            }
            _repository.Update(transmitter);
            _unitOfWork.save();
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

