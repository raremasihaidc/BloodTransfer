using AutoMapper;
using BloodTransferAPI.DTOs;
using BloodTransferAPI.Handler;
using BloodTransferAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BloodTransferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : Controller
    {
        private readonly ITransferHandler _transferHandler;
        private readonly IMapper _mapper;
        public TransferController(ITransferHandler transferHandler, IMapper mapper)
        {
            _transferHandler = transferHandler;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get() => Ok(_transferHandler.Get());
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model=_transferHandler.GetById(id);
            if (model == null)
            { 
                return BadRequest("not found"); 
            }
                return Ok(model);
        }
       
        [HttpPut]
        public IActionResult UpdateTransfer(TransferDTO updateTransfer)
        {
            if (updateTransfer?.RecieverId == 0 || updateTransfer?.TransmiiterId == 0)
            {
               return BadRequest("fields cant be Null");
            } 
            _transferHandler.Update(updateTransfer);
            return Ok();

        }
    }
}
