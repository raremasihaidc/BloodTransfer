using AutoMapper;
using BloodTransferAPI.Controllers;
using BloodTransferAPI.DTOs;
using BloodTransferAPI.Model;
using BloodTransferAPI.Repositories;

namespace BloodTransferAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BloodTransferModel, RecieverDTO>();
            CreateMap<BloodTransferModel, TransferDTO>();
            CreateMap<BloodTransferModel,TransmitterDTO>();
            CreateMap< RecieverDTO, BloodTransferModel>();
            CreateMap< TransferDTO, BloodTransferModel>();
            CreateMap< TransmitterDTO, BloodTransferModel>();
        }
    }
}
