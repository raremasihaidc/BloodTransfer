using AutoMapper;
using BloodTransferAPI.Data;
using BloodTransferAPI.DTOs;
using BloodTransferAPI.Handler;
using BloodTransferAPI.Model;
using BloodTransferAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodTransferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmitterController : Controller
    {
        private readonly ITransmiiterhandler _transmitterHandler;
        private readonly IMapper _mapper;
        public TransmitterController(ITransmiiterhandler transmiiterhandler, IMapper mapper)
        {
            _transmitterHandler = transmiiterhandler;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get() => Ok(_transmitterHandler.Get());

        [HttpPost]
        public IActionResult AddTransmitter(TransmitterDTO addTransmitter)
        {
           var model = _mapper.Map<BloodTransferModel>(addTransmitter);
             if (addTransmitter.UserId == null || addTransmitter.UserId != 0)
             {
               return BadRequest("you shoudnt insert UserId manually (system will do this automatically , please set 0 as defualt)");
              }
           if ((addTransmitter.UnitOfBlood == null || addTransmitter.UnitOfBlood == 0) ||
             (addTransmitter.NumberOfTransmitting == null || addTransmitter.NumberOfTransmitting == 0) ||
             (addTransmitter.TransmiiterId == null || addTransmitter.TransmiiterId == 0) ||
            (addTransmitter.FullName == null || addTransmitter.FullName == "string") ||
            (addTransmitter.BloodGroupType == null || addTransmitter.BloodGroupType == "string"))
            {
             return BadRequest("fields cant be Null");
             }
           _transmitterHandler.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTransmitter(TransmitterDTO updateTransmitter)
        {
              if ((updateTransmitter.UserId == null || updateTransmitter.UserId != 0) ||
                 (updateTransmitter.UnitOfBlood == null || updateTransmitter.UnitOfBlood == 0) ||
                 (updateTransmitter.NumberOfTransmitting == null || updateTransmitter.NumberOfTransmitting == 0) ||
                (updateTransmitter.TransmiiterId == null || updateTransmitter.TransmiiterId == 0) ||
                (updateTransmitter.FullName == null || updateTransmitter.FullName == "string") ||
               (updateTransmitter.BloodGroupType == null || updateTransmitter.BloodGroupType == "string"))
              {
                   return BadRequest("fields cant be Null");
              }
                _transmitterHandler.Update(updateTransmitter);
              return Ok();
              }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransmitter(int id)
        {
            var model = _transmitterHandler.GetById(id);
            if (id == null || id == 0)
            {
                return BadRequest("not found");
            }
            _transmitterHandler.Delete(model);
            return Ok();
        }
    }

}
