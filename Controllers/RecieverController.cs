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
           if (addReciever.UserId==null||addReciever.UserId!=0)
           {
             return BadRequest("you shoudnt insert UserId manually (system will do this automatically , please set 0 as defualt)");
            }

            if(( addReciever.UnitOfBlood == null || addReciever.UnitOfBlood==0)||
               (addReciever.NumberOfRecieving==null|| addReciever.NumberOfRecieving==0)||
               (addReciever.RecieverId==null || addReciever.RecieverId==0)||
               (addReciever.FullName==null||addReciever.FullName=="string")||
               (addReciever.BloodGroupType==null||addReciever.BloodGroupType=="string"))
            {
                return BadRequest("fields cant be Null");
            }
            _recieverHandler.Add(model);
            return Ok();
            }

        [HttpPut]
        public IActionResult UpdateReciever(RecieverDTO updateReciever)
        {
            if ((updateReciever.UserId==null||updateReciever.UserId!=0)||
               (updateReciever.UnitOfBlood == null || updateReciever.UnitOfBlood == 0) ||
               (updateReciever.NumberOfRecieving == null || updateReciever.NumberOfRecieving == 0) ||
               (updateReciever.RecieverId == null || updateReciever.RecieverId == 0) ||
               (updateReciever.FullName == null || updateReciever.FullName == "string") ||
              (updateReciever.BloodGroupType == null || updateReciever.BloodGroupType == "string"))
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
