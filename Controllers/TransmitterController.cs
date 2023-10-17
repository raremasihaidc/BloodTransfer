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
          //  if (addTransmitter.UserId != null || addTransmitter.UserId != 0)
          //  {
          //      return BadRequest("you shoudnt insert UserId manually (system will do this automatically)");
          //  }
            if (string.IsNullOrEmpty(addTransmitter.FullName) ||
                string.IsNullOrEmpty(addTransmitter.BloodGroupType) ||
                string.IsNullOrEmpty(addTransmitter.UnitOfBlood.ToString()) ||
                string.IsNullOrEmpty(addTransmitter.NumberOfTransmitting.ToString())||
                string.IsNullOrEmpty(addTransmitter.TransmiiterId.ToString()))
            {
                return BadRequest("fields cant be Null");
            }
            _transmitterHandler.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTransmitter(TransmitterDTO updateTransmitter)
        {
            if (string.IsNullOrEmpty(updateTransmitter.UserId.ToString()) ||
               string.IsNullOrEmpty(updateTransmitter.FullName) ||
               string.IsNullOrEmpty(updateTransmitter.BloodGroupType) ||
               string.IsNullOrEmpty(updateTransmitter.UnitOfBlood.ToString()) ||
               string.IsNullOrEmpty(updateTransmitter.NumberOfTransmitting.ToString()) ||
               string.IsNullOrEmpty(updateTransmitter.TransmiiterId.ToString()))
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
