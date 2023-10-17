using AutoMapper;
using BloodTransferAPI.Data;
using BloodTransferAPI.DTOs;
using BloodTransferAPI.Handler;
using BloodTransferAPI.Model;
using BloodTransferAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Net.WebSockets;

namespace BloodTransferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecieverController : Controller
    {
        private readonly IRecieverHandler _recieverHandler;
        private readonly IMapper _mapper;

        public RecieverController(IRecieverHandler recieverHandler, IMapper mapper)
        {
            _recieverHandler = recieverHandler;
            _mapper = mapper;
        }

        [HttpGet]                                                                            
        public IActionResult Get() => Ok(_recieverHandler.Get());

        [HttpPost]
        public IActionResult AddReciever(RecieverDTO addReciever)
        {
            var model = _mapper.Map<BloodTransferModel>(addReciever);
         //   if (addReciever.UserId != null||addReciever.UserId!=0)
          //  {
          //      return BadRequest("you shoudnt insert UserId manually (system will do this automatically)");
          //  }
            if (string.IsNullOrEmpty(addReciever.FullName) ||
                string.IsNullOrEmpty(addReciever.UnitOfBlood.ToString())||
                string.IsNullOrEmpty(addReciever.BloodGroupType) ||
                string.IsNullOrEmpty(addReciever.NumberOfRecieving.ToString()) ||
                string.IsNullOrEmpty(addReciever.RecieverId.ToString()))
            {
                return BadRequest("fields cant be Null");
            }
            _recieverHandler.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateReciever(RecieverDTO updateReciever)
        {
            if (string.IsNullOrEmpty(updateReciever.UserId.ToString()) ||
                string.IsNullOrEmpty(updateReciever.FullName) ||
                string.IsNullOrEmpty(updateReciever.BloodGroupType) ||
                string.IsNullOrEmpty(  updateReciever.UnitOfBlood.ToString())||
                string.IsNullOrEmpty(updateReciever.NumberOfRecieving.ToString()) ||
                string.IsNullOrEmpty(updateReciever.RecieverId.ToString()))
            {
                return BadRequest("fields cant be Null");
            }
            _recieverHandler.Update(updateReciever);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReciever(int id)
        {
            var model = _recieverHandler.GetById(id);
            if (id == null || id == 0)
            {
                return BadRequest("feilds cant be Null ");
            }
            _recieverHandler.Delete(model);
            return Ok();
        }
    }
}
